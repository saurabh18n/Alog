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
    public partial class Form1 : Form
    {
        List<listItem> list = new List<listItem>();

        public Form1()
        {
            InitializeComponent();
        }


        private void populate_cbTeacher()
        {
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("get_teacher", myConn))
                {
                    try
                    {
                        myConn.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                list.Add(new listItem() { teacher_id = dr.GetInt32(0), teacher_name = dr.GetString(1) });
                            }                            
                            CB_teacher.ValueMember = "teacher_id";
                            CB_teacher.DisplayMember = "teacher_name";
                            CB_teacher.DataSource = list;
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
            populate_cbTeacher();
        }
    }
    class listItem
    {
        public int teacher_id;
        public string teacher_name;
    }
}