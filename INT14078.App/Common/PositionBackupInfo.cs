using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT14078.App.Common
{
    public class PositionBackupInfo
    {
        public int Position { get; set; }

        public string Name { get; set; }

        public DateTime BackupDateTime { get; set; }

        public string UserBackup { get; set; }
    }
}
