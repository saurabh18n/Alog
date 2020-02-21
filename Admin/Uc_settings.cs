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
using Regex = System.Text.RegularExpressions.Regex;


namespace AManager
{
    public partial class Uc_settings : UserControl
    {
        DataSet Ds_settings = new DataSet();
        string templet;
        bool isGatewayPriorityChanged = false;
        bool isSMSValidforChanged = false;
        bool isTempletChanged = false;


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

        class cbData
        {
            public string text { get; set; }
            public int Value { get; set; }
        }

        public Uc_settings()
        {
            InitializeComponent();

        }

        private void Uc_settings_Load(object sender, EventArgs e)
        {
            populateRefreshRate();
            pupulateTextDirection();
            populategatewayPriority();
            populateTempletFields();
            initialiseSettingsValue();
            label_controlFont.Text = $"Font: {Properties.Settings.Default.labelFont.Name} {Properties.Settings.Default.labelFont.Size}";
        }

        private void populateRefreshRate()
        {
            Ds_settings.Tables.Add(new DataTable("dt_refresh"));
            Ds_settings.Tables["dt_refresh"].Columns.Add("text");
            Ds_settings.Tables["dt_refresh"].Columns.Add("value");
            foreach (int item in new int[11] { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 })
            {
                DataRow dr = Ds_settings.Tables["dt_refresh"].NewRow();
                dr[0] = item.ToString() + " Seconds";
                dr[1] = item;
                Ds_settings.Tables["dt_refresh"].Rows.Add(dr);
            }
            cb_refreshRate.DataSource = Ds_settings.Tables["dt_refresh"];
            cb_refreshRate.DisplayMember = "text";
            cb_refreshRate.ValueMember = "value";
        }

        private void populategatewayPriority()
        {
            Ds_settings.Tables.Add(new DataTable("dt_gwPriority"));
            Ds_settings.Tables["dt_gwPriority"].Columns.Add("text");
            Ds_settings.Tables["dt_gwPriority"].Columns.Add("value");
            DataRow dr = Ds_settings.Tables["dt_gwPriority"].NewRow();
            dr[0] = "Local";
            dr[1] = 1;
            DataRow dr2 = Ds_settings.Tables["dt_gwPriority"].NewRow();
            dr2[0] = "API";
            dr2[1] = 2;
            Ds_settings.Tables["dt_gwPriority"].Rows.Add(dr);
            Ds_settings.Tables["dt_gwPriority"].Rows.Add(dr2);
            cb_gatewaypriority.DataSource = Ds_settings.Tables["dt_gwPriority"];
            cb_gatewaypriority.DisplayMember = "text";
            cb_gatewaypriority.ValueMember = "value";
        }

        private void populateTempletFields()
        {
            Ds_settings.Tables.Add(new DataTable("dt_tempField"));
            Ds_settings.Tables["dt_tempField"].Columns.Add("text");
            Ds_settings.Tables["dt_tempField"].Columns.Add("value");
            DataRow dr = Ds_settings.Tables["dt_tempField"].NewRow();
            dr[0] = "ParentName";
            dr[1] = 1;
            Ds_settings.Tables["dt_tempField"].Rows.Add(dr);

            DataRow dr1 = Ds_settings.Tables["dt_tempField"].NewRow();
            dr1[0] = "StudentName";
            dr1[1] = 2;
            Ds_settings.Tables["dt_tempField"].Rows.Add(dr1);

            DataRow dr2 = Ds_settings.Tables["dt_tempField"].NewRow();
            dr2[0] = "Date";
            dr2[1] = 3;
            Ds_settings.Tables["dt_tempField"].Rows.Add(dr2);

            DataRow dr3 = Ds_settings.Tables["dt_tempField"].NewRow();
            dr3[0] = "Time";
            dr3[1] = 4;
            Ds_settings.Tables["dt_tempField"].Rows.Add(dr3);
            cb_tempField.DataSource = Ds_settings.Tables["dt_tempField"];
            cb_tempField.DisplayMember = "text";
            cb_tempField.ValueMember = "value";
        }

        private void Btn_addfiend_Click(object sender, EventArgs e)
        {
            text_templetField.AppendText("{" + cb_tempField.Text + "}");
        }

        private void Text_templetField_TextChanged(object sender, EventArgs e)
        {
            text_Preview.Text = ShowExampleText(text_templetField.Text);
            isTempletChanged = true;
        }

        private String ShowExampleText(string input)
        {
            input = input.Replace("{StudentName}", "Alice Carson");
            input = input.Replace("{ParentName}", "Matt Lewis");
            input = input.Replace("{Date}", "22/10/2020");
            input = input.Replace("{Time}", "10:30 AM");
            return input;
        }

