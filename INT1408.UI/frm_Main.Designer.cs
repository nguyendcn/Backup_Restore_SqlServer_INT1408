namespace INT1408.UI
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flp_ListDb = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl_WorkControl = new System.Windows.Forms.Panel();
            this.lsv_BackupVersions = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.uc_login = new INT1408.UI.UI.uc_Login();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_DbName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_BackupCount = new System.Windows.Forms.Label();
            this.ckb_DelAllBeforeBackup = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_DateRestore = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeRestore = new System.Windows.Forms.DateTimePicker();
            this.clmn_Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.pnl_WorkControl.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8412198F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.6768F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.323194F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 612);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Time);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 27);
            this.panel1.TabIndex = 1;
            // 
            // lbl_Time
            // 
            this.lbl_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Time.ForeColor = System.Drawing.Color.Teal;
            this.lbl_Time.Location = new System.Drawing.Point(849, 5);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(82, 16);
            this.lbl_Time.TabIndex = 0;
            this.lbl_Time.Text = "HH:MM:SS";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.uc_login);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 573);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.03704F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.027924F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.97208F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(945, 573);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.18743F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.81257F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.09416F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(939, 521);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.flp_ListDb, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.095238F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.90476F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(145, 515);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flp_ListDb
            // 
            this.flp_ListDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_ListDb.Location = new System.Drawing.Point(3, 34);
            this.flp_ListDb.Name = "flp_ListDb";
            this.flp_ListDb.Size = new System.Drawing.Size(139, 478);
            this.flp_ListDb.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(139, 25);
            this.panel4.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::INT1408.UI.Properties.Resources.icons8_database_view_16;
            this.button6.Location = new System.Drawing.Point(4, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(36, 25);
            this.button6.TabIndex = 1;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cơ sở dữ liệu";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(154, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 515);
            this.panel3.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.pnl_WorkControl, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.407767F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.59223F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(782, 515);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // pnl_WorkControl
            // 
            this.pnl_WorkControl.Controls.Add(this.dtp_TimeRestore);
            this.pnl_WorkControl.Controls.Add(this.dtp_DateRestore);
            this.pnl_WorkControl.Controls.Add(this.label5);
            this.pnl_WorkControl.Controls.Add(this.ckb_DelAllBeforeBackup);
            this.pnl_WorkControl.Controls.Add(this.lsv_BackupVersions);
            this.pnl_WorkControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_WorkControl.Location = new System.Drawing.Point(3, 35);
            this.pnl_WorkControl.Name = "pnl_WorkControl";
            this.pnl_WorkControl.Size = new System.Drawing.Size(776, 477);
            this.pnl_WorkControl.TabIndex = 0;
            // 
            // lsv_BackupVersions
            // 
            this.lsv_BackupVersions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_Position,
            this.clmn_Description,
            this.clmn_Date,
            this.clmn_User});
            this.lsv_BackupVersions.Dock = System.Windows.Forms.DockStyle.Top;
            this.lsv_BackupVersions.FullRowSelect = true;
            this.lsv_BackupVersions.GridLines = true;
            this.lsv_BackupVersions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsv_BackupVersions.HideSelection = false;
            this.lsv_BackupVersions.Location = new System.Drawing.Point(0, 0);
            this.lsv_BackupVersions.MultiSelect = false;
            this.lsv_BackupVersions.Name = "lsv_BackupVersions";
            this.lsv_BackupVersions.Size = new System.Drawing.Size(776, 214);
            this.lsv_BackupVersions.TabIndex = 0;
            this.lsv_BackupVersions.UseCompatibleStateImageBehavior = false;
            this.lsv_BackupVersions.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lsv_BackupVersions_DrawColumnHeader);
            this.lsv_BackupVersions.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lsv_BackupVersions_DrawItem);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(939, 40);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::INT1408.UI.Properties.Resources.icons8_data_backup_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sao Lưu";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::INT1408.UI.Properties.Resources.icons8_database_restore_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(115, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Phục Hồi";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::INT1408.UI.Properties.Resources.icons8_alarm_clock_32;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(234, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "Phục hồi theo TG";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::INT1408.UI.Properties.Resources.icons8_save_close_32;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(422, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "Tạo Device";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::INT1408.UI.Properties.Resources.icons8_close_window_32;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(553, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 38);
            this.button5.TabIndex = 4;
            this.button5.Text = "Thoát";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // uc_login
            // 
            this.uc_login.BackColor = System.Drawing.Color.White;
            this.uc_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_login.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_login.Location = new System.Drawing.Point(0, 0);
            this.uc_login.Margin = new System.Windows.Forms.Padding(4);
            this.uc_login.Name = "uc_login";
            this.uc_login.Size = new System.Drawing.Size(945, 573);
            this.uc_login.TabIndex = 1;
            this.uc_login.Load += new System.EventHandler(this.uc_login_Load);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.lbl_DbName);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.lbl_BackupCount);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(776, 26);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database: ";
            // 
            // lbl_DbName
            // 
            this.lbl_DbName.AutoSize = true;
            this.lbl_DbName.Location = new System.Drawing.Point(90, 0);
            this.lbl_DbName.Name = "lbl_DbName";
            this.lbl_DbName.Size = new System.Drawing.Size(71, 18);
            this.lbl_DbName.TabIndex = 1;
            this.lbl_DbName.Text = "db_name";
            this.lbl_DbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "                          ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số bản sao lưu: ";
            // 
            // lbl_BackupCount
            // 
            this.lbl_BackupCount.AutoSize = true;
            this.lbl_BackupCount.Location = new System.Drawing.Point(407, 0);
            this.lbl_BackupCount.Name = "lbl_BackupCount";
            this.lbl_BackupCount.Size = new System.Drawing.Size(126, 18);
            this.lbl_BackupCount.TabIndex = 4;
            this.lbl_BackupCount.Text = "db_backupCount";
            // 
            // ckb_DelAllBeforeBackup
            // 
            this.ckb_DelAllBeforeBackup.AutoSize = true;
            this.ckb_DelAllBeforeBackup.Location = new System.Drawing.Point(182, 242);
            this.ckb_DelAllBeforeBackup.Name = "ckb_DelAllBeforeBackup";
            this.ckb_DelAllBeforeBackup.Size = new System.Drawing.Size(382, 22);
            this.ckb_DelAllBeforeBackup.TabIndex = 1;
            this.ckb_DelAllBeforeBackup.Text = "Xóa tất cả các bản backup trước đó  rồi mới backup";
            this.ckb_DelAllBeforeBackup.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày giờ muốn phục hồi đến ";
            // 
            // dtp_DateRestore
            // 
            this.dtp_DateRestore.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateRestore.Location = new System.Drawing.Point(339, 307);
            this.dtp_DateRestore.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtp_DateRestore.Name = "dtp_DateRestore";
            this.dtp_DateRestore.Size = new System.Drawing.Size(116, 26);
            this.dtp_DateRestore.TabIndex = 3;
            // 
            // dtp_TimeRestore
            // 
            this.dtp_TimeRestore.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_TimeRestore.Location = new System.Drawing.Point(470, 307);
            this.dtp_TimeRestore.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtp_TimeRestore.Name = "dtp_TimeRestore";
            this.dtp_TimeRestore.Size = new System.Drawing.Size(116, 26);
            this.dtp_TimeRestore.TabIndex = 4;
            // 
            // clmn_Position
            // 
            this.clmn_Position.Text = "Version";
            this.clmn_Position.Width = 120;
            // 
            // clmn_Description
            // 
            this.clmn_Description.Text = "Description";
            this.clmn_Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmn_Description.Width = 150;
            // 
            // clmn_Date
            // 
            this.clmn_Date.Text = "Date Backup";
            this.clmn_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmn_Date.Width = 250;
            // 
            // clmn_User
            // 
            this.clmn_User.Text = "User Backup";
            this.clmn_User.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmn_User.Width = 250;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(951, 612);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Main";
            this.Text = "frm_Login";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.pnl_WorkControl.ResumeLayout(false);
            this.pnl_WorkControl.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Panel panel2;
        private UI.uc_Login uc_login;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flp_ListDb;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel pnl_WorkControl;
        private System.Windows.Forms.ListView lsv_BackupVersions;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_DbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_BackupCount;
        private System.Windows.Forms.DateTimePicker dtp_TimeRestore;
        private System.Windows.Forms.DateTimePicker dtp_DateRestore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckb_DelAllBeforeBackup;
        private System.Windows.Forms.ColumnHeader clmn_Position;
        private System.Windows.Forms.ColumnHeader clmn_Description;
        private System.Windows.Forms.ColumnHeader clmn_Date;
        private System.Windows.Forms.ColumnHeader clmn_User;
    }
}