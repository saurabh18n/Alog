namespace AManager
{
    partial class Uc_settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Btn_changeControlFont = new System.Windows.Forms.Button();
            this.label_controlFont = new System.Windows.Forms.Label();
            this.cb_textDirection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_refreshRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dt_autocheckout = new System.Windows.Forms.DateTimePicker();
            this.dt_checkout_end = new System.Windows.Forms.DateTimePicker();
            this.dt_checkout_start = new System.Windows.Forms.DateTimePicker();
            this.dt_checkin_end = new System.Windows.Forms.DateTimePicker();
            this.dt_checkin_start = new System.Windows.Forms.DateTimePicker();
            this.btn_save = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_SMSsaveSetting = new System.Windows.Forms.Button();
            this.dt_sms_validfor = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_gatewaypriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_addfiend = new System.Windows.Forms.Button();
            this.cb_tempField = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.text_Preview = new System.Windows.Forms.TextBox();
            this.text_templetField = new System.Windows.Forms.TextBox();
            this.btn_saveTemplet = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fontDialog_control = new System.Windows.Forms.FontDialog();
            this.Btn_genSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1035, 547);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Btn_genSave);
            this.tabPage1.Controls.Add(this.Btn_changeControlFont);
            this.tabPage1.Controls.Add(this.label_controlFont);
            this.tabPage1.Controls.Add(this.cb_textDirection);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cb_refreshRate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1027, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Btn_changeControlFont
            // 
            this.Btn_changeControlFont.AutoSize = true;
            this.Btn_changeControlFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_changeControlFont.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_changeControlFont.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.Btn_changeControlFont.Location = new System.Drawing.Point(239, 94);
            this.Btn_changeControlFont.Name = "Btn_changeControlFont";
            this.Btn_changeControlFont.Size = new System.Drawing.Size(89, 23);
            this.Btn_changeControlFont.TabIndex = 7;
            this.Btn_changeControlFont.Text = "Change Font";
            this.Btn_changeControlFont.UseVisualStyleBackColor = true;
            this.Btn_changeControlFont.Click += new System.EventHandler(this.Btn_changeControlFont_Click);
            // 
            // label_controlFont
            // 
            this.label_controlFont.AutoSize = true;
            this.label_controlFont.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label_controlFont.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label_controlFont.Location = new System.Drawing.Point(6, 99);
            this.label_controlFont.Name = "label_controlFont";
            this.label_controlFont.Size = new System.Drawing.Size(83, 13);
            this.label_controlFont.TabIndex = 6;
            this.label_controlFont.Text = "Controls Font";
            // 
            // cb_textDirection
            // 
            this.cb_textDirection.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_textDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_textDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_textDirection.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.cb_textDirection.FormattingEnabled = true;
            this.cb_textDirection.Location = new System.Drawing.Point(166, 56);
            this.cb_textDirection.Name = "cb_textDirection";
            this.cb_textDirection.Size = new System.Drawing.Size(162, 21);
            this.cb_textDirection.TabIndex = 5;
            this.cb_textDirection.SelectedIndexChanged += new System.EventHandler(this.cb_textDirection_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text Direction";
            // 
            // cb_refreshRate
            // 
            this.cb_refreshRate.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_refreshRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_refreshRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_refreshRate.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.cb_refreshRate.FormattingEnabled = true;
            this.cb_refreshRate.Location = new System.Drawing.Point(166, 13);
            this.cb_refreshRate.Name = "cb_refreshRate";
            this.cb_refreshRate.Size = new System.Drawing.Size(162, 21);
            this.cb_refreshRate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default Refresh";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dt_autocheckout);
            this.tabPage3.Controls.Add(this.dt_checkout_end);
            this.tabPage3.Controls.Add(this.dt_checkout_start);
            this.tabPage3.Controls.Add(this.dt_checkin_end);
            this.tabPage3.Controls.Add(this.dt_checkin_start);
            this.tabPage3.Controls.Add(this.btn_save);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1027, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Attendence";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dt_autocheckout
            // 
            this.dt_autocheckout.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_autocheckout.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.dt_autocheckout.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_autocheckout.Location = new System.Drawing.Point(237, 101);
            this.dt_autocheckout.Name = "dt_autocheckout";
            this.dt_autocheckout.ShowUpDown = true;
            this.dt_autocheckout.Size = new System.Drawing.Size(107, 20);
            this.dt_autocheckout.TabIndex = 22;
            this.dt_autocheckout.TabStop = false;
            this.dt_autocheckout.Value = global::AManager.Properties.Settings.Default.autoCheckOut;
            // 
            // dt_checkout_end
            // 
            this.dt_checkout_end.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_checkout_end.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.dt_checkout_end.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_checkout_end.Location = new System.Drawing.Point(421, 58);
            this.dt_checkout_end.Name = "dt_checkout_end";
            this.dt_checkout_end.ShowUpDown = true;
            this.dt_checkout_end.Size = new System.Drawing.Size(110, 20);
            this.dt_checkout_end.TabIndex = 21;
            this.dt_checkout_end.TabStop = false;
            this.dt_checkout_end.Value = global::AManager.Properties.Settings.Default.checkoutEnd;
            // 
            // dt_checkout_start
            // 
            this.dt_checkout_start.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_checkout_start.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.dt_checkout_start.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_checkout_start.Location = new System.Drawing.Point(236, 57);
            this.dt_checkout_start.Name = "dt_checkout_start";
            this.dt_checkout_start.ShowUpDown = true;
            this.dt_checkout_start.Size = new System.Drawing.Size(107, 20);
            this.dt_checkout_start.TabIndex = 20;
            this.dt_checkout_start.TabStop = false;
            this.dt_checkout_start.Value = global::AManager.Properties.Settings.Default.checkoutStart;
            // 
            // dt_checkin_end
            // 
            this.dt_checkin_end.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_checkin_end.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.dt_checkin_end.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_checkin_end.Location = new System.Drawing.Point(421, 15);
            this.dt_checkin_end.Name = "dt_checkin_end";
            this.dt_checkin_end.ShowUpDown = true;
            this.dt_checkin_end.Size = new System.Drawing.Size(110, 20);
            this.dt_checkin_end.TabIndex = 19;
            this.dt_checkin_end.TabStop = false;
            this.dt_checkin_end.Value = global::AManager.Properties.Settings.Default.checkinEnd;
            // 
            // dt_checkin_start
            // 
            this.dt_checkin_start.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_checkin_start.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.dt_checkin_start.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_checkin_start.Location = new System.Drawing.Point(237, 15);
            this.dt_checkin_start.Name = "dt_checkin_start";
            this.dt_checkin_start.ShowUpDown = true;
            this.dt_checkin_start.Size = new System.Drawing.Size(107, 20);
            this.dt_checkin_start.TabIndex = 18;
            this.dt_checkin_start.TabStop = false;
            this.dt_checkin_start.Value = global::AManager.Properties.Settings.Default.checkinStart;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(456, 91);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 30);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label11.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label11.Location = new System.Drawing.Point(363, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "End";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label12.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label12.Location = new System.Drawing.Point(176, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Start";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label10.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label10.Location = new System.Drawing.Point(363, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "End";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label9.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label9.Location = new System.Drawing.Point(176, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Start";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label8.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label8.Location = new System.Drawing.Point(22, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Auto Check Out";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label7.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label7.Location = new System.Drawing.Point(22, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Check Out";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label6.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label6.Location = new System.Drawing.Point(22, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Check In";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.btn_SMSsaveSetting);
            this.tabPage2.Controls.Add(this.dt_sms_validfor);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cb_gatewaypriority);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1027, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label14.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label14.Location = new System.Drawing.Point(3, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Settings";
            // 
            // btn_SMSsaveSetting
            // 
            this.btn_SMSsaveSetting.AutoSize = true;
            this.btn_SMSsaveSetting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_SMSsaveSetting.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_SMSsaveSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SMSsaveSetting.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_SMSsaveSetting.Location = new System.Drawing.Point(242, 156);
            this.btn_SMSsaveSetting.Name = "btn_SMSsaveSetting";
            this.btn_SMSsaveSetting.Size = new System.Drawing.Size(48, 25);
            this.btn_SMSsaveSetting.TabIndex = 15;
            this.btn_SMSsaveSetting.Text = "Save";
            this.btn_SMSsaveSetting.UseVisualStyleBackColor = true;
            this.btn_SMSsaveSetting.Click += new System.EventHandler(this.btn_SMSsaveSetting_Click);
            // 
            // dt_sms_validfor
            // 
            this.dt_sms_validfor.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_sms_validfor.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.dt_sms_validfor.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_sms_validfor.Location = new System.Drawing.Point(196, 89);
            this.dt_sms_validfor.Name = "dt_sms_validfor";
            this.dt_sms_validfor.ShowUpDown = true;
            this.dt_sms_validfor.Size = new System.Drawing.Size(105, 20);
            this.dt_sms_validfor.TabIndex = 14;
            this.dt_sms_validfor.Value = global::AManager.Properties.Settings.Default.sms_defaultValidFor;
            this.dt_sms_validfor.ValueChanged += new System.EventHandler(this.dt_sms_validfor_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label13.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label13.Location = new System.Drawing.Point(6, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Message Valid For";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label4.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label4.Location = new System.Drawing.Point(370, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Attendence Message Templet";
            // 
            // cb_gatewaypriority
            // 
            this.cb_gatewaypriority.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_gatewaypriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_gatewaypriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_gatewaypriority.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.cb_gatewaypriority.FormattingEnabled = true;
            this.cb_gatewaypriority.Items.AddRange(new object[] {
            "Local",
            "API"});
            this.cb_gatewaypriority.Location = new System.Drawing.Point(180, 39);
            this.cb_gatewaypriority.Name = "cb_gatewaypriority";
            this.cb_gatewaypriority.Size = new System.Drawing.Size(121, 21);
            this.cb_gatewaypriority.TabIndex = 5;
            this.cb_gatewaypriority.SelectedIndexChanged += new System.EventHandler(this.cb_gatewaypriority_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label3.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gateway Priority";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Btn_addfiend);
            this.panel1.Controls.Add(this.cb_tempField);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.text_Preview);
            this.panel1.Controls.Add(this.text_templetField);
            this.panel1.Controls.Add(this.btn_saveTemplet);
            this.panel1.Location = new System.Drawing.Point(373, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 377);
            this.panel1.TabIndex = 16;
            // 
            // Btn_addfiend
            // 
            this.Btn_addfiend.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_addfiend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_addfiend.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.Btn_addfiend.Location = new System.Drawing.Point(244, 22);
            this.Btn_addfiend.Name = "Btn_addfiend";
            this.Btn_addfiend.Size = new System.Drawing.Size(61, 26);
            this.Btn_addfiend.TabIndex = 17;
            this.Btn_addfiend.Text = "+";
            this.Btn_addfiend.UseVisualStyleBackColor = true;
            this.Btn_addfiend.Click += new System.EventHandler(this.Btn_addfiend_Click);
            // 
            // cb_tempField
            // 
            this.cb_tempField.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_tempField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tempField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tempField.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.cb_tempField.FormattingEnabled = true;
            this.cb_tempField.Items.AddRange(new object[] {
            "Parent Name",
            "Student Name",
            "Date",
            "Time"});
            this.cb_tempField.Location = new System.Drawing.Point(16, 22);
            this.cb_tempField.Name = "cb_tempField";
            this.cb_tempField.Size = new System.Drawing.Size(183, 21);
            this.cb_tempField.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label5.Location = new System.Drawing.Point(329, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Message Preview";
            // 
            // text_Preview
            // 
            this.text_Preview.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_Preview.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_Preview.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_Preview.Location = new System.Drawing.Point(332, 61);
            this.text_Preview.Multiline = true;
            this.text_Preview.Name = "text_Preview";
            this.text_Preview.ReadOnly = true;
            this.text_Preview.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_Preview.Size = new System.Drawing.Size(283, 251);
            this.text_Preview.TabIndex = 14;
            // 
            // text_templetField
            // 
            this.text_templetField.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_templetField.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_templetField.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_templetField.Location = new System.Drawing.Point(16, 61);
            this.text_templetField.Multiline = true;
            this.text_templetField.Name = "text_templetField";
            this.text_templetField.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_templetField.Size = new System.Drawing.Size(289, 251);
            this.text_templetField.TabIndex = 13;
            this.text_templetField.TextChanged += new System.EventHandler(this.Text_templetField_TextChanged);
            // 
            // btn_saveTemplet
            // 
            this.btn_saveTemplet.AutoSize = true;
            this.btn_saveTemplet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_saveTemplet.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_saveTemplet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveTemplet.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_saveTemplet.Location = new System.Drawing.Point(518, 318);
            this.btn_saveTemplet.Name = "btn_saveTemplet";
            this.btn_saveTemplet.Size = new System.Drawing.Size(97, 25);
            this.btn_saveTemplet.TabIndex = 12;
            this.btn_saveTemplet.Text = "Save Templet";
            this.btn_saveTemplet.UseVisualStyleBackColor = true;
            this.btn_saveTemplet.Click += new System.EventHandler(this.Btn_saveTemplet_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 176);
            this.panel2.TabIndex = 17;
            // 
            // Btn_genSave
            // 
            this.Btn_genSave.Location = new System.Drawing.Point(253, 143);
            this.Btn_genSave.Name = "Btn_genSave";
            this.Btn_genSave.Size = new System.Drawing.Size(75, 30);
            this.Btn_genSave.TabIndex = 18;
            this.Btn_genSave.Text = "Save";
            this.Btn_genSave.UseVisualStyleBackColor = true;
            this.Btn_genSave.Click += new System.EventHandler(this.Btn_genSave_Click);
            // 
            // Uc_settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Name = "Uc_settings";
            this.Size = new System.Drawing.Size(1035, 547);
            this.Load += new System.EventHandler(this.Uc_settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cb_refreshRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_gatewaypriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_saveTemplet;
        private System.Windows.Forms.ComboBox cb_textDirection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dt_sms_validfor;
        private System.Windows.Forms.DateTimePicker dt_checkout_end;
        private System.Windows.Forms.DateTimePicker dt_checkout_start;
        private System.Windows.Forms.DateTimePicker dt_checkin_end;
        private System.Windows.Forms.DateTimePicker dt_checkin_start;
        private System.Windows.Forms.DateTimePicker dt_autocheckout;
        private System.Windows.Forms.Button btn_SMSsaveSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button Btn_addfiend;
        private System.Windows.Forms.ComboBox cb_tempField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_Preview;
        private System.Windows.Forms.TextBox text_templetField;
        private System.Windows.Forms.Label label_controlFont;
        private System.Windows.Forms.Button Btn_changeControlFont;
        private System.Windows.Forms.FontDialog fontDialog_control;
        private System.Windows.Forms.Button Btn_genSave;
    }
}
