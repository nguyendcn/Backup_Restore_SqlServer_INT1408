using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INT1408.Shared.ErrorHandler;
using System.Data.SqlClient;
using System.Data.Common;

namespace INT1408.UI.UI
{
    public partial class uc_Login : UserControl
    {
        public delegate void ResultLogin(string server, string user, string password);

        public event ResultLogin ResponseResultLogin;

        public uc_Login()
        {
            InitializeComponent();

            SetupFirstStartShowControl();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            bool isPassing = false;

            isPassing = ValidateEmptyInput(new TextBox[] { txt_ServerName, txt_username, txt_password }
                                                , new Label[] { lbl_Err_server, lbl_Err_username, lbl_Err_password });

            if (isPassing)
                isPassing = ValidateLogin();

            if (isPassing)
            {
                OnResponseLoginResult(txt_ServerName.Text, txt_username.Text, txt_password.Text);

                this.Dispose();
            }
        }

        #region Outside

        public virtual void OnResponseLoginResult(string server, string user, string password)
        {
            ResponseResultLogin?.Invoke(server, user, password);
        }

        #endregion

        #region Function support

        private bool ValidateEmptyInput(TextBox[] inputs, Label[] errors)
        {
            bool isPassing = true;

            for(int i = 0; i < inputs.Length; i++)
            {
                if(inputs[i].Text.Trim().Length == 0)
                {
                    ErrorHandler.ShowError(errors[i], "Ox0001");
                    isPassing = false;
                }
            }

            return isPassing;
        }

        private bool ValidateLogin()
        {
            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.DataSource = txt_ServerName.Text;
            connBuilder.UserID = txt_username.Text;
            connBuilder.Password = txt_password.Text;

            string a = connBuilder.ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connBuilder.ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                if(sqlEx.Number == 53) // server name fail
                {
                    ErrorHandler.ShowError(lbl_Err_server, "OxDB02");
                }
                else if(sqlEx.Number == 18456) // login user fail
                {
                    ErrorHandler.ShowError(lbl_Err_summary, "OxDB03");
                }

                return false;
            }
            catch(Exception ex)
            {
                ErrorHandler.ShowError(lbl_Err_summary, "OxDB01");
                return false;
            }
            return true;
        }

        private void SetupFirstStartShowControl()
        {
            this.lbl_Err_password.Text = lbl_Err_server.Text = lbl_Err_summary.Text = lbl_Err_username.Text = String.Empty;
        }

        #endregion
    }
}
