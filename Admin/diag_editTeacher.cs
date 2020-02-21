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

namespace AManager
{
    public partial class diag_editTeacher : Form
    {
        public int TeacherId;

        public diag_editTeacher()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (btn_Update.Text == "Add") // Add Routine
            {
                using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                {
                    using (SqlCommand command = new SqlCommand("sp_add_teacher", myConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@teacherName", text_teacherName.Text);
                        command.Parameters.AddWithValue("@teacherIsactive", CB_teacherActive.SelectedIndex == 0 ? false : true);
                        command.Parameters.Add("@status", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        try
                        {
                            myConn.Open();
                            command.ExecuteNonQuery();
                            if ((byte)command.Parameters["@status"].Value == 1)
                            {
                                MessageBox.Show("Teacher Already Exists");
                            }
                            else
                            {
                                MessageBox.Show("Teacher Saved Successfully");
                                this.Dispose();
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("SqlError" + ex.ToString());
                        }
                    }
                }
            }
            else // Update Routine
            {
                using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                {
                    using (SqlCommand command = new SqlCommand("sp_set_teacher", myConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@teacherId", TeacherId);
                        command.Parameters.AddWithValue("@teacherName", text_teacherName.Text);
                        command.Parameters.AddWithValue("@teacherIsactive", CB_teacherActive.SelectedIndex == 0 ? false : true);
                        command.Parameters.Add("@status", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        try
                        {
                            myConn.Open();
                            command.ExecuteNonQuery();
                            if ((byte)command.Parameters["@status"].Value == 1)
                            {
                                MessageBox.Show("SQL Db Error");
                            }
                            else
                            {
                                MessageBox.Show("Teacher Saved Successfully");
                                this.Dispose();
                            }

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("SqlError" + ex.ToString());
                        }

                    }
                }

            }
        }
    }
}