using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AManager
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand("SELECT user_fullname,user_isadmin FROM table_user_accounts WHERE user_name = '"+textUsername.Text+"' AND user_password = '"+ textPassword.Text+"' AND user_active = 1", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    userInfo.userName = Convert.ToString(reader["user_fullname"]);
                    userInfo.isAdmin = Convert.ToBoolean(reader["user_isadmin"]);
                    
                }
                else
                {
                    MessageBox.Show("User Not Found/ User Name Password Wrong");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            if (!(userInfo.userName.Length == 0))
            {
                this.Close();
            }
            
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            checkSetup();
        }

        private void checkSetup()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!(configFile.ConnectionStrings.ConnectionStrings.Count > 2))
            {
                Form prompt = new Form();
                prompt.Width = 500;
                prompt.Height = 500;
                prompt.Text = "Configure SQL Server";
                prompt.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                Label l1 = new Label() { Text = "SQL Host Name", Left = 50, Top = 30, };                
                TextBox serverName = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 100 };
                confirmation.Click += (sender, e) => {
                    bool successflag = false;
                    string constring =  "Data Source = " + serverName.Text + "; Initial Catalog = amDB; Integrated Security = True";
                    prompt.UseWaitCursor = true;
                    try
                    {
                        using (SqlConnection myConn = new SqlConnection(constring))
                        {
                            myConn.Open();
                            successflag = true;
                        }

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);                        
                    }
                    if (successflag)
                    {                      
                  
                        ConnectionStringSettings conSet = new ConnectionStringSettings();
                        conSet.Name = "AManager.Properties.Settings.TestConn";
                        conSet.ProviderName = "System.Data.SqlClient";
                        conSet.ConnectionString = constring;
                        //=================================================
                        
                        var conSetting = configFile.ConnectionStrings.ConnectionStrings;                        
                        conSetting["AManager.Properties.Settings.connection"].ConnectionString = constring;
                        conSetting.Add(conSet);
                        configFile.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection(configFile.ConnectionStrings.SectionInformation.Name);
                        //=========================================================================================
                        prompt.UseWaitCursor = true;
                        Properties.Settings.Default.Reload();
                        MessageBox.Show("Configuration success " + Properties.Settings.Default.connection);
                        prompt.Close();
                    }
                    else
                    {
                        prompt.UseWaitCursor = true;
                        MessageBox.Show("Configuration Error Please try again");
                    }                     
                };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(serverName);
                prompt.Controls.Add(l1);
                prompt.ShowDialog();
            }
            
        }
    }
}
