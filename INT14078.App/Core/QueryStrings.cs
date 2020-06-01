using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT14078.App.Core
{
    public static class QueryStrings
    {
        private static string _currentDBName;
        public static string CurrentDBName
        {
            get
            {
                return _currentDBName;
            }
            set
            {
                _currentDBName = value;
                CurrentDevice = $"DEVICE_{value}";
            }
        }

        public static string CurrentDevice { get; set; }

        public static string CurrentPathDevice { get; set; }

        public static string GetAllDatabaseName
        {
            get
            {
                return @"USE Master
                         SELECT database_id, name
                         FROM sys.databases
                         WHERE(database_id >= 5) AND(NOT(name LIKE N'ReportServer%'))
                         ORDER BY NAME";
            }
        }

        public static string CheckUserPermission
        {
            get
            {
                return @"USE master
                         IS_ROLEMEMBER ('db_backupoperator') = 1 
	                     AND IS_ROLEMEMBER('db_owner') = 1
                         BEGIN
                            SELECT 1 AS result
                         END
                         ELSE
                         BEGIN
                             SELECT 0 AS result
                         END
                         ";
            }
        }

        public static string GetAllDeviceName
        {
            get
            {
                return
                    @"
                        SELECT name  FROM sys.backup_devices
                    ";
            }
        }

        public static string GetAllPositionOfBackupVersions
        {
            get
            {
                return
                    $@"
                        SELECT position, description, backup_start_date , user_name 
                        FROM  msdb.dbo.backupset 
                        WHERE  database_name ='{CurrentDBName}' AND type='D' AND 
                             backup_set_id >= 
                        		( SELECT MAX(backup_set_id)
                        		  FROM 	msdb.dbo.backupset
                        		  WHERE media_set_id = 
                        				( SELECT  MAX(media_set_id) 
                        				  FROM msdb.dbo.backupset  
                                          WHERE database_name = '{CurrentDBName}' AND type='D'
                                         ) AND position = 1    
                                 ) 
                        ORDER BY position DESC
                     ";
            }
        }

        public static string BackupFullDB
        {
            get
            {
                return
                    $@"
                        BACKUP DATABASE {CurrentDBName}
                        TO {CurrentDevice}
                      ";
            }
        }

        public static string BackupDBWithInit
        {
            get
            {
                return
                    $@"
                        BACKUP DATABASE {CurrentDBName}
                        TO {CurrentDevice}
                        WITH INIT
                      ";
            }
        }

        private static string _deleteBackupByPosition;
        public static string DeleteBackupByPosition
        {
            get
            {
                return _deleteBackupByPosition;
            }
            set
            {
                _deleteBackupByPosition =
                    $@"
                        declare @id int;

                        SELECT @id = v.backup_set_id
                        FROM
                        (   SELECT position, backup_set_id 
                            FROM  msdb.dbo.backupset 
                            WHERE  database_name ='{CurrentDBName}' AND type='D' AND 
                                 backup_set_id >= 
                            		( SELECT MAX(backup_set_id)
                            		  FROM 	msdb.dbo.backupset
                            		  WHERE media_set_id = 
                            				( SELECT  MAX(media_set_id) 
                            				  FROM msdb.dbo.backupset  
                                              WHERE database_name = '{CurrentDBName}' AND type='D'
                                             ) AND position = 1    
                            ) 
                        ) as v
                        WHERE position = {value}

                        BEGIN TRY
                            BEGIN TRANSACTION
                        			delete from msdb.dbo.backupfilegroup where backup_set_id = @id
                        			delete from msdb.dbo.backupfile where backup_set_id = @id

                                    delete from  msdb.dbo.Backupset where backup_set_id = @id
                                COMMIT
                        END TRY
                        BEGIN CATCH
                        	raiserror('Can not delete backup file position {value}', 1, 12)
                            ROLLBACK TRAN
                        END CATCH                    
                    ";
            }
        }

        public static string GetAllDeviceNameByDBName
        {
            get
            {
                return
                    $@"
                        SELECT DISTINCT fm.logical_device_name 
                        FROM
                        (   SELECT media_set_id 
                            FROM  msdb.dbo.backupset 
                            WHERE  database_name ='Test' AND type='D' AND 
                                 backup_set_id >= 
                            		( SELECT backup_set_id 
                            		  FROM 	msdb.dbo.backupset
                            		  WHERE media_set_id = 
                            				( SELECT  MAX(media_set_id) 
                            				  FROM msdb.dbo.backupset  
                                              WHERE database_name = 'Test' AND type='D'
                                             ) AND position = 1    
                                     ) 
                        ) as bs
                        Inner join 
                        (select * from msdb.dbo.backupmediafamily) as fm
                        on bs.media_set_id = fm.media_set_id
                      ";
            }
        }

        public static string CreateDevice
        {
            get
            {
                return
                    $@"
                        EXEC sp_addumpdevice 'disk', 'DEVICE_{CurrentDBName}', '{CurrentPathDevice}'  
                     ";
            }
        }

        public static string GetDevicePath
        {
            get
            {
                return
                    $@"
                        SELECT physical_name  FROM sys.backup_devices
                        WHERE name = '{CurrentDevice}'
                      ";
            }
        }

        private static string _restoreDBToAPosition;
        public static string RestoreDBToAPosition
        {
            get
            {
                return _restoreDBToAPosition;
            }
            set
            {
                _restoreDBToAPosition =
                    $@"
                        ALTER DATABASE {CurrentDBName} 
                        SET SINGLE_USER 
                        WITH ROLLBACK IMMEDIATE  
                        
                        USE tempdb 
                        
                        RESTORE DATABASE {CurrentDBName} 
                        FROM  {CurrentDevice}  
                        WITH FILE= {value}, REPLACE 
                        
                        ALTER DATABASE {CurrentDBName}  SET MULTI_USER
                    ";
            }
        }

        public static string ValidateRestoreDBByTime
        {
            get
            {
                return
                    $@"
                        declare @rv_db int;
                        select @rv_db = COUNT(*) from sys.databases
                        where name = '{CurrentDBName}' and recovery_model_desc = 'FULL'
                        if(@rv_db = 0)
                         select 0 as result;
                        else
                         select 1 as result;
                     ";
            }
        }

        public static string LastRestoreDBByTime
        {
            get
            {
                return
                    $"ALTER DATABASE {CurrentDBName} SET MULTI_USER";
            }
        }

        public static string fourthPart;
        public static string ThirdRestoreDBByTime
        {
            set
            {
                string logPath = $"{CurrentPathDevice.Substring(0, CurrentPathDevice.LastIndexOf("\\"))}\\{CurrentDBName}.trn";
                fourthPart =
                    $@"
                           RESTORE DATABASE {CurrentDBName} 
                           FROM DISK = '{logPath}' WITH STOPAT='{value}'
                    ";
            }

            get
            {
                return fourthPart;
            }
        }

        public static string SecondRestoreDBByTime
        {
            get
            {
                return
                    $@"

                           
                           RESTORE DATABASE {CurrentDBName} 
                           FROM DISK = '{CurrentPathDevice}' WITH NORECOVERY, REPLACE
                            
                     ";
            }

        }

        public static string FirstRestoreDbByTime
        {
            get
            {
                string logPath = $"{CurrentPathDevice.Substring(0, CurrentPathDevice.LastIndexOf("\\"))}\\{CurrentDBName}.trn";
                return
                    $@"
                           ALTER DATABASE {CurrentDBName} 
                           SET SINGLE_USER 
                           WITH ROLLBACK IMMEDIATE
                           
                           BACKUP LOG {CurrentDBName} 
                           TO DISK = '{logPath}' 
                           WITH INIT

                           USE tempdb

                           
                    ";
            }
        }
    }
}
