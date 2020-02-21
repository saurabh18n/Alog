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
    public partial class diag_editClass : Form
    {
        List<listItem> list = new List<listItem>();
        public int classId;

        public diag_editClass()
        {
            InitializeComponent();
        }


        public void populateCbTeacher()
        {
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("sp_get_teacher", myConn))
                {
                    try
                    {
                        list.Add(new listItem() { teacher_id = 0, teacher_name = "Select Teacher" });
                        myConn.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                list.Add(new listItem() { teacher_id = dr.GetInt32(0), teacher_name = dr.GetString(1)});
                            }
                            CB_teacher.DataSource = list;
                            CB_teacher.ValueMember = "teacher_id";
                            CB_teacher.DisplayMember = "teacher_name";                            
                        }

                    }
                    catch (SqlException ex)
                    {

                        MessageBox.Show("SQL Error Getting Teachers" + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populateCbTeacher();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if(btn_Update.Text == "Add") // Add Routine
            {
                using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                {
                    using (SqlCommand command = new SqlCommand("sp_add_class", myConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@className", text_class.Text);
                        command.Parameters.AddWithValue("@classFloor", text_floor.Text);
                        command.Parameters.AddWithValue("@classTeacher", CB_teacher.SelectedValue);
                        command.Parameters.Add("@status", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                        try
                        {
                            myConn.Open();
                            command.ExecuteNonQuery();
                            if((byte)command.Parameters["@status"].Value == 1)
                            {
                                MessageBox.Show("Class Already Exists");
                            }
                            else
                            {
                                MessageBox.Show("Class Saved Successfully");
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
                    using (SqlCommand command = new SqlCommand("sp_set_class", myConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@classId", classId);
                        command.Parameters.AddWithValue("@className", text_class.Text);
                        command.Parameters.AddWithValue("@classFloor", text_floor.Text);
                        command.Parameters.AddWithValue("@classTeacher", CB_teacher.SelectedValue);
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
                                MessageBox.Show("Class Saved Successfully");
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
    class listItem
    {
        public int teacher_id { get; set; }
        public string teacher_name { get; set;}
    }
}