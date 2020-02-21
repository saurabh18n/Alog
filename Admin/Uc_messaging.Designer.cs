namespace AManager
{
    partial class Ucmessaging
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gv_sent = new System.Windows.Forms.DataGridView();
            this.s_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_queued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_sent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_sentby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gv_queue = new System.Windows.Forms.DataGridView();
            this.sms_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sms_student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sms_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sms_queued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sms_content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pannel_compose = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DTP_sendBefore = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DTP_scheduleat = new System.Windows.Forms.DateTimePicker();
            this.cb_classSelect = new System.Windows.Forms.ComboBox();
            this.text_studentName = new System.Windows.Forms.TextBox();
            this.gv_student = new System.Windows.Forms.DataGridView();
            this.s_fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_parentmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_parentname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text_mobile = new System.Windows.Forms.TextBox();
            this.gv_selectedStudent = new System.Windows.Forms.DataGridView();
            this.st_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_parentmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_parentname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_removeSt = new System.Windows.Forms.Button();
            this.btn_addtosendlist = new System.Windows.Forms.Button();
            this.text_Preview = new System.Windows.Forms.TextBox();
            this.btn_preview = new System.Windows.Forms.Button();
            this.Btn_addfield = new System.Windows.Forms.Button();
            this.cb_tempField = new System.Windows.Forms.ComboBox();
            this.text_templetField = new System.Windows.Forms.TextBox();
            this.pannel_preview = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_schedule = new System.Windows.Forms.Button();
            this.gv_message = new System.Windows.Forms.DataGridView();
            this.stdt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdt_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdt_message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_sent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_queue)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pannel_compose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_selectedStudent)).BeginInit();
            this.pannel_preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_message)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1207, 646);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gv_sent);
            this.tabPage1.Controls.Add(this.gv_queue);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1199, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "State";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gv_sent
            // 
            this.gv_sent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gv_sent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_sent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_sent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_id,
            this.s_student,
            this.s_mobile,
            this.s_queued,
            this.s_sent,
            this.s_sentby,
            this.s_content});
            this.gv_sent.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gv_sent.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.gv_sent.Location = new System.Drawing.Point(6, 310);
            this.gv_sent.Name = "gv_sent";
            this.gv_sent.RowHeadersVisible = false;
            this.gv_sent.Size = new System.Drawing.Size(964, 299);
            this.gv_sent.TabIndex = 2;
            // 
            // s_id
            // 
            this.s_id.DataPropertyName = "sms_id";
            this.s_id.HeaderText = "sms_id";
            this.s_id.Name = "s_id";
            this.s_id.ReadOnly = true;
            this.s_id.Visible = false;
            // 
            // s_student
            // 
            this.s_student.DataPropertyName = "sms_student";
            dataGridViewCellStyle3.NullValue = null;
            this.s_student.DefaultCellStyle = dataGridViewCellStyle3;
            this.s_student.HeaderText = "Name";
            this.s_student.Name = "s_student";
            this.s_student.ReadOnly = true;
            // 
            // s_mobile
            // 
            this.s_mobile.DataPropertyName = "sms_mobile";
            this.s_mobile.HeaderText = "Mobile";
            this.s_mobile.Name = "s_mobile";
            this.s_mobile.ReadOnly = true;
            // 
            // s_queued
            // 
            this.s_queued.DataPropertyName = "sms_queued";
            dataGridViewCellStyle4.Format = "F";
            dataGridViewCellStyle4.NullValue = null;
            this.s_queued.DefaultCellStyle = dataGridViewCellStyle4;
            this.s_queued.FillWeight = 120F;
            this.s_queued.HeaderText = "Queued";
            this.s_queued.Name = "s_queued";
            this.s_queued.ReadOnly = true;
            // 
            // s_sent
            // 
            this.s_sent.DataPropertyName = "sms_senttime";
            this.s_sent.FillWeight = 120F;
            this.s_sent.HeaderText = "Sent";
            this.s_sent.Name = "s_sent";
            this.s_sent.ReadOnly = true;
            // 
            // s_sentby
            // 
            this.s_sentby.DataPropertyName = "sms_sentby";
            this.s_sentby.FillWeight = 50F;
            this.s_sentby.HeaderText = "Gateway";
            this.s_sentby.Name = "s_sentby";
            this.s_sentby.ReadOnly = true;
            // 
            // s_content
            // 
            this.s_content.DataPropertyName = "sms_content";
            this.s_content.FillWeight = 200F;
            this.s_content.HeaderText = "Text";
            this.s_content.Name = "s_content";
            this.s_content.ReadOnly = true;
            // 
            // gv_queue
            // 
            this.gv_queue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_queue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_queue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sms_id,
            this.sms_student,
            this.sms_mobile,
            this.sms_queued,
            this.sms_content});
            this.gv_queue.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gv_queue.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.gv_queue.Location = new System.Drawing.Point(7, 6);
            this.gv_queue.Name = "gv_queue";
            this.gv_queue.RowHeadersVisible = false;
            this.gv_queue.Size = new System.Drawing.Size(963, 301);
            this.gv_queue.TabIndex = 1;
            // 
            // sms_id
            // 
            this.sms_id.DataPropertyName = "sms_id";
            this.sms_id.FillWeight = 200F;
            this.sms_id.HeaderText = "sms_id";
            this.sms_id.Name = "sms_id";
            this.sms_id.ReadOnly = true;
            this.sms_id.Visible = false;
            // 
            // sms_student
            // 
            this.sms_student.DataPropertyName = "sms_student";
            this.sms_student.HeaderText = "Name";
            this.sms_student.Name = "sms_student";
            this.sms_student.ReadOnly = true;
            // 
            // sms_mobile
            // 
            this.sms_mobile.DataPropertyName = "sms_mobile";
            this.sms_mobile.HeaderText = "Mobile";
            this.sms_mobile.Name = "sms_mobile";
            this.sms_mobile.ReadOnly = true;
            // 
            // sms_queued
            // 
            this.sms_queued.DataPropertyName = "sms_queued";
            this.sms_queued.FillWeight = 120F;
            this.sms_queued.HeaderText = "Queued at";
            this.sms_queued.Name = "sms_queued";
            this.sms_queued.ReadOnly = true;
            // 
            // sms_content
            // 
            this.sms_content.DataPropertyName = "sms_content";
            this.sms_content.FillWeight = 250F;
            this.sms_content.HeaderText = "Text";
            this.sms_content.Name = "sms_content";
            this.sms_content.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.pannel_compose);
            this.tabPage2.Controls.Add(this.pannel_preview);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1199, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Schedule";
            // 
            // pannel_compose
            // 
            this.pannel_compose.AutoScroll = true;
            this.pannel_compose.Controls.Add(this.label2);
            this.pannel_compose.Controls.Add(this.DTP_sendBefore);
            this.pannel_compose.Controls.Add(this.label1);
            this.pannel_compose.Controls.Add(this.DTP_scheduleat);
            this.pannel_compose.Controls.Add(this.cb_classSelect);
            this.pannel_compose.Controls.Add(this.text_studentName);
            this.pannel_compose.Controls.Add(this.gv_student);
            this.pannel_compose.Controls.Add(this.text_mobile);
            this.pannel_compose.Controls.Add(this.gv_selectedStudent);
            this.pannel_compose.Controls.Add(this.btn_removeSt);
            this.pannel_compose.Controls.Add(this.btn_addtosendlist);
            this.pannel_compose.Controls.Add(this.text_Preview);
            this.pannel_compose.Controls.Add(this.btn_preview);
            this.pannel_compose.Controls.Add(this.Btn_addfield);
            this.pannel_compose.Controls.Add(this.cb_tempField);
            this.pannel_compose.Controls.Add(this.text_templetField);
            this.pannel_compose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannel_compose.Location = new System.Drawing.Point(3, 3);
            this.pannel_compose.Name = "pannel_compose";
            this.pannel_compose.Size = new System.Drawing.Size(1193, 609);
            this.pannel_compose.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(874, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Send Before";
            // 
            // DTP_sendBefore
            // 
            this.DTP_sendBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTP_sendBefore.CustomFormat = "dd-MM-yy hh:mm:ss tt";
            this.DTP_sendBefore.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_sendBefore.Location = new System.Drawing.Point(987, 450);
            this.DTP_sendBefore.Name = "DTP_sendBefore";
            this.DTP_sendBefore.ShowUpDown = true;
            this.DTP_sendBefore.Size = new System.Drawing.Size(179, 27);
            this.DTP_sendBefore.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(875, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Send After";
            // 
            // DTP_scheduleat
            // 
            this.DTP_scheduleat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DTP_scheduleat.CustomFormat = "dd-MM-yy hh:mm:ss tt";
            this.DTP_scheduleat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_scheduleat.Location = new System.Drawing.Point(986, 414);
            this.DTP_scheduleat.Name = "DTP_scheduleat";
            this.DTP_scheduleat.ShowUpDown = true;
            this.DTP_scheduleat.Size = new System.Drawing.Size(181, 27);
            this.DTP_scheduleat.TabIndex = 30;
            this.DTP_scheduleat.ValueChanged += new System.EventHandler(this.DTP_scheduleat_ValueChanged);
            // 
            // cb_classSelect
            // 
            this.cb_classSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_classSelect.FormattingEnabled = true;
            this.cb_classSelect.Location = new System.Drawing.Point(168, 3);
            this.cb_classSelect.Name = "cb_classSelect";
            this.cb_classSelect.Size = new System.Drawing.Size(75, 26);
            this.cb_classSelect.TabIndex = 20;
            this.cb_classSelect.SelectedIndexChanged += new System.EventHandler(this.Cb_classSelect_SelectedIndexChanged);
            // 
            // text_studentName
            // 
            this.text_studentName.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_studentName.Location = new System.Drawing.Point(0, 3);
            this.text_studentName.Name = "text_studentName";
            this.text_studentName.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_studentName.Size = new System.Drawing.Size(162, 27);
            this.text_studentName.TabIndex = 19;
            this.text_studentName.TextChanged += new System.EventHandler(this.Text_studentName_TextChanged);
            // 
            // gv_student
            // 
            this.gv_student.AllowUserToAddRows = false;
            this.gv_student.AllowUserToDeleteRows = false;
            this.gv_student.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gv_student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_student.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_fname,
            this.s_class,
            this.s_parentmobile,
            this.dataGridViewTextBoxColumn1,
            this.s_parentname});
            this.gv_student.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gv_student.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.gv_student.GridColor = System.Drawing.SystemColors.Control;
            this.gv_student.Location = new System.Drawing.Point(0, 33);
            this.gv_student.Name = "gv_student";
            this.gv_student.ReadOnly = true;
            this.gv_student.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gv_student.RowHeadersVisible = false;
            this.gv_student.RowHeadersWidth = 4;
            this.gv_student.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gv_student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_student.Size = new System.Drawing.Size(404, 573);
            this.gv_student.TabIndex = 18;
            this.gv_student.TabStop = false;
            // 
            // s_fname
            // 
            this.s_fname.DataPropertyName = "s_name";
            this.s_fname.HeaderText = "Name";
            this.s_fname.Name = "s_fname";
            this.s_fname.ReadOnly = true;
            // 
            // s_class
            // 
            this.s_class.DataPropertyName = "s_class";
            this.s_class.FillWeight = 30F;
            this.s_class.HeaderText = "Class";
            this.s_class.Name = "s_class";
            this.s_class.ReadOnly = true;
            // 
            // s_parentmobile
            // 
            this.s_parentmobile.DataPropertyName = "s_parentmobile";
            this.s_parentmobile.HeaderText = "Mobile";
            this.s_parentmobile.Name = "s_parentmobile";
            this.s_parentmobile.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "s_id";
            this.dataGridViewTextBoxColumn1.FillWeight = 10.5141F;
            this.dataGridViewTextBoxColumn1.HeaderText = "s_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // s_parentname
            // 
            this.s_parentname.DataPropertyName = "s_parentname";
            this.s_parentname.HeaderText = "s_parentname";
            this.s_parentname.Name = "s_parentname";
            this.s_parentname.ReadOnly = true;
            this.s_parentname.Visible = false;
            // 
            // text_mobile
            // 
            this.text_mobile.Location = new System.Drawing.Point(249, 3);
            this.text_mobile.Name = "text_mobile";
            this.text_mobile.Size = new System.Drawing.Size(155, 27);
            this.text_mobile.TabIndex = 21;
            this.text_mobile.TextChanged += new System.EventHandler(this.Text_mobile_TextChanged);
            // 
            // gv_selectedStudent
            // 
            this.gv_selectedStudent.AllowUserToAddRows = false;
            this.gv_selectedStudent.AllowUserToDeleteRows = false;
            this.gv_selectedStudent.AllowUserToOrderColumns = true;
            this.gv_selectedStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gv_selectedStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_selectedStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_selectedStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.st_id,
            this.st_name,
            this.st_class,
            this.st_parentmobile,
            this.st_parentname});
            this.gv_selectedStudent.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gv_selectedStudent.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.gv_selectedStudent.GridColor = System.Drawing.SystemColors.Control;
            this.gv_selectedStudent.Location = new System.Drawing.Point(457, 3);
            this.gv_selectedStudent.Name = "gv_selectedStudent";
            this.gv_selectedStudent.ReadOnly = true;
            this.gv_selectedStudent.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gv_selectedStudent.RowHeadersVisible = false;
            this.gv_selectedStudent.RowHeadersWidth = 4;
            this.gv_selectedStudent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gv_selectedStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_selectedStudent.Size = new System.Drawing.Size(404, 603);
            this.gv_selectedStudent.TabIndex = 22;
            this.gv_selectedStudent.TabStop = false;
            // 
            // st_id
            // 
            this.st_id.DataPropertyName = "st_id";
            this.st_id.HeaderText = "st_id";
            this.st_id.Name = "st_id";
            this.st_id.ReadOnly = true;
            this.st_id.Visible = false;
            // 
            // st_name
            // 
            this.st_name.DataPropertyName = "st_name";
            this.st_name.HeaderText = "name";
            this.st_name.Name = "st_name";
            this.st_name.ReadOnly = true;
            // 
            // st_class
            // 
            this.st_class.DataPropertyName = "st_class";
            this.st_class.FillWeight = 40F;
            this.st_class.HeaderText = "Class";
            this.st_class.Name = "st_class";
            this.st_class.ReadOnly = true;
            // 
            // st_parentmobile
            // 
            this.st_parentmobile.DataPropertyName = "st_parentmobile";
            this.st_parentmobile.HeaderText = "Mobile";
            this.st_parentmobile.Name = "st_parentmobile";
            this.st_parentmobile.ReadOnly = true;
            // 
            // st_parentname
            // 
            this.st_parentname.DataPropertyName = "st_parentname";
            this.st_parentname.HeaderText = "st_parentname";
            this.st_parentname.Name = "st_parentname";
            this.st_parentname.ReadOnly = true;
            this.st_parentname.Visible = false;
            // 
            // btn_removeSt
            // 
            this.btn_removeSt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_removeSt.Location = new System.Drawing.Point(410, 318);
            this.btn_removeSt.Name = "btn_removeSt";
            this.btn_removeSt.Size = new System.Drawing.Size(41, 27);
            this.btn_removeSt.TabIndex = 24;
            this.btn_removeSt.Text = "<";
            this.btn_removeSt.UseVisualStyleBackColor = true;
            this.btn_removeSt.Click += new System.EventHandler(this.Btn_removeSt_Click);
            // 
            // btn_addtosendlist
            // 
            this.btn_addtosendlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_addtosendlist.Location = new System.Drawing.Point(410, 248);
            this.btn_addtosendlist.Name = "btn_addtosendlist";
            this.btn_addtosendlist.Size = new System.Drawing.Size(41, 30);
            this.btn_addtosendlist.TabIndex = 23;
            this.btn_addtosendlist.Text = ">";
            this.btn_addtosendlist.UseVisualStyleBackColor = true;
            this.btn_addtosendlist.Click += new System.EventHandler(this.Btn_addtosendlist_Click);
            // 
            // text_Preview
            // 
            this.text_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Preview.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_Preview.Location = new System.Drawing.Point(878, 225);
            this.text_Preview.Multiline = true;
            this.text_Preview.Name = "text_Preview";
            this.text_Preview.ReadOnly = true;
            this.text_Preview.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_Preview.Size = new System.Drawing.Size(289, 159);
            this.text_Preview.TabIndex = 28;
            // 
            // btn_preview
            // 
            this.btn_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_preview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_preview.Location = new System.Drawing.Point(1064, 505);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(103, 27);
            this.btn_preview.TabIndex = 29;
            this.btn_preview.Text = "Preview";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.Btn_preview_Click);
            // 
            // Btn_addfield
            // 
            this.Btn_addfield.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_addfield.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "BtnFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_addfield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_addfield.Font = global::AManager.Properties.Settings.Default.BtnFont;
            this.Btn_addfield.Location = new System.Drawing.Point(1106, 9);
            this.Btn_addfield.Name = "Btn_addfield";
            this.Btn_addfield.Size = new System.Drawing.Size(61, 26);
            this.Btn_addfield.TabIndex = 27;
            this.Btn_addfield.Text = "+";
            this.Btn_addfield.UseVisualStyleBackColor = true;
            this.Btn_addfield.Click += new System.EventHandler(this.Btn_addfield_Click);
            // 
            // cb_tempField
            // 
            this.cb_tempField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_tempField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tempField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tempField.FormattingEnabled = true;
            this.cb_tempField.Location = new System.Drawing.Point(878, 9);
            this.cb_tempField.Name = "cb_tempField";
            this.cb_tempField.Size = new System.Drawing.Size(183, 26);
            this.cb_tempField.TabIndex = 26;
            // 
            // text_templetField
            // 
            this.text_templetField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.text_templetField.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_templetField.Location = new System.Drawing.Point(878, 48);
            this.text_templetField.Multiline = true;
            this.text_templetField.Name = "text_templetField";
            this.text_templetField.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_templetField.Size = new System.Drawing.Size(289, 159);
            this.text_templetField.TabIndex = 25;
            this.text_templetField.TextChanged += new System.EventHandler(this.Text_templetField_TextChanged);
            // 
            // pannel_preview
            // 
            this.pannel_preview.Controls.Add(this.btn_back);
            this.pannel_preview.Controls.Add(this.btn_schedule);
            this.pannel_preview.Controls.Add(this.gv_message);
            this.pannel_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannel_preview.Location = new System.Drawing.Point(3, 3);
            this.pannel_preview.Name = "pannel_preview";
            this.pannel_preview.Size = new System.Drawing.Size(1193, 609);
            this.pannel_preview.TabIndex = 18;
            // 
            // btn_back
            // 
            this.btn_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_back.Location = new System.Drawing.Point(983, 568);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 34);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.Btn_back_Click);
            // 
            // btn_schedule
            // 
            this.btn_schedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_schedule.Location = new System.Drawing.Point(1064, 568);
            this.btn_schedule.Name = "btn_schedule";
            this.btn_schedule.Size = new System.Drawing.Size(122, 34);
            this.btn_schedule.TabIndex = 1;
            this.btn_schedule.Text = "Schedule";
            this.btn_schedule.UseVisualStyleBackColor = true;
            this.btn_schedule.Click += new System.EventHandler(this.Btn_schedule_Click);
            // 
            // gv_message
            // 
            this.gv_message.AllowUserToAddRows = false;
            this.gv_message.AllowUserToDeleteRows = false;
            this.gv_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_message.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_message.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stdt_name,
            this.stdt_mobile,
            this.stdt_message});
            this.gv_message.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gv_message.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.gv_message.Location = new System.Drawing.Point(8, 9);
            this.gv_message.Name = "gv_message";
            this.gv_message.ReadOnly = true;
            this.gv_message.RowHeadersVisible = false;
            this.gv_message.Size = new System.Drawing.Size(1182, 553);
            this.gv_message.TabIndex = 0;
            // 
            // stdt_name
            // 
            this.stdt_name.DataPropertyName = "stdt_name";
            this.stdt_name.FillWeight = 50F;
            this.stdt_name.HeaderText = "Student Name";
            this.stdt_name.Name = "stdt_name";
            this.stdt_name.ReadOnly = true;
            // 
            // stdt_mobile
            // 
            this.stdt_mobile.DataPropertyName = "stdt_mobile";
            this.stdt_mobile.FillWeight = 50F;
            this.stdt_mobile.HeaderText = "Mobile Number";
            this.stdt_mobile.Name = "stdt_mobile";
            this.stdt_mobile.ReadOnly = true;
            // 
            // stdt_message
            // 
            this.stdt_message.DataPropertyName = "stdt_message";
            this.stdt_message.FillWeight = 400F;
            this.stdt_message.HeaderText = "Message";
            this.stdt_message.Name = "stdt_message";
            this.stdt_message.ReadOnly = true;
            // 
            // Ucmessaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Ucmessaging";
            this.Size = new System.Drawing.Size(1207, 646);
            this.Load += new System.EventHandler(this.Uc_messaging_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_sent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_queue)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.pannel_compose.ResumeLayout(false);
            this.pannel_compose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_selectedStudent)).EndInit();
            this.pannel_preview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_message)).EndInit();
            this.ResumeLayout(false);

        }

        private void Gv_student_DataBindingComplete(object sender, System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            this.gv_student.ClearSelection();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gv_sent;
        private System.Windows.Forms.DataGridView gv_queue;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sms_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sms_student;
        private System.Windows.Forms.DataGridViewTextBoxColumn sms_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn sms_queued;
        private System.Windows.Forms.DataGridViewTextBoxColumn sms_content;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_student;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_queued;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_sent;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_sentby;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_content;
        private System.Windows.Forms.Panel pannel_preview;
        private System.Windows.Forms.DataGridView gv_message;
        private System.Windows.Forms.Button btn_schedule;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel pannel_compose;
        private System.Windows.Forms.ComboBox cb_classSelect;
        private System.Windows.Forms.TextBox text_studentName;
        private System.Windows.Forms.DataGridView gv_student;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_parentmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_parentname;
        private System.Windows.Forms.TextBox text_mobile;
        private System.Windows.Forms.DataGridView gv_selectedStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_parentmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_parentname;
        private System.Windows.Forms.Button btn_removeSt;
        private System.Windows.Forms.Button btn_addtosendlist;
        private System.Windows.Forms.TextBox text_Preview;
        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.Button Btn_addfield;
        private System.Windows.Forms.ComboBox cb_tempField;
        private System.Windows.Forms.TextBox text_templetField;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdt_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn stdt_message;
        private System.Windows.Forms.DateTimePicker DTP_scheduleat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTP_sendBefore;
    }
}
