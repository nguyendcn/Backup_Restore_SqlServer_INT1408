using INT14078.App.Common;
using INT14078.App.Core;
using INT1408.Shared.SqlSupport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    CurrentDatabaseHadChanged(value, null);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        #region Event
        public delegate void ListDatabaseBaseChanged(List<DatabaseBase> databaseBases);

        public event ListDatabaseBaseChanged OnListDatabaseBaseChanged;

        public delegate void CurrentDatabaseChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos);

        public event CurrentDatabaseChanged OnCurrentDatabaseChanged;
        #endregion

        public BK(ConnectionInfo connectionInfo, ListDatabaseBaseChanged changed)
        {
            ConnectionInfo = connectionInfo;
            this.OnListDatabaseBaseChanged = changed;

            DatabaseBases = ExecuteQuery<DatabaseBase>.Execute(connectionInfo, QueryStrings.GetAllDatabaseName, 
                            (sqlDataReader) =>
                            {
                                return new DatabaseBase()
                                {
                                    ID = SqlSupport.Read<Int32>(sqlDataReader, "database_id"),
                                    Name = SqlSupport.Read<String>(sqlDataReader, "name"),
                            };
                        }).ToList<DatabaseBase>();
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
                                Name = SqlSupport.Read<String>(sqlDataReader, "name"),
                                BackupDateTime = SqlSupport.Read<DateTime>(sqlDataReader, "backup_start_date"),
                                UserBackup = SqlSupport.Read<String>(sqlDataReader, "user_name"),
                            };
                        }
                      );
        }

        #endregion

        #region Virtual function
        public virtual void DatabaseBaseChanged(List<DatabaseBase> args)
        {
            if (OnListDatabaseBaseChanged != null)
                OnListDatabaseBaseChanged(args);
               
        }

        public virtual void CurrentDatabaseHadChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos)
        {
            if (OnCurrentDatabaseChanged != null)
            {
                if(positionBackupInfos == null)
                {
                    positionBackupInfos = GetAllPositionBackupVersions().ToList<PositionBackupInfo>();
                }
                OnCurrentDatabaseChanged(currentDB, positionBackupInfos);
            }
        }
        #endregion
    }
}
