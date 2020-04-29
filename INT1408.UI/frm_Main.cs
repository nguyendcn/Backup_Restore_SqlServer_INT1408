﻿using INT14078.App;
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
        private BK bk;

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
            bk = new BK(new ConnectionInfo(server, user, password)
                , Bk_OnListDatabaseBaseChanged
                , Bk_OnCurrentDatabaseChanged);
        }

        private void Bk_OnCurrentDatabaseChanged(DatabaseBase currentDB, List<PositionBackupInfo> positionBackupInfos)
        {
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
    }
}
