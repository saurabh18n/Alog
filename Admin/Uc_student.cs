//DB table terminal updates u_type 1 == Add Student,2 = Delete Student,3 Update student


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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace AManager
{
    public partial class Uc_student : UserControl
    {
        bool isadmin = userInfo.isAdmin;
        DataTable student_table = new DataTable();
        DataTable student_table_filtered = new DataTable();
        public Uc_student()
        {
            InitializeComponent();            
        }

        private void Uc_student_Load(object sender, EventArgs e)
        {
            this.datePicker_DoB.MaxDate = DateTime.Now.Date;
            validateRole();
            PupulateClassListBox();
            PopulateStudentTable();
            this.gv_student.SelectionChanged += new System.EventHandler(this.Gv_student_SelectionChanged);
            this.gv_student.DataBindingComplete += Gv_student_DataBindingComplete;
        }
        
        private void Gv_student_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) //Clear Selection of grid on startup
        {
            this.gv_student.ClearSelection();
        }

        private void PopulateStudentTable() //Fetch data and populate student table
        {
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("sp_get_students_list", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        student_table.Rows.Clear();
                        myConn.Open();
                        student_table.Load(command.ExecuteReader());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }

                    if (student_table.Rows.Count > 0)
                    {
                        gv_student.DataSource = student_table;
                        gv_student.CurrentCell.Selected = false;
                        filterDatatable();
                    }
                }
            }
        }

        private void PupulateClassListBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn() { ColumnName = "class_id", ReadOnly = false });
            dt.Columns.Add(new DataColumn() { ColumnName = "class_class", ReadOnly = false });
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("sp_get_classes", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        myConn.Open();
                        dt.Load(command.ExecuteReader());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                    finally
                    {
                        myConn.Close();
                    }
                    if (dt.Rows.Count > 1)
                    {
                        DataTable updateClassDropDownDt = new DataTable();
                        updateClassDropDownDt = dt.Copy();
                        DataRow dr = dt.NewRow();
                        dr["class_id"] = 0;
                        dr["class_class"] = "All";
                        dt.Rows.InsertAt(dr, 0);
                        cb_class.ValueMember = "class_id";
                        cb_class.DisplayMember = "class_class";
                        cb_class.DataSource = dt;

                        DataRow dr1 = updateClassDropDownDt.NewRow();
                        dr1["class_id"] = 0;
                        dr1["class_class"] = "Select Class";
                        updateClassDropDownDt.Rows.InsertAt(dr1,0);
                        cb_classSelect.DataSource = updateClassDropDownDt;
                        cb_classSelect.ValueMember = "class_id";
                        cb_classSelect.DisplayMember = "class_class";
                    }

                }

            }                
        } // Populate Classlist Combo box

        private void text_studentName_TextChanged(object sender, EventArgs e)
        {
            filterDatatable();
        }

        private void cb_class_SelectionChangeCommited(object sender, EventArgs e)
        {
           filterDatatable();
        }

        private void text_mobile_TextChanged(object sender, EventArgs e)
        {
            filterDatatable();
        }

        private void filterDatatable()
        {
            this.gv_student.SelectionChanged -= new System.EventHandler(this.Gv_student_SelectionChanged);
            if (cb_class.SelectedIndex == 0)
            {
                student_table.DefaultView.RowFilter = "(s_fname + s_lname Like '*" + text_studentName.Text + "*') AND s_parentmobile LIKE '*" + text_mobile.Text + "*'";
            }
            else
            {
                student_table.DefaultView.RowFilter = "(s_fname + s_lname Like '*" + text_studentName.Text + "*') AND s_parentmobile LIKE '*" + text_mobile.Text + "*' AND s_class = " + cb_class.SelectedValue;

            }
            gv_student.DataSource = student_table;
            gv_student.ClearSelection();
            this.gv_student.SelectionChanged += new System.EventHandler(this.Gv_student_SelectionChanged);
        }

        private void Gv_student_SelectionChanged(object sender, EventArgs e)
        {
            if (gv_student.Focused)
            {
                if (gv_student.SelectedRows.Count > 1)
                {
                    text_FirstName.Enabled = isadmin && false;
                    text_FirstName.Text = "";
                    text_LastName.Enabled = isadmin && false;
                    text_LastName.Text = "";
                    cb_classSelect.Enabled = isadmin && true;
                    cb_classSelect.SelectedIndex = 0;
                    text_ParentMobile.Enabled = isadmin && false;
                    text_ParentMobile.Text = "";
                    text_Address.Enabled = isadmin && false;
                    text_Address.Text = "";
                    datePicker_DoB.Enabled = isadmin && false;
                    datePicker_DoB.Value = new DateTime(2000,1,1).Date;
                    text_homePhone.Enabled = isadmin && false;
                    text_homePhone.Text = "";
                    btn_UpdateDetails.Enabled = isadmin && true;
                    btn_addNew.Enabled = isadmin && false;
                    text_parentName.Enabled = isadmin && false;
                    text_parentName.Text = "";

                }
                else if (gv_student.SelectedRows.Count == 1)
                {
                    text_FirstName.Enabled = isadmin && true;
                    text_LastName.Enabled = isadmin && true;
                    cb_classSelect.Enabled = isadmin && true;
                    text_ParentMobile.Enabled = isadmin && true;
                    text_Address.Enabled = isadmin && true;
                    btn_UpdateDetails.Enabled = isadmin && true;
                    datePicker_DoB.Enabled = isadmin && true;
                    text_homePhone.Enabled = isadmin && true;
                    btn_addNew.Enabled = isadmin && false;
                    text_parentName.Enabled = isadmin && true;
                    DataRowView row = ((DataRowView)gv_student.SelectedRows[0].DataBoundItem);
                    lavel_idonMachine.Text = row["s_idonMachine"].ToString();
                    text_FirstName.Text = (string)row[0];
                    text_LastName.Text = (string)row[1];
                    datePicker_DoB.Value = Convert.ToDateTime(row[2]);
                    cb_classSelect.SelectedValue = Convert.ToInt16(row[3]);
                    text_ParentMobile.Text = ((string)row["s_parentmobile"]).Replace("+972","");
                    text_parentName.Text = (string)row["s_parentname"];
                    text_homePhone.Text = ((string)row["s_homephone"]).Replace("+972","");
                    text_Address.Text = (string)row["s_address"];
                }
                else
                {
                    text_FirstName.Enabled = false;
                    text_LastName.Enabled = false;
                    cb_classSelect.Enabled = false;
                    text_ParentMobile.Enabled = false;
                    text_Address.Enabled = false;
                    btn_UpdateDetails.Enabled = false;
                    datePicker_DoB.Enabled = false;
                    text_homePhone.Enabled = false;
                } 
            }
        }

        private void Btn_reset_Click(object sender, EventArgs e)
        {
            text_FirstName.Enabled = isadmin && true;
            text_FirstName.Text = "";
            text_LastName.Enabled = isadmin && true;
            text_LastName.Text = "";
            cb_classSelect.Enabled = isadmin && true;
            cb_classSelect.SelectedIndex = 0;
            text_ParentMobile.Enabled = isadmin && true;
            text_ParentMobile.Text = "";
            text_parentName.Enabled = isadmin && true;
            text_parentName.Text = "";
            text_Address.Enabled = isadmin && true;
            text_Address.Text = "";
            datePicker_DoB.Enabled = isadmin && true;
            datePicker_DoB.Value = new DateTime(2000, 1, 1); 
            text_homePhone.Enabled = isadmin && true;
            text_homePhone.Text = "";
            btn_UpdateDetails.Enabled = isadmin && true;
            btn_addNew.Enabled = isadmin && true;
            lavel_idonMachine.Visible = isadmin && true;
            lavel_idonMachine.Text = "";
            gv_student.ClearSelection();
        }

        private void Btn_UpdateDetails_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                if (gv_student.SelectedRows.Count > 1)
                {
                    DataTable dt = new DataTable();
                    DataColumn dc = new DataColumn("s_id");
                    dt.Columns.Add(dc);
                    foreach (DataGridViewRow row in gv_student.SelectedRows)
                    {
                        DataRow dtRow = dt.NewRow();
                        dtRow[0] = (int)(((DataRowView)row.DataBoundItem).Row["s_idonmachine"]);
                        dt.Rows.Add(dtRow);
                    }
                    SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection);
                    SqlCommand command = new SqlCommand("sp_update_student_class", myConn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@class", cb_classSelect.SelectedValue);
                    command.Parameters.AddWithValue("@studentIdTab", dt).TypeName = "students_id";
                    try
                    {
                        myConn.Open();
                        command.ExecuteNonQuery();
                        PopulateStudentTable();
                        Btn_reset_Click(null, null);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        command.Dispose();
                        myConn.Close();
                    }


                }
                else if (gv_student.SelectedRows.Count == 1)
                {
                    string status = string.Empty;
                    DataRow row = ((DataRowView)gv_student.SelectedRows[0].DataBoundItem).Row;
                    //row["s_id"].ToString();
                    SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection);
                    SqlCommand command = new SqlCommand("sp_update_student", myConn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstName", text_FirstName.Text);
                    command.Parameters.AddWithValue("@lastName", text_LastName.Text);
                    command.Parameters.Add("@dob", SqlDbType.Date).Value = datePicker_DoB.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    command.Parameters.AddWithValue("@parentName", text_parentName.Text);
                    command.Parameters.AddWithValue("@mobile", "+972" + text_ParentMobile.Text.Trim());
                    command.Parameters.AddWithValue("@homePhone", "+972" + text_homePhone.Text.Trim());
                    command.Parameters.AddWithValue("@address", text_Address.Text);
                    command.Parameters.AddWithValue("@class", cb_classSelect.SelectedValue);
                    command.Parameters.AddWithValue("@studentid", row["s_idonmachine"]);
                    command.Parameters.Add("@status", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                    try
                    {
                        myConn.Open();
                        int rowsupdated = command.ExecuteNonQuery();
                        status = (string)command.Parameters["@status"].Value;
                        if(status == "OK")
                        {
                            MessageBox.Show("Updated Successfully");
                        }
                        else
                        {
                            MessageBox.Show("DB Error " + status);
                        }
                        
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        command.Dispose();
                        myConn.Close();
                    }
                } 
            }
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            int studentId = 0;
            string ErrorMessage = string.Empty;
            if (validateInput())
            {
                SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection);
                SqlCommand command = new SqlCommand("sp_add_student", myConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", text_FirstName.Text);
                command.Parameters.AddWithValue("@lastName", text_LastName.Text);
                command.Parameters.Add("@dob", SqlDbType.Date).Value = datePicker_DoB.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("@parentName", text_parentName.Text);
                command.Parameters.AddWithValue("@mobile", "+972" + text_ParentMobile.Text.Trim());
                command.Parameters.AddWithValue("@homePhone", text_homePhone.Text);
                command.Parameters.AddWithValue("@address", text_Address.Text);
                command.Parameters.AddWithValue("@class", cb_classSelect.SelectedValue);
                command.Parameters.Add("@studentid", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.Add("@message", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                try
                {
                    myConn.Open();
                    int rowsupdated = command.ExecuteNonQuery();
                    studentId = (int)command.Parameters["@studentid"].Value;
                    ErrorMessage = (string)command.Parameters["@message"].Value;
                    if(studentId == 0)
                    {
                        MessageBox.Show("Some unknown Error");
                    }else if(studentId > 0 && studentId < 1001)
                    {
                        MessageBox.Show("Student Saved with id " + studentId.ToString() + " Please enroll finger print for student");
                    }
                    else if (studentId == 1001)
                    {
                        MessageBox.Show("100% Capecity 1000 user in Use");
                    }

                    else if (studentId == 1002)
                    {
                        MessageBox.Show("DB Error " + ErrorMessage);
                    }

                    PopulateStudentTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                finally
                {
                    myConn.Close();
                } 
            }
            }

        private void btn_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Students.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //Excel.Range RA = xlWorkSheet.Range["C:C"];
                // Testing
                xlWorkSheet.Cells[1, 1] = "Student Id";
                xlWorkSheet.Cells[1, 2] = "Name";
                xlWorkSheet.Cells[1, 3] = "Date of Birth";
                xlWorkSheet.Cells[1, 4] = "Class";
                xlWorkSheet.Cells[1, 5] = "Parent";
                xlWorkSheet.Cells[1, 6] = "Mobile";                
                xlWorkSheet.Cells[1, 7] = "Homephone";                
                xlWorkSheet.Cells[1, 8] = "Address";
                int rowindex = 2;
                foreach (DataGridViewRow Row in gv_student.Rows)
                {
                    DataRow DR = ((DataRowView)Row.DataBoundItem).Row;
                    xlWorkSheet.Cells[rowindex, 1] = DR["s_idonMachine"];
                    xlWorkSheet.Cells[rowindex, 2] = DR["s_fname"] + " " + DR["s_lname"];
                    xlWorkSheet.Cells[rowindex, 3] = ((DateTime)DR["s_dob"]).Date.ToString("dd-MM-yyyy");
                    xlWorkSheet.Cells[rowindex, 4] = DR["class_class"];
                    xlWorkSheet.Cells[rowindex, 5] = DR["s_parentname"];
                    xlWorkSheet.Cells[rowindex, 6] = DR["s_parentmobile"];
                    xlWorkSheet.Cells[rowindex, 7] = DR["s_homephone"];                    
                    xlWorkSheet.Cells[rowindex, 8] = DR["s_address"];
                    rowindex++;
                }
                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);
                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {

            if (gv_student.SelectedRows.Count > 0)
            {
                string status = string.Empty;
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("s_id");
                dt.Columns.Add(dc);
                foreach (DataGridViewRow row in gv_student.SelectedRows)
                {
                    DataRow dtRow = dt.NewRow();
                    dtRow[0] = (int)(((DataRowView)row.DataBoundItem).Row["s_idonMachine"]);
                    dt.Rows.Add(dtRow);
                }
                SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection);
                SqlCommand command = new SqlCommand("sp_delete_student", myConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@studentIdTab", dt).TypeName= "students_id";
                command.Parameters.Add("@status",SqlDbType.NVarChar,400).Direction = ParameterDirection.Output;
                try
                {
                    myConn.Open();
                    command.ExecuteNonQuery();
                    status = (string)command.Parameters["@status"].Value;
                    if (status == "OK")
                    {
                        MessageBox.Show("Deleted Successfully");
                        PopulateStudentTable();
                        Btn_reset_Click(null, null);

                    }
                    else
                    {
                        MessageBox.Show("DB Error " + status);
                    }
                   
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                }
                finally
                {
                    myConn.Close();
                }
            }

        }

        private void validateRole()
        {
            if (!userInfo.isAdmin)
            {
                text_FirstName.Enabled = false;                
                text_LastName.Enabled = false;
                cb_classSelect.Enabled = false;
                text_ParentMobile.Enabled = false;
                text_parentName.Enabled = false;
                text_Address.Enabled = false;
                datePicker_DoB.Enabled = false;
                text_homePhone.Enabled = false;
                btn_UpdateDetails.Enabled = false;
                btn_delete.Enabled = false;
                btn_addNew.Enabled = false;
                btn_reset.Enabled = false;
                btn_import.Enabled = false;
            }
            else
            {

            }

        }

        private bool validateInput()
        {
            bool flag = false;
            if (gv_student.SelectedRows.Count > 1)
            {
                if (!(cb_classSelect.SelectedIndex == 0))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Please select student class");
                    return false;
                }

            }
            else {
                if (text_FirstName.Text.Length > 0 && text_FirstName.Text.All(Char.IsLetter))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Firstname Empty or illigal Charector");
                    return false;
                }

                if (text_LastName.Text.Length > 0 && text_LastName.Text.All(Char.IsLetter))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Last Name Empty or illigal Charector");
                    return false;
                }

                if (text_parentName.Text.Length > 0 && text_parentName.Text.All(c => Char.IsLetter(c) || c == ' '))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Parent Name Name Empty or illigal Charector");
                    return false;
                }

                if (text_ParentMobile.Text.Length > 6 && text_ParentMobile.Text.All(char.IsDigit))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Parent Mobile can only contain digits");
                    return false;
                }

                if (text_homePhone.Text.Length > 6 && text_homePhone.Text.All(char.IsDigit))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Home phone can only contain digits");
                    return false;

                }

                if (datePicker_DoB.Value.Year + 3 < DateTime.Now.Year)
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Student Age can not be less then 3 year");
                    return false;
                }

                if (!(cb_classSelect.SelectedIndex == 0))
                {
                    flag = true;
                }
                else
                {
                    MessageBox.Show("Please select student class");
                    return false;
                } 
            }

            return flag;
        }
    }
}
