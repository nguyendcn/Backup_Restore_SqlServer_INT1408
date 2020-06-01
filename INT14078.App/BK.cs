using INT14078.App.Common;
using INT14078.App.Core;
using INT1408.Shared.SqlSupport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT14078.App
{
    public class BK
    {
        public ConnectionInfo ConnectionInfo { get; set; }

        private List<DatabaseBase> _databaseBases;
        public List<DatabaseBase> DatabaseBases
        {
            get
            {
                return _databaseBases;
            }
            set
            {
                try
                {
                    _databaseBases = value;
                    if(DatabaseBases.Count > 0)
                        OnListDatabaseBaseChanged(value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private DatabaseBase _currentDB;

        public DatabaseBase CurrentDataBase
        {
            get
            {
                return _currentDB;
            }
            set
            {
                try
                {
                    _currentDB = value;
                    QueryStrings.CurrentDBName = value.Name;
                    CurrentDatabaseHadChanged(value);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public string DeviceName { get; set; }

        #region Event
        public delegate void ListDatabaseBaseChanged(List<DatabaseBase> databaseBases);

        public event ListDatabaseBaseChanged OnListDatabaseBaseChanged;

        public delegate void CurrentDatabaseChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos = null, string deviceName = null);

        public event CurrentDatabaseChanged OnCurrentDatabaseChanged;
        #endregion

        public BK(ConnectionInfo connectionInfo, ListDatabaseBaseChanged changed, CurrentDatabaseChanged currentChanged)
        {
            ConnectionInfo = connectionInfo;
            this.OnListDatabaseBaseChanged = changed;
            this.OnCurrentDatabaseChanged = currentChanged;

            DatabaseBases = ExecuteQuery<DatabaseBase>.Execute(connectionInfo, QueryStrings.GetAllDatabaseName, 
                            (sqlDataReader) =>
                            {
                                return new DatabaseBase()
                                {
                                    ID = SqlSupport.Read<Int32>(sqlDataReader, "database_id"),
                                    Name = SqlSupport.Read<String>(sqlDataReader, "name"),
                            };
                        }).ToList<DatabaseBase>();

            if(DatabaseBases.Count != 0)
                CurrentDataBase = DatabaseBases[0];
        }

        public bool CreateDevice()
        {
            String currentPath = this.GetType().Assembly.Location;

            String folderPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));

            DirectoryInfo directoryInfo = null;
            if (!Directory.Exists($"{folderPath}\\BackupFiles\\{CurrentDataBase.Name}"))
            {
                directoryInfo =  Directory.CreateDirectory($"{folderPath}\\BackupFiles\\{CurrentDataBase.Name}");
            }

            if (directoryInfo == null)
            {
                QueryStrings.CurrentPathDevice = $"{folderPath}\\BackupFiles\\{CurrentDataBase.Name}\\{CurrentDataBase.Name}.bak";
            }
            else
            {
                QueryStrings.CurrentPathDevice = $"{directoryInfo.FullName}\\{CurrentDataBase.Name}.bak";
            }

            IEnumerable<Boolean> result =  ExecuteQuery<Boolean>.Execute(ConnectionInfo, QueryStrings.CreateDevice, (sqlDataReader)=> {
                                            return SqlSupport.Read<Boolean>(sqlDataReader, "");
                                        });

            this.CurrentDataBase = _currentDB;

            return result.FirstOrDefault();
        }

        public void BackupFullDB()
        {
            ExecuteQuery<int>.Execute(ConnectionInfo, QueryStrings.BackupFullDB, null);

            CurrentDataBase = _currentDB;
        }

        public void DelAllBackupBeforeBackupDB()
        {
            //String pathDevice = ExecuteQuery<String>.Execute(ConnectionInfo, QueryStrings.GetDevicePath, (sqlDataReader) =>
            //{
            //    return SqlSupport.Read<String>(sqlDataReader, "physical_name");
            //}).FirstOrDefault();

            //File.Delete(pathDevice);

            ExecuteQuery<int>.ExecuteNonQuery(ConnectionInfo, QueryStrings.BackupDBWithInit);

            CurrentDataBase = _currentDB;
        }

        public void BackupToPosition(int position)
        {
            QueryStrings.RestoreDBToAPosition = position.ToString();

            ExecuteQuery<int>.Execute(ConnectionInfo, QueryStrings.RestoreDBToAPosition, null);
        }

        public bool DeleteBackupByPosition(int position)
        {
            QueryStrings.DeleteBackupByPosition = position.ToString();

            try
            {
                ExecuteQuery<int>.ExecuteNonQuery(ConnectionInfo, QueryStrings.DeleteBackupByPosition);
                CurrentDataBase = _currentDB;
                return true;
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 12)
                {
                    return false;
                }
                return false;
            }
        }

        public bool RestoreDBToPosition(int position)
        {
            QueryStrings.RestoreDBToAPosition = position.ToString();
            try
            {
                ExecuteQuery<int>.ExecuteNonQuery(ConnectionInfo, QueryStrings.RestoreDBToAPosition);
   
                return true;
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 12)
                {
                    return false;
                }
                return false;
            }
        }

        public bool ValidateRestoreDBByTime()
        {
            try
            {
                int result = ExecuteQuery<int>.Execute(ConnectionInfo, QueryStrings.ValidateRestoreDBByTime, (sqlDataReader)=> {

                            return SqlSupport.Read<Int32>(sqlDataReader, "result");
                        }).FirstOrDefault<int>();

                if(result == 0)
                {
                    return false;
                }
                return true;
            }
            catch (SqlException sqlEx)
            {
                return false;
            }
        }

        public bool RestoreBDByTime(DateTime dateTimeRestore)
        {
            QueryStrings.CurrentPathDevice = ExecuteQuery<String>.Execute(ConnectionInfo, QueryStrings.GetDevicePath, (sqlDataReader) =>
            {
                return SqlSupport.Read<String>(sqlDataReader, "physical_name");
            }).FirstOrDefault();


            QueryStrings.ThirdRestoreDBByTime = dateTimeRestore.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                ExecuteQuery<int>.ExecuteNonQuery(ConnectionInfo, QueryStrings.FirstRestoreDbByTime);
                ExecuteQuery<int>.Execute(ConnectionInfo, QueryStrings.SecondRestoreDBByTime, null);
                ExecuteQuery<int>.ExecuteNonQuery(ConnectionInfo, QueryStrings.ThirdRestoreDBByTime);
                ExecuteQuery<int>.ExecuteNonQuery(ConnectionInfo, QueryStrings.LastRestoreDBByTime);

                return true;
            }
            catch (SqlException sqlEx)
            {
                return false;
            }
        }

        #region Support Function

        private IEnumerable<PositionBackupInfo> GetAllPositionBackupVersions()
        {
            return ExecuteQuery<PositionBackupInfo>.Execute(ConnectionInfo, QueryStrings.GetAllPositionOfBackupVersions,
                        (sqlDataReader) =>
                        {
                            return new PositionBackupInfo()
                            {
                                Position = SqlSupport.Read<Int32>(sqlDataReader, "position"),
                                Description = SqlSupport.Read<String>(sqlDataReader, "description"),
                                BackupDateTime = SqlSupport.Read<DateTime>(sqlDataReader, "backup_start_date"),
                                UserBackup = SqlSupport.Read<String>(sqlDataReader, "user_name"),
                            };
                        }
                      );
        }

        private bool CurrentDBHadDevice()
        {
            IEnumerable<String> devicesname = ExecuteQuery<String>.Execute(ConnectionInfo, QueryStrings.GetAllDeviceName
                                                    , (sqlDataReader) =>
                                                    {
                                                        return SqlSupport.Read<String>(sqlDataReader, "name");
                                                    });

            return devicesname.Where(x => x.Contains(CurrentDataBase.Name)).Count() > 0;
        }

        private string GetCurrentDeviceOfDB()
        {
            IEnumerable<String> devicesname = ExecuteQuery<String>.Execute(ConnectionInfo, QueryStrings.GetAllDeviceNameByDBName
                                                   , (sqlDataReader) =>
                                                   {
                                                       return SqlSupport.Read<String>(sqlDataReader, "logical_device_name");
                                                   });
            return devicesname.FirstOrDefault();
        }

        #endregion

        #region Virtual function
        public virtual void DatabaseBaseChanged(List<DatabaseBase> args)
        {
            if (OnListDatabaseBaseChanged != null)
                OnListDatabaseBaseChanged(args);
               
        }

        public virtual void CurrentDatabaseHadChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos = null, string deviceName = null)
        {
            if (OnCurrentDatabaseChanged != null)
            {
                if(positionBackupInfos == null)
                {
                    positionBackupInfos = GetAllPositionBackupVersions().ToList<PositionBackupInfo>();

                    bool hadDevice = CurrentDBHadDevice();

                    if (!hadDevice && positionBackupInfos.Count != 0) // name of device is not default
                    {
                        DeviceName = GetCurrentDeviceOfDB();
                        QueryStrings.CurrentDevice = DeviceName;
                    }
                    else if(hadDevice)
                    {
                        DeviceName = QueryStrings.CurrentDevice;
                    }
                    else if(!hadDevice)
                    {
                        DeviceName = null;
                    }
                }
                OnCurrentDatabaseChanged(currentDB, positionBackupInfos, DeviceName);
            }
        }
        #endregion
    }
}
