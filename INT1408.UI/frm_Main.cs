using INT14078.App;
using INT14078.App.Common;
using INT14078.App.Core;
using INT1408.Shared.ErrorHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INT1408.UI
{
    public partial class frm_Main : Form
    {
        private BK bk;

        public frm_Main()
        {
            InitializeComponent();

            dtp_DateRestore.CustomFormat = "dd-MM-yyyy";
            dtp_TimeRestore.CustomFormat = "HH:mm:ss";

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
            bk = new BK(new ConnectionInfo(server, user, password)
                , Bk_OnListDatabaseBaseChanged
                , Bk_OnCurrentDatabaseChanged);
        }

        private void Bk_OnCurrentDatabaseChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos, string deviceName)
        {
            if(!String.IsNullOrEmpty(deviceName)) //had device
            {
                btn_CreateDevice.Enabled = false;
                btn_Backup.Enabled = true;
            }
            else
            {
                btn_CreateDevice.Enabled = true;
                btn_Backup.Enabled = false;
            }

            //setup listview
            lsv_BackupVersions.Items.Clear();
            lsv_BackupVersions.View = View.Details;
            lsv_BackupVersions.OwnerDraw = true;

            lbl_BackupCount.Text = positionBackupInfos.Count.ToString();

            foreach (var item in positionBackupInfos)
            {
                ListViewItem row = new ListViewItem(new string[]{item.Position.ToString(), item.Description, item.BackupDateTime.ToString("MM/dd/yyyy HH:mm:ss"), item.UserBackup});
                
                lsv_BackupVersions.Items.Add(row);
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

            bk.CurrentDataBase = new DatabaseBase()
            {
                ID = int.Parse(btn_clicked.Tag.ToString()),
                Name = btn_clicked.Text.ToString()
            }; ;
        }

        private void InvokeUI(Action action)
        {
            if (!this.IsDisposed)
            {
                try
                {
                    this.Invoke(action);
                }
                catch (Exception)
                {

                    throw;
                }
            }
                
        }

        private void uc_login_Load(object sender, EventArgs e)
        {

        }

        #region Support Function


        #endregion

        private void lsv_BackupVersions_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Lime, e.Bounds);
            e.DrawText();
        }

        private void lsv_BackupVersions_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lbl_BackupCount_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_CreateDevice_Click(object sender, EventArgs e)
        {
            bool isSuccess = bk.CreateDevice();

            if (isSuccess)
            {
                MessageBox.Show("Device had created!");
            }
            else
            {
                MessageBox.Show("Can not create device.");
            }
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            if (chk_DelAllBeforeBackup.Checked)
            {
                bk.DelAllBackupBeforeBackupDB();
            }
            else
            {
                bk.BackupFullDB();
            }
        }

        private void cmsi_Delete_Click(object sender, EventArgs e)
        {
            if(lsv_BackupVersions.SelectedItems.Count != 0)
            {
                ListViewItem item = lsv_BackupVersions.SelectedItems[0];
                string position = item.SubItems[0].Text;

                DialogResult isDelete =  MessageBox.Show("Bạn có chắc muốn xóa bản backup này không?", "XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (isDelete == DialogResult.Yes)
                {
                    bool deleteSuccess = bk.DeleteBackupByPosition(int.Parse(position));
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản backup!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            if (lsv_BackupVersions.SelectedItems.Count != 0)
            {
                ListViewItem item = lsv_BackupVersions.SelectedItems[0];
                string position = item.SubItems[0].Text;

                bool isSuccess = bk.RestoreDBToPosition(int.Parse(position));

                if (isSuccess)
                {
                    MessageBox.Show("Phục hồi thành công ");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản backup!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_RestoreByTime_Click(object sender, EventArgs e)
        {
            if (lsv_BackupVersions.Items.Count != 0)
            {
                ListViewItem item = lsv_BackupVersions.Items[0];
                string position = item.SubItems[0].Text;
                DateTime dateTimeFullBK = DateTime.Parse(item.SubItems[2].Text);
                DateTime dateTimeNow = DateTime.Now;
    
                DateTime timeEnter = DateTime.ParseExact(dtp_TimeRestore.Text
                                            , "HH:mm:ss"
                                            , CultureInfo.InvariantCulture);

                DateTime dateEnter = DateTime.ParseExact(dtp_DateRestore.Text
                                            , "dd-MM-yyyy"
                                            , CultureInfo.InvariantCulture);

                DateTime dateTimeEnter = new DateTime(dateEnter.Year, dateEnter.Month, dateEnter.Day, timeEnter.Hour, timeEnter.Minute, timeEnter.Second);

                if (dateTimeEnter < dateTimeFullBK)
                {
                    MessageBox.Show("Thời gian phục hồi phải sau thời gian fullbackup đó.");
                    return;
                }
                else if(dateTimeEnter > DateTime.Now)
                {
                    MessageBox.Show("Thời gian phục hồi phải trước thời gian hiện tai.");
                    return;
                }
                else
                {
                    if (bk.ValidateRestoreDBByTime())
                    {
                        bool isSuccess = bk.RestoreBDByTime(dateTimeEnter);
                        if (isSuccess)
                        {
                            MessageBox.Show("Phục hồi thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không thể phục hồi do lỗi nào đó.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("RECOVERY MODE phải là FULL.");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng backup database!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
