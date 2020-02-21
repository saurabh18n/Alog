namespace AManager
{
    partial class diag_editTeacher
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diag_editTeacher));
            this.text_teacherName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_teacherActive = new System.Windows.Forms.ComboBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_teacherName
            // 
            this.text_teacherName.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_teacherName.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_teacherName.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_teacherName.Location = new System.Drawing.Point(194, 54);
            this.text_teacherName.Name = "text_teacherName";
            this.text_teacherName.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_teacherName.Size = new System.Drawing.Size(209, 27);
            this.text_teacherName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Teacher Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label3.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label3.Location = new System.Drawing.Point(20, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Active";
            // 
            // CB_teacherActive
            // 
            this.CB_teacherActive.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_teacherActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_teacherActive.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.CB_teacherActive.FormattingEnabled = true;
            this.CB_teacherActive.Items.AddRange(new object[] {
            "Inactive",
            "Active"});
            this.CB_teacherActive.Location = new System.Drawing.Point(194, 134);
            this.CB_teacherActive.Name = "CB_teacherActive";
            this.CB_teacherActive.Size = new System.Drawing.Size(209, 26);
            this.CB_teacherActive.TabIndex = 5;
            // 
            // btn_Update
            // 
            this.btn_Update.AutoSize = true;
            this.btn_Update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Update.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_Update.Location = new System.Drawing.Point(238, 199);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(79, 30);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.AutoSize = true;
            this.btn_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cancel.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_cancel.Location = new System.Drawing.Point(71, 199);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(74, 30);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.button4_Click);
            // 
            // diag_editTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 296);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.CB_teacherActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_teacherName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "diag_editTeacher";
            this.Text = "Edit Teacher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_Update;
        public System.Windows.Forms.TextBox text_teacherName;
        public System.Windows.Forms.ComboBox CB_teacherActive;
    }
}