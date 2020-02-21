namespace AManager
{
    partial class Uc_classes
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
            this.GV_classes = new System.Windows.Forms.DataGridView();
            this.class_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btm_add = new System.Windows.Forms.Button();
            this.btm_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_teacherUpdate = new System.Windows.Forms.Button();
            this.Btn_teacherDelete = new System.Windows.Forms.Button();
            this.Btn_teacherAdd = new System.Windows.Forms.Button();
            this.GV_teachers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t_active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GV_classes)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_teachers)).BeginInit();
            this.SuspendLayout();
            // 
            // GV_classes
            // 
            this.GV_classes.AllowUserToAddRows = false;
            this.GV_classes.AllowUserToDeleteRows = false;
            this.GV_classes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV_classes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GV_classes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.class_id,
            this.t_id,
            this.class_class,
            this.class_floor,
            this.class_teacher,
            this.class_student});
            this.GV_classes.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GV_classes.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.GV_classes.Location = new System.Drawing.Point(6, 6);
            this.GV_classes.Name = "GV_classes";
            this.GV_classes.RowHeadersVisible = false;
            this.GV_classes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GV_classes.Size = new System.Drawing.Size(570, 347);
            this.GV_classes.TabIndex = 1;
            // 
            // class_id
            // 
            this.class_id.DataPropertyName = "class_id";
            this.class_id.HeaderText = "class_id";
            this.class_id.Name = "class_id";
            this.class_id.ReadOnly = true;
            this.class_id.Visible = false;
            // 
            // t_id
            // 
            this.t_id.DataPropertyName = "t_id";
            this.t_id.HeaderText = "t_id";
            this.t_id.Name = "t_id";
            this.t_id.ReadOnly = true;
            this.t_id.Visible = false;
            // 
            // class_class
            // 
            this.class_class.DataPropertyName = "class_class";
            this.class_class.HeaderText = "Class";
            this.class_class.Name = "class_class";
            this.class_class.ReadOnly = true;
            // 
            // class_floor
            // 
            this.class_floor.DataPropertyName = "class_floor";
            this.class_floor.HeaderText = "Floor";
            this.class_floor.Name = "class_floor";
            this.class_floor.ReadOnly = true;
            // 
            // class_teacher
            // 
            this.class_teacher.DataPropertyName = "class_teacher";
            this.class_teacher.HeaderText = "Teacher";
            this.class_teacher.Name = "class_teacher";
            this.class_teacher.ReadOnly = true;
            // 
            // class_student
            // 
            this.class_student.DataPropertyName = "class_student";
            this.class_student.HeaderText = "Students";
            this.class_student.Name = "class_student";
            this.class_student.ReadOnly = true;
            // 
            // btm_add
            // 
            this.btm_add.AutoSize = true;
            this.btm_add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btm_add.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btm_add.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btm_add.Location = new System.Drawing.Point(51, 384);
            this.btm_add.Name = "btm_add";
            this.btm_add.Size = new System.Drawing.Size(49, 28);
            this.btm_add.TabIndex = 2;
            this.btm_add.Text = "Add";
            this.btm_add.UseVisualStyleBackColor = true;
            this.btm_add.Click += new System.EventHandler(this.btm_add_Click);
            // 
            // btm_delete
            // 
            this.btm_delete.AutoSize = true;
            this.btm_delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btm_delete.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btm_delete.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btm_delete.Location = new System.Drawing.Point(219, 384);
            this.btm_delete.Name = "btm_delete";
            this.btm_delete.Size = new System.Drawing.Size(72, 28);
            this.btm_delete.TabIndex = 3;
            this.btm_delete.Text = "Delete";
            this.btm_delete.UseVisualStyleBackColor = true;
            this.btm_delete.Click += new System.EventHandler(this.btm_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.AutoSize = true;
            this.btn_update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_update.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_update.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_update.Location = new System.Drawing.Point(416, 384);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(77, 28);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
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
            this.tabControl1.Size = new System.Drawing.Size(893, 536);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GV_classes);
            this.tabPage1.Controls.Add(this.btn_update);
            this.tabPage1.Controls.Add(this.btm_delete);
            this.tabPage1.Controls.Add(this.btm_add);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Classes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_teacherUpdate);
            this.tabPage2.Controls.Add(this.Btn_teacherDelete);
            this.tabPage2.Controls.Add(this.Btn_teacherAdd);
            this.tabPage2.Controls.Add(this.GV_teachers);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Teachers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_teacherUpdate
            // 
            this.btn_teacherUpdate.AutoSize = true;
            this.btn_teacherUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_teacherUpdate.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_teacherUpdate.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_teacherUpdate.Location = new System.Drawing.Point(416, 384);
            this.btn_teacherUpdate.Name = "btn_teacherUpdate";
            this.btn_teacherUpdate.Size = new System.Drawing.Size(77, 28);
            this.btn_teacherUpdate.TabIndex = 7;
            this.btn_teacherUpdate.Text = "Update";
            this.btn_teacherUpdate.UseVisualStyleBackColor = true;
            this.btn_teacherUpdate.Click += new System.EventHandler(this.Btn_teacherUpdate_Click);
            // 
            // Btn_teacherDelete
            // 
            this.Btn_teacherDelete.AutoSize = true;
            this.Btn_teacherDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_teacherDelete.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_teacherDelete.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.Btn_teacherDelete.Location = new System.Drawing.Point(219, 384);
            this.Btn_teacherDelete.Name = "Btn_teacherDelete";
            this.Btn_teacherDelete.Size = new System.Drawing.Size(72, 28);
            this.Btn_teacherDelete.TabIndex = 6;
            this.Btn_teacherDelete.Text = "Delete";
            this.Btn_teacherDelete.UseVisualStyleBackColor = true;
            // 
            // Btn_teacherAdd
            // 
            this.Btn_teacherAdd.AutoSize = true;
            this.Btn_teacherAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_teacherAdd.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_teacherAdd.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.Btn_teacherAdd.Location = new System.Drawing.Point(51, 384);
            this.Btn_teacherAdd.Name = "Btn_teacherAdd";
            this.Btn_teacherAdd.Size = new System.Drawing.Size(49, 28);
            this.Btn_teacherAdd.TabIndex = 5;
            this.Btn_teacherAdd.Text = "Add";
            this.Btn_teacherAdd.UseVisualStyleBackColor = true;
            this.Btn_teacherAdd.Click += new System.EventHandler(this.Btn_teacherAdd_Click);
            // 
            // GV_teachers
            // 
            this.GV_teachers.AllowUserToAddRows = false;
            this.GV_teachers.AllowUserToDeleteRows = false;
            this.GV_teachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV_teachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GV_teachers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.t_name,
            this.t_class,
            this.t_student,
            this.t_active});
            this.GV_teachers.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "GVFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.GV_teachers.Font = global::AManager.Properties.Settings.Default.GVFont;
            this.GV_teachers.Location = new System.Drawing.Point(6, 6);
            this.GV_teachers.Name = "GV_teachers";
            this.GV_teachers.RowHeadersVisible = false;
            this.GV_teachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GV_teachers.Size = new System.Drawing.Size(570, 347);
            this.GV_teachers.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "t_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "t_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // t_name
            // 
            this.t_name.DataPropertyName = "t_name";
            this.t_name.HeaderText = "Name";
            this.t_name.Name = "t_name";
            this.t_name.ReadOnly = true;
            // 
            // t_class
            // 
            this.t_class.DataPropertyName = "t_class";
            this.t_class.HeaderText = "Classe";
            this.t_class.Name = "t_class";
            this.t_class.ReadOnly = true;
            // 
            // t_student
            // 
            this.t_student.DataPropertyName = "t_student";
            this.t_student.HeaderText = "Students";
            this.t_student.Name = "t_student";
            // 
            // t_active
            // 
            this.t_active.DataPropertyName = "t_active";
            this.t_active.HeaderText = "Active";
            this.t_active.Name = "t_active";
            this.t_active.ReadOnly = true;
            // 
            // Uc_classes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Uc_classes";
            this.Size = new System.Drawing.Size(893, 536);
            this.Load += new System.EventHandler(this.Uc_classes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GV_classes)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_teachers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView GV_classes;
        private System.Windows.Forms.Button btm_add;
        private System.Windows.Forms.Button btm_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_student;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView GV_teachers;
        private System.Windows.Forms.Button btn_teacherUpdate;
        private System.Windows.Forms.Button Btn_teacherDelete;
        private System.Windows.Forms.Button Btn_teacherAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_student;
        private System.Windows.Forms.DataGridViewTextBoxColumn t_active;
    }
}