        private void Btn_saveTemplet_Click(object sender, EventArgs e)
        {
            if (isTempletChanged)
            {
                string tempstring = text_templetField.Text.Trim();
                if (!(tempstring.Length < 30 || tempstring.Length > 299))
                {
                    using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                    {
                        using (SqlCommand command = new SqlCommand("sp_update_sms_templet", myConn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@temp", tempstring);
                            try
                            {
                                myConn.Open();
                                command.ExecuteNonQuery();
                                Properties.Settings.Default.smsTemplet = tempstring;
                                MessageBox.Show("Templet Updated successfully");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Error " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Templet Should be At Lease 30 Charector and not more then 299 Charector");
                }
            }



            Properties.Settings.Default.Save();
        }

        private void pupulateTextDirection()
        {
            Dictionary<string, System.Windows.Forms.RightToLeft> dict = new Dictionary<string, System.Windows.Forms.RightToLeft>();
            dict.Add("Right to Left", System.Windows.Forms.RightToLeft.Yes);
            dict.Add("Left to Right", System.Windows.Forms.RightToLeft.No);
            cb_textDirection.DataSource = new BindingSource(dict, null);
            cb_textDirection.ValueMember = "Value";
            cb_textDirection.DisplayMember = "Key";
        }

        private void cb_textDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_textDirection.Focused)
            {
                Properties.Settings.Default.TextRighttoLeft = (RightToLeft)cb_textDirection.SelectedValue;
            }
        }

        private void initialiseSettingsValue()
        {
            cb_textDirection.SelectedValue = AManager.Properties.Settings.Default.TextRighttoLeft;
            cb_refreshRate.SelectedValue = AManager.Properties.Settings.Default.refreshInterval;
            cb_gatewaypriority.SelectedValue = AManager.Properties.Settings.Default.gatewayPriority;
            templet = Properties.Settings.Default.smsTemplet;
            text_templetField.Text = templet;
            //Intialis hr min selector fro check in check out
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkinStart = dt_checkin_start.Value;
            Properties.Settings.Default.checkinEnd = dt_checkin_end.Value;
            Properties.Settings.Default.checkoutStart = dt_checkout_start.Value;
            Properties.Settings.Default.checkoutEnd = dt_checkout_end.Value;
            Properties.Settings.Default.autoCheckOut = dt_autocheckout.Value;
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
            {
                using (SqlCommand command = new SqlCommand("sp_update_attendence_time", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@checkInStart", dt_checkin_start.Value.ToString("hh:mm:ss"));
                    command.Parameters.AddWithValue("@checkInEnd", dt_checkin_end.Value.ToString("hh:mm:ss"));
                    command.Parameters.AddWithValue("@checkOutStart", dt_checkout_start.Value.ToString("hh:mm:ss"));
                    command.Parameters.AddWithValue("@checkOutEnd", dt_checkout_end.Value.ToString("hh:mm:ss"));
                    command.Parameters.AddWithValue("@checkoutAll", dt_autocheckout.Value.ToString("hh:mm:ss"));
                    try
                    {
                        myConn.Open();
                        command.ExecuteNonQuery();
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Saved Successfuly");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("SqlError " + ex.Message);
                    }
                }
            }
        }

        private void dt_sms_validfor_ValueChanged(object sender, EventArgs e)
        {
            isSMSValidforChanged = true;
        }

        private void cb_gatewaypriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            isGatewayPriorityChanged = true;
        }

        private void btn_SMSsaveSetting_Click(object sender, EventArgs e)
        {
            if (isGatewayPriorityChanged)
            {

            }
            if (isSMSValidforChanged)
            {
                using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                {
                    using (SqlCommand command = new SqlCommand("sp_update_sms_validtime", myConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@offset", dt_sms_validfor.Value.ToString("hh:mm:ss"));
                        try
                        {
                            myConn.Open();
                            command.ExecuteNonQuery();
                            Properties.Settings.Default.sms_defaultValidFor = dt_sms_validfor.Value;
                            MessageBox.Show("Updated Successfully");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("SQL Error updating SMS valid for Time " + ex.Message);
                        }

                    }
                }
            }
            Properties.Settings.Default.Save();
        }

        private void Btn_changeControlFont_Click(object sender, EventArgs e)
        {
            fontDialog_control.Font = Properties.Settings.Default.labelFont;
            fontDialog_control.ShowEffects = false;
            fontDialog_control.ShowHelp = false;
            fontDialog_control.ShowApply = true;
            fontDialog_control.Apply += (object sender2, EventArgs e2) =>
            {
                Properties.Settings.Default.labelFont = fontDialog_control.Font;
                Properties.Settings.Default.Save();
                //Application.Restart();
            };
            fontDialog_control.ShowDialog();
        }

        private void Btn_genSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
