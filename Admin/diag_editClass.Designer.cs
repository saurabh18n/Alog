namespace AManager
{
    partial class diag_editClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diag_editClass));
            this.text_class = new System.Windows.Forms.TextBox();
            this.text_floor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_teacher = new System.Windows.Forms.ComboBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_class
            // 
            this.text_class.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_class.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_class.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_class.Location = new System.Drawing.Point(194, 27);
            this.text_class.Name = "text_class";
            this.text_class.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_class.Size = new System.Drawing.Size(121, 27);
            this.text_class.TabIndex = 0;
            // 
            // text_floor
            // 
            this.text_floor.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_floor.DataBindings.Add(new System.Windows.Forms.Binding("RightToLeft", global::AManager.Properties.Settings.Default, "TextRighttoLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.text_floor.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.text_floor.Location = new System.Drawing.Point(194, 80);
            this.text_floor.Name = "text_floor";
            this.text_floor.RightToLeft = global::AManager.Properties.Settings.Default.TextRighttoLeft;
            this.text_floor.Size = new System.Drawing.Size(121, 27);
            this.text_floor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label2.Location = new System.Drawing.Point(41, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Floor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label3.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.label3.Location = new System.Drawing.Point(41, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Class Teacher";
            // 
            // CB_teacher
            // 
            this.CB_teacher.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_teacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_teacher.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.CB_teacher.FormattingEnabled = true;
            this.CB_teacher.Location = new System.Drawing.Point(194, 134);
            this.CB_teacher.Name = "CB_teacher";
            this.CB_teacher.Size = new System.Drawing.Size(215, 26);
            this.CB_teacher.TabIndex = 5;
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
            // diag_editClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 296);
            this.ControlBox = false;
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.CB_teacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_floor);
            this.Controls.Add(this.text_class);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "diag_editClass";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button btn_Update;
        public System.Windows.Forms.TextBox text_class;
        public System.Windows.Forms.TextBox text_floor;
        public System.Windows.Forms.ComboBox CB_teacher;
    }
}