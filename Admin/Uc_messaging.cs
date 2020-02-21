using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AManager
{
    public partial class Ucmessaging : UserControl
    {
        DataTable dt_studentTable = new DataTable();
        DataTable dt_studentSelected = new DataTable();
        DataTable dt_scheduleMessage = new DataTable();
        List<Part> TempletParts = new List<Part>();
        bool scheduledStatus;
        public class Part : IEquatable<Part>, IComparable<Part>
        {
            public string Name { get; set; }

            public int index { get; set; }

            public int dtIndex { get; set; }

            public bool isBound { get; set; }

            public int CompareTo(Part comparePart)
            {
                if (comparePart == null)
                    return 1;

                else
                    return this.index.CompareTo(comparePart.index);
            }

            public bool Equals(Part other)
            {
                if (other == null) return false;
                return Name.Equals(other.Name);
            }
        }

        public class tempFields
        {
             public string text { get; set; }
             public string value { get; set;}
        }

        public List<tempFields> tmpFieldList;

        public Ucmessaging()
        {
            InitializeComponent();
            #region Initialise dt_studentSelected
            dt_studentSelected.Columns.Add("st_id");
            dt_studentSelected.Columns.Add("st_name");
            dt_studentSelected.Columns.Add("st_class");
            dt_studentSelected.Columns.Add("st_parentmobile");
            dt_studentSelected.Columns.Add("st_parentname");
            dt_studentSelected.PrimaryKey =new DataColumn[] { dt_studentSelected.Columns["st_id"] };
            #endregion
            #region Initialise dt_messages
            dt_scheduleMessage.Columns.Add("stdt_name");
            dt_scheduleMessage.Columns.Add("stdt_mobile");
            dt_scheduleMessage.Columns.Add("stdt_message");
            #endregion

        }

        private void Uc_messaging_Load(object sender, EventArgs e)
        {
            pupulateStateData();
            PupulateClassListBox();
            pupulateStudentTableData();
            populateTempFieldCB();
            if (!userInfo.isAdmin) { tabControl1.TabPages.Remove(tabPage2); };
            DTP_sendBefore.Value = DateTime.Now + Properties.Settings.Default.sms_defaultValidFor.TimeOfDay;
            DTP_sendBefore.MinDate = DateTime.Now.Date;
            DTP_scheduleat.MinDate = DateTime.Now.Date;
        }

        private void pupulateStateData()
        {
            DataSet dt_messages = new DataSet();
            SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand("sp_get_messagestatus", myConn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@fromdate",new DateTime().Date.ToString("yyyy - MM - dd HH: mm:ss"));
            try
            {
                myConn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(dt_messages);
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

            gv_queue.DataSource = dt_messages.Tables[0];
            gv_sent.DataSource = dt_messages.Tables[1];
        }

        private void PupulateClassListBox()
        {
            DataTable dt = new DataTable();
            using(SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection)){
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
                        DataRow dr = dt.NewRow();
                        dr["class_id"] = 0;
                        dr["class_class"] = "All";
                        dt.Rows.InsertAt(dr, 0);
                        cb_classSelect.ValueMember = "class_id";
                        cb_classSelect.DisplayMember = "class_class";
                        cb_classSelect.DataSource = dt;                   
                    }

                }
                    

            }
            
        }

        private void filterDatatable()
        {
            
            if (cb_classSelect.SelectedIndex == 0)
            {
                dt_studentTable.DefaultView.RowFilter = "(s_name Like '*" + text_studentName.Text + "*') AND s_parentmobile LIKE '*" + text_mobile.Text + "*'";
            }
            else
            {
                dt_studentTable.DefaultView.RowFilter = "(s_name Like '*" + text_studentName.Text + "*') AND s_parentmobile LIKE '*" + text_mobile.Text + "*' AND s_class = " + cb_classSelect.SelectedValue;
            }
            gv_student.DataSource = dt_studentTable;
            gv_student.ClearSelection();
        }

        private void pupulateStudentTableData()
        {
            SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand("sp_get_students_list_custom_sms", myConn);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                myConn.Open();
                dt_studentTable.Load(command.ExecuteReader());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
            gv_student.DataSource = dt_studentTable;
            filterDatatable();
        }

        private void Cb_classSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_classSelect.Focused)
            {
                filterDatatable();
            }            
        }

        private void Text_studentName_TextChanged(object sender, EventArgs e)
        {
            if (text_studentName.Focused)
            {
                filterDatatable();
            }
        }

        private void Text_mobile_TextChanged(object sender, EventArgs e)
        {
            if (text_mobile.Focused)
            {
                filterDatatable();
            }
        }

        private void Btn_addtosendlist_Click(object sender, EventArgs e)
        {
            if (gv_student.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow Row in gv_student.SelectedRows)
                {
                    DataRow newRow = dt_studentSelected.NewRow();
                    newRow["st_id"] = (int)((DataRowView)Row.DataBoundItem).Row["s_id"];
                    newRow["st_name"] = (string)((DataRowView)Row.DataBoundItem).Row["s_name"];
                    newRow["st_class"] = ((DataRowView)Row.DataBoundItem).Row["s_class"];
                    newRow["st_parentmobile"] = (string)((DataRowView)Row.DataBoundItem).Row["s_parentmobile"];
                    newRow["st_parentname"] = (string)((DataRowView)Row.DataBoundItem).Row["s_parentname"];
                    if (dt_studentSelected.Rows.Find((int)((DataRowView)Row.DataBoundItem).Row["s_id"]) == null)
                    {
                        dt_studentSelected.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Student Selected");
            }
            Populate_gv_selectedStudent();
        }

        private void Populate_gv_selectedStudent()
        {
            if(dt_studentSelected.Rows.Count > 0)
            {
                gv_selectedStudent.DataSource = dt_studentSelected;
            }
        }

        private String ShowExampleText(string input)
        {
            input = input.Replace("{StudentName}", "Alice Carson");
            input = input.Replace("{ParentName}", "Matt Lewis");
            return input;
        }

        private void templetParsher(string templet)
        {
            TempletParts.Clear();
            if (templet.Contains("{ParentName}")) { TempletParts.Add(new Part() { Name = "{ParentName}", index = templet.IndexOf("{ParentName}",System.StringComparison.CurrentCulture), dtIndex = 4, isBound = true }); };
            if (templet.Contains("{StudentName}")) { TempletParts.Add(new Part() { Name = "{StudentName}", index = templet.IndexOf("{StudentName}", System.StringComparison.CurrentCulture), dtIndex = 1, isBound = true }); };
            string[] textArray;
            // 0 student name, 1 parent name
            string[] filterText = new string[] { "{ParentName}", "{StudentName}"};
            textArray = templet.Split(filterText, StringSplitOptions.RemoveEmptyEntries);
            List<Part> TextParts = new List<Part>();
            foreach (string item in textArray)
            {
                TextParts.Add(new Part { Name = item, index = templet.IndexOf(item,System.StringComparison.CurrentCulture), isBound = false });
            }
            TempletParts.AddRange(TextParts);
            TempletParts.Sort();
        }

        private void Btn_removeSt_Click(object sender, EventArgs e)
        {
            if (gv_selectedStudent.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow Row in gv_selectedStudent.SelectedRows)
                {
                    dt_studentSelected.Rows.Remove(((DataRowView)Row.DataBoundItem).Row);
                }
            }
        }

        private void Text_templetField_TextChanged(object sender, EventArgs e)
        {
            text_Preview.Text = ShowExampleText(text_templetField.Text);
        }

        private void populateTempFieldCB()
        {
            tmpFieldList = new List<tempFields>();
            tmpFieldList.Add(new tempFields() { text = "Student Name", value = "{StudentName}" });
            tmpFieldList.Add(new tempFields() { text = "Parent Name", value = "{ParentName}" });
            cb_tempField.DataSource = tmpFieldList;
            cb_tempField.DisplayMember = "text";
            cb_tempField.ValueMember = "value";
        }

        private void Btn_preview_Click(object sender, EventArgs e)
        {
            if ((DTP_sendBefore.Value < DTP_scheduleat.Value) || (DTP_sendBefore.Value < DTP_scheduleat.Value))
            {
                MessageBox.Show("Send Before is before the send after. No Message will be sent");
                return;
            }
            if (gv_selectedStudent.Rows.Count > 0)
            {
                if (text_templetField.Text.Length > 10)
                {
                    dt_scheduleMessage.Clear();
                    templetParsher(text_templetField.Text);
                    foreach (DataGridViewRow Row in gv_selectedStudent.Rows)
                    {
                        DataRow messageRow = dt_scheduleMessage.NewRow();
                        messageRow["stdt_name"] = (string)((DataRowView)Row.DataBoundItem).Row["st_name"];
                        messageRow["stdt_mobile"] = (string)((DataRowView)Row.DataBoundItem).Row["st_parentmobile"];
                        string message = "";
                        foreach (Part item in TempletParts)
                        {
                            if (item.isBound)
                            {
                                message += (string)((DataRowView)Row.DataBoundItem).Row[item.dtIndex];
                            }
                            else
                            {
                                message += item.Name;
                            }
                        }
                        messageRow["stdt_message"] = message;
                        dt_scheduleMessage.Rows.Add(messageRow);
                    }
                    gv_message.DataSource = dt_scheduleMessage;
                    pannel_compose.SendToBack();
                }else
                {
                    MessageBox.Show("At Least 10 Static Charector in Message");
                }
            }else
            {
                MessageBox.Show("No Student Selected to sent Message to");
            }
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            pannel_preview.SendToBack();
        }

        private void Btn_schedule_Click(object sender, EventArgs e)
        {
                try
                {
                    using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                    {
                        using (SqlCommand command = new SqlCommand("sp_message_schedule", myConn) { CommandType = CommandType.StoredProcedure })
                        {
                            command.Parameters.AddWithValue("@messageTable", dt_scheduleMessage).TypeName = "message";
                            command.Parameters.AddWithValue("@validafter", DTP_scheduleat.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@validbefore", DTP_sendBefore.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.Add("@status", SqlDbType.Bit).Direction = ParameterDirection.Output;

                            myConn.Open();
                            command.ExecuteNonQuery();
                            scheduledStatus = (bool)command.Parameters["@status"].Value;
                            if (scheduledStatus)
                            {
                                MessageBox.Show("SMS Scheduled Successfull");
                                resetForm();
                            }
                            else
                            {
                                MessageBox.Show("Message Schedule Error");
                            }
                        }

                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    scheduledStatus = false;
                }            
        }

        private void Btn_addfield_Click(object sender, EventArgs e)
        {
            text_templetField.AppendText(cb_tempField.SelectedValue.ToString());
        }

        private void resetForm()
        {
        }

        private void pannel_compose_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DTP_scheduleat_ValueChanged(object sender, EventArgs e)
        {
            DTP_sendBefore.Value = DTP_scheduleat.Value + Properties.Settings.Default.sms_defaultValidFor.TimeOfDay;
        }
    }
}
