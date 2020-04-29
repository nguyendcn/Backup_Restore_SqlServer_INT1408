using INT14078.App;
using INT14078.App.Common;
using INT14078.App.Core;
using INT1408.Shared.ErrorHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INT1408.UI
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();

            Thread thread = new Thread(new ThreadStart(() =>
            {
                TimerAction.AddTimer((args, e) => { InvokeUI(() => { this.lbl_Time.Text = DateTime.Now.ToLongTimeString(); }); }, 1000);
            }));
            thread.Start();

            uc_login.ResponseResultLogin += Uc_login_ResponseResultLogin;

            uc_login.BringToFront();
        }

        private void Uc_login_ResponseResultLogin(string server, string user, string password)
        {
            BK bk = new BK(new ConnectionInfo(server, user, password), Bk_OnListDatabaseBaseChanged);
            bk.OnCurrentDatabaseChanged += Bk_OnCurrentDatabaseChanged;
        }

        private void Bk_OnCurrentDatabaseChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos)
        {
            lsv_BackupVersions.View = View.Details;

            foreach (var property in typeof(PositionBackupInfo).GetProperties())
            {
                lsv_BackupVersions.Columns.Add(property.Name);
            }

            foreach(var item in positionBackupInfos)
            {
                lsv_BackupVersions.Items.AddRange( )
            }
        }

        private void Bk_OnListDatabaseBaseChanged(List<DatabaseBase> databaseBases)
        {
            foreach(DatabaseBase dbInfo in databaseBases)
            {
                Button btn = new Button();
                btn.Text = dbInfo.Name;
                btn.Tag = dbInfo.ID;

                btn.Size = new Size { Width = flp_ListDb.Width - 2, Height= 50};
                btn.Click += Btn_Db_Click;
                flp_ListDb.Controls.Add(btn);
            }
        }

        private void Btn_Db_Click(object sender, EventArgs e)
        {
            Button btn_clicked = sender as Button;

            lbl_DbName.Text = btn_clicked.Text;

            LoadAllBackupVersionByDB();
        }

        private void InvokeUI(Action action)
        {
            this.Invoke(action);
        }

        private void uc_login_Load(object sender, EventArgs e)
        {

        }

        #region Support Function

        public void LoadAllBackupVersionByDB()
        {

        }

        #endregion
    }
}
