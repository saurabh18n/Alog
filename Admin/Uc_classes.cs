using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AManager
{
    public partial class Uc_classes : UserControl
    {
        public Uc_classes()
        {
            InitializeComponent();
        }

        private void Uc_classes_Load(object sender, EventArgs e)
        {
            populate_GV_classes();
            populateGVTeachers();
        }


        private void populate_GV_classes()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                {
                    using (SqlCommand command = new SqlCommand("sp_get_classes_ex", myConn))
                    {
                        try
                        {
                            myConn.Open();
                            dt.Load(command.ExecuteReader());
                            GV_classes.DataSource = dt;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("SQL Error" + ex.Message);
                        }
                        
                    }
                }
            }


        }

        private void btm_add_Click(object sender, EventArgs e)
        {
            showdialoge("", "", 0, "Add",0);
        }

        private void btm_delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("sp_delete_class", myConn))
                {
                    DataRow dr = ((DataRowView)GV_classes.SelectedRows[0].DataBoundItem).Row;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@classId", (int)dr["class_id"]);
                    command.Parameters.Add("@status", SqlDbType.TinyInt).Direction = ParameterDirection.Output;
                    try
                    {
                        myConn.Open();
                        command.ExecuteNonQuery();
                        if((byte)command.Parameters["@status"].Value == 0)
                        {
                            refrshGVclasses();
                            MessageBox.Show("Class Deleted Successfully");
                        }else if((byte)command.Parameters["@status"].Value == 1)
                        {
                            MessageBox.Show("Class is not empty. Please transfer students first");
                        }

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Sql Error" + ex.Message);
                    }
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            if (GV_classes.SelectedRows.Count == 1)
            {
                DataRow dr = ((DataRowView)GV_classes.SelectedRows[0].DataBoundItem).Row;
                showdialoge((string)dr["class_class"], dr["class_floor"].ToString(), (int)dr["t_id"], "Update", (int)dr["class_id"]);
            }
            else
            {
                MessageBox.Show("Please Select a class first");
            }


        }

        private void showdialoge(string classname,string floor,int teacher,string type, int classId)
        {
            diag_editClass diag = new diag_editClass();
            diag.StartPosition = FormStartPosition.CenterScreen;
            diag.populateCbTeacher();
            diag.Text = type;
            diag.btn_Update.Text = type;
            diag.text_class.Text = classname;
            diag.text_floor.Text = floor;
            diag.CB_teacher.SelectedValue = teacher;
            diag.classId = classId;
            diag.ShowDialog();
            refrshGVclasses();
        }

        private void refrshGVclasses()
        {
            populate_GV_classes();
        }

        

        private void populateGVTeachers()
        {
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("sp_get_teachers_ex", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            myConn.Open();
                            dt.Load(command.ExecuteReader());
                            GV_teachers.DataSource = dt;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Sql Error" + ex.Message);
                        }
                    }
                }
            }
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            populateGVTeachers();
        }

        private void Btn_teacherUpdate_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)GV_teachers.SelectedRows[0].DataBoundItem).Row;

            showTeacherDiag((int)dr["t_id"], (string)dr["t_name"], (bool)dr["t_active"], "Update");
        }

        private void showTeacherDiag(int teacherId,string teacherName,bool isActive,string type)
        {
            using (diag_editTeacher diag = new diag_editTeacher())
            {
                diag.StartPosition = FormStartPosition.CenterScreen;
                diag.Text = type;
                diag.TeacherId = teacherId;
                diag.btn_Update.Text = type;
                diag.text_teacherName.Text = teacherName;
                diag.CB_teacherActive.SelectedIndex = isActive ? 1 : 0;
                diag.ShowDialog();
            }
            populateGVTeachers();
        }

        private void Btn_teacherAdd_Click(object sender, EventArgs e)
        {
            showTeacherDiag(0, "", true, "Add");
        }
    }
}
