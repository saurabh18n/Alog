namespace AManager
{
    partial class Uc_student
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
            this.gv_student = new System.Windows.Forms.DataGridView();
            this.text_studentName = new System.Windows.Forms.TextBox();
            this.cb_class = new System.Windows.Forms.ComboBox();
            this.text_mobile = new System.Windows.Forms.TextBox();
            this.text_FirstName = new System.Windows.Forms.TextBox();
            this.text_LastName = new System.Windows.Forms.TextBox();
            this.cb_classSelect = new System.Windows.Forms.ComboBox();
            this.text_ParentMobile = new System.Windows.Forms.TextBox();
            this.text_Address = new System.Windows.Forms.TextBox();
            this.btn_UpdateDetails = new System.Windows.Forms.Button();
            this.text_homePhone = new System.Windows.Forms.TextBox();
            this.datePicker_DoB = new System.Windows.Forms.DateTimePicker();
            this.btn_addNew = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.text_parentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lavel_idonMachine = new System.Windows.Forms.Label();
            this.s_fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_lname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_dob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_parentmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_idonmachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_homephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_parentname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_student)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_student
            // 
            this.gv_student.AllowUserToAddRows = false;
            this.gv_student.AllowUserToDeleteRows = false;
            this.gv_student.AllowUserToOrderColumns = true;
            this.gv_student.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gv_student.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gv_student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gv_student.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_fname,
            this.s_lname,
            this.s_dob,
            this.s_class,
            this.class_class,
            this.s_parentmobile,
            this.s_idonmachine,
            this.s_homephone,
            this.s_parentname,
            this.s_address});
            this.gv_student.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.gv_student.GridColor = System.Drawing.SystemColors.Control;
            this.gv_student.Location = new System.Drawing.Point(2, 40);
            this.gv_student.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gv_student.Name = "gv_student";
            this.gv_student.ReadOnly = true;
            this.gv_student.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gv_student.RowHeadersVisible = false;
            this.gv_student.RowHeadersWidth = 4;
            this.gv_student.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gv_student.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gv_student.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_student.Size = new System.Drawing.Size(555, 683);
            this.gv_student.TabIndex = 0;
            this.gv_student.TabStop = false;
            // 
            // text_studentName
            // 
            this.text_studentName.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_studentName.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_studentName.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_studentName.Location = new System.Drawing.Point(4, 4);
            this.text_studentName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_studentName.Name = "text_studentName";
            this.text_studentName.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_studentName.Size = new System.Drawing.Size(150, 20);
            this.text_studentName.TabIndex = 1;
            this.text_studentName.TextChanged += new System.EventHandler(this.text_studentName_TextChanged);
            // 
            // cb_class
            // 
            this.cb_class.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_class.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.cb_class.FormattingEnabled = true;
            this.cb_class.Location = new System.Drawing.Point(248, 4);
            this.cb_class.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_class.Name = "cb_class";
            this.cb_class.Size = new System.Drawing.Size(117, 21);
            this.cb_class.TabIndex = 2;
            this.cb_class.SelectionChangeCommitted += new System.EventHandler(this.cb_class_SelectionChangeCommited);
            // 
            // text_mobile
            // 
            this.text_mobile.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_mobile.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_mobile.Location = new System.Drawing.Point(416, 5);
            this.text_mobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_mobile.Name = "text_mobile";
            this.text_mobile.Size = new System.Drawing.Size(141, 20);
            this.text_mobile.TabIndex = 3;
            this.text_mobile.TextChanged += new System.EventHandler(this.text_mobile_TextChanged);
            // 
            // text_FirstName
            // 
            this.text_FirstName.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_FirstName.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_FirstName.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_FirstName.Location = new System.Drawing.Point(585, 32);
            this.text_FirstName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_FirstName.Name = "text_FirstName";
            this.text_FirstName.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_FirstName.Size = new System.Drawing.Size(176, 20);
            this.text_FirstName.TabIndex = 4;
            // 
            // text_LastName
            // 
            this.text_LastName.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_LastName.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_LastName.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_LastName.Location = new System.Drawing.Point(776, 32);
            this.text_LastName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_LastName.Name = "text_LastName";
            this.text_LastName.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_LastName.Size = new System.Drawing.Size(174, 20);
            this.text_LastName.TabIndex = 5;
            // 
            // cb_classSelect
            // 
            this.cb_classSelect.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_classSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_classSelect.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.cb_classSelect.FormattingEnabled = true;
            this.cb_classSelect.Location = new System.Drawing.Point(585, 132);
            this.cb_classSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cb_classSelect.Name = "cb_classSelect";
            this.cb_classSelect.Size = new System.Drawing.Size(176, 21);
            this.cb_classSelect.TabIndex = 6;
            // 
            // text_ParentMobile
            // 
            this.text_ParentMobile.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_ParentMobile.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_ParentMobile.Location = new System.Drawing.Point(776, 78);
            this.text_ParentMobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_ParentMobile.Name = "text_ParentMobile";
            this.text_ParentMobile.Size = new System.Drawing.Size(174, 20);
            this.text_ParentMobile.TabIndex = 7;
            // 
            // text_Address
            // 
            this.text_Address.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_Address.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_Address.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_Address.Location = new System.Drawing.Point(585, 178);
            this.text_Address.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_Address.Multiline = true;
            this.text_Address.Name = "text_Address";
            this.text_Address.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_Address.Size = new System.Drawing.Size(405, 66);
            this.text_Address.TabIndex = 8;
            // 
            // btn_UpdateDetails
            // 
            this.btn_UpdateDetails.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_UpdateDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpdateDetails.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_UpdateDetails.Location = new System.Drawing.Point(585, 281);
            this.btn_UpdateDetails.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_UpdateDetails.Name = "btn_UpdateDetails";
            this.btn_UpdateDetails.Size = new System.Drawing.Size(84, 34);
            this.btn_UpdateDetails.TabIndex = 9;
            this.btn_UpdateDetails.Text = "Update";
            this.btn_UpdateDetails.UseVisualStyleBackColor = true;
            this.btn_UpdateDetails.Click += new System.EventHandler(this.Btn_UpdateDetails_Click);
            // 
            // text_homePhone
            // 
            this.text_homePhone.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_homePhone.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_homePhone.Location = new System.Drawing.Point(776, 132);
            this.text_homePhone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_homePhone.Name = "text_homePhone";
            this.text_homePhone.Size = new System.Drawing.Size(174, 20);
            this.text_homePhone.TabIndex = 10;
            // 
            // datePicker_DoB
            // 
            this.datePicker_DoB.CalendarFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker_DoB.CustomFormat = "dd-MM-yyyy";
            this.datePicker_DoB.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.datePicker_DoB.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.datePicker_DoB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker_DoB.Location = new System.Drawing.Point(974, 32);
            this.datePicker_DoB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datePicker_DoB.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.datePicker_DoB.MinDate = new System.DateTime(1989, 1, 1, 0, 0, 0, 0);
            this.datePicker_DoB.Name = "datePicker_DoB";
            this.datePicker_DoB.Size = new System.Drawing.Size(116, 20);
            this.datePicker_DoB.TabIndex = 11;
            // 
            // btn_addNew
            // 
            this.btn_addNew.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_addNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addNew.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_addNew.Location = new System.Drawing.Point(799, 281);
            this.btn_addNew.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_addNew.Name = "btn_addNew";
            this.btn_addNew.Size = new System.Drawing.Size(84, 34);
            this.btn_addNew.TabIndex = 12;
            this.btn_addNew.Text = "Add New";
            this.btn_addNew.UseVisualStyleBackColor = true;
            this.btn_addNew.Click += new System.EventHandler(this.btn_addNew_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_delete.Location = new System.Drawing.Point(692, 281);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(84, 34);
            this.btn_delete.TabIndex = 13;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_reset.Location = new System.Drawing.Point(905, 281);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(84, 34);
            this.btn_reset.TabIndex = 14;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
            // 
            // btn_export
            // 
            this.btn_export.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_export.Location = new System.Drawing.Point(585, 360);
            this.btn_export.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(84, 34);
            this.btn_export.TabIndex = 15;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_import
            // 
            this.btn_import.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_import.Location = new System.Drawing.Point(692, 360);
            this.btn_import.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(84, 34);
            this.btn_import.TabIndex = 16;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            // 
            // text_parentName
            // 
            this.text_parentName.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_parentName.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_parentName.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_parentName.Location = new System.Drawing.Point(585, 78);
            this.text_parentName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.text_parentName.Name = "text_parentName";
            this.text_parentName.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_parentName.Size = new System.Drawing.Size(176, 20);
            this.text_parentName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(585, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(773, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "Parent Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(773, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "Mobile";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(773, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Home Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "Address";
            // 
            // lavel_idonMachine
            // 
            this.lavel_idonMachine.AutoSize = true;
            this.lavel_idonMachine.Font = new System.Drawing.Font("Verdana", 25F, System.Drawing.FontStyle.Bold);
            this.lavel_idonMachine.Location = new System.Drawing.Point(968, 92);
            this.lavel_idonMachine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lavel_idonMachine.Name = "lavel_idonMachine";
            this.lavel_idonMachine.Size = new System.Drawing.Size(90, 41);
            this.lavel_idonMachine.TabIndex = 24;
            this.lavel_idonMachine.Text = "000";
            // 
            // s_fname
            // 
            this.s_fname.DataPropertyName = "s_fname";
            this.s_fname.HeaderText = "First Name";
            this.s_fname.Name = "s_fname";
            this.s_fname.ReadOnly = true;
            // 
            // s_lname
            // 
            this.s_lname.DataPropertyName = "s_lname";
            this.s_lname.HeaderText = "Last Name";
            this.s_lname.Name = "s_lname";
            this.s_lname.ReadOnly = true;
            // 
            // s_dob
            // 
            this.s_dob.DataPropertyName = "s_dob";
            this.s_dob.HeaderText = "Birthday";
            this.s_dob.Name = "s_dob";
            this.s_dob.ReadOnly = true;
            // 
            // s_class
            // 
            this.s_class.DataPropertyName = "s_class";
            this.s_class.FillWeight = 50F;
            this.s_class.HeaderText = "s_class";
            this.s_class.Name = "s_class";
            this.s_class.ReadOnly = true;
            this.s_class.Visible = false;
            // 
            // class_class
            // 
            this.class_class.DataPropertyName = "class_class";
            this.class_class.FillWeight = 60F;
            this.class_class.HeaderText = "Class";
            this.class_class.Name = "class_class";
            this.class_class.ReadOnly = true;
            // 
            // s_parentmobile
            // 
            this.s_parentmobile.DataPropertyName = "s_parentmobile";
            this.s_parentmobile.HeaderText = "Mobile";
            this.s_parentmobile.Name = "s_parentmobile";
            this.s_parentmobile.ReadOnly = true;
            // 
            // s_idonmachine
            // 
            this.s_idonmachine.DataPropertyName = "s_idonmachine";
            this.s_idonmachine.FillWeight = 10.5141F;
            this.s_idonmachine.HeaderText = "s_id";
            this.s_idonmachine.Name = "s_idonmachine";
            this.s_idonmachine.ReadOnly = true;
            this.s_idonmachine.Visible = false;
            // 
            // s_homephone
            // 
            this.s_homephone.DataPropertyName = "s_homephone";
            this.s_homephone.HeaderText = "s_homephone";
            this.s_homephone.Name = "s_homephone";
            this.s_homephone.ReadOnly = true;
            this.s_homephone.Visible = false;
            // 
            // s_parentname
            // 
            this.s_parentname.DataPropertyName = "s_parentname";
            this.s_parentname.HeaderText = "s_parentname";
            this.s_parentname.Name = "s_parentname";
            this.s_parentname.ReadOnly = true;
            this.s_parentname.Visible = false;
            // 
            // s_address
            // 
            this.s_address.DataPropertyName = "s_address";
            this.s_address.HeaderText = "s_address";
            this.s_address.Name = "s_address";
            this.s_address.ReadOnly = true;
            this.s_address.Visible = false;
            // 
            // Uc_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lavel_idonMachine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_parentName);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_addNew);
            this.Controls.Add(this.datePicker_DoB);
            this.Controls.Add(this.text_homePhone);
            this.Controls.Add(this.btn_UpdateDetails);
            this.Controls.Add(this.text_Address);
            this.Controls.Add(this.text_ParentMobile);
            this.Controls.Add(this.cb_classSelect);
            this.Controls.Add(this.text_LastName);
            this.Controls.Add(this.text_FirstName);
            this.Controls.Add(this.text_mobile);
            this.Controls.Add(this.cb_class);
            this.Controls.Add(this.text_studentName);
            this.Controls.Add(this.gv_student);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Uc_student";
            this.Size = new System.Drawing.Size(1117, 727);
            this.Load += new System.EventHandler(this.Uc_student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_student)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView gv_student;
        private System.Windows.Forms.TextBox text_studentName;
        private System.Windows.Forms.ComboBox cb_class;
        private System.Windows.Forms.TextBox text_mobile;
        private System.Windows.Forms.TextBox text_FirstName;
        private System.Windows.Forms.TextBox text_LastName;
        private System.Windows.Forms.ComboBox cb_classSelect;
        private System.Windows.Forms.TextBox text_ParentMobile;
        private System.Windows.Forms.TextBox text_Address;
        private System.Windows.Forms.Button btn_UpdateDetails;
        private System.Windows.Forms.TextBox text_homePhone;
        private System.Windows.Forms.DateTimePicker datePicker_DoB;
        private System.Windows.Forms.Button btn_addNew;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.TextBox text_parentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lavel_idonMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_lname;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_dob;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_parentmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_idonmachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_homephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_parentname;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_address;
    }
}
