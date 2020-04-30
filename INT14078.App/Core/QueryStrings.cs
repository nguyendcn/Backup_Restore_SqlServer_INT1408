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
                        		( SELECT backup_set_id 
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
    }
}
