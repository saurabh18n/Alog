namespace Alog
{
    partial class Form1
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
            this.ipTextbox = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.DisconnetBtn = new System.Windows.Forms.Button();
            this.StatusText = new System.Windows.Forms.Label();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Edit = new System.Windows.Forms.Button();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.getalluser = new System.Windows.Forms.Button();
            this.getUSerDetails = new System.Windows.Forms.Button();
            this.textEnroll = new System.Windows.Forms.TextBox();
            this.sdkversion = new System.Windows.Forms.Button();
            this.textbackup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_enum = new System.Windows.Forms.TextBox();
            this.text_name = new System.Windows.Forms.TextBox();
            this.text_pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipTextbox
            // 
            this.ipTextbox.Location = new System.Drawing.Point(265, 12);
            this.ipTextbox.Name = "ipTextbox";
            this.ipTextbox.Size = new System.Drawing.Size(137, 20);
            this.ipTextbox.TabIndex = 0;
            this.ipTextbox.Text = "10.0.0.55";
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(456, 12);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(56, 20);
            this.portText.TabIndex = 1;
            this.portText.Text = "4370";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(576, 10);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 4;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // result
            // 
            this.result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.result.Location = new System.Drawing.Point(12, 42);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.result.Size = new System.Drawing.Size(781, 476);
            this.result.TabIndex = 5;
            // 
            // DisconnetBtn
            // 
            this.DisconnetBtn.Location = new System.Drawing.Point(702, 10);
            this.DisconnetBtn.Name = "DisconnetBtn";
            this.DisconnetBtn.Size = new System.Drawing.Size(75, 23);
            this.DisconnetBtn.TabIndex = 6;
            this.DisconnetBtn.Text = "Disconnet";
            this.DisconnetBtn.UseVisualStyleBackColor = true;
            this.DisconnetBtn.Click += new System.EventHandler(this.DisconnetBtn_Click);
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusText.Location = new System.Drawing.Point(12, 10);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(131, 25);
            this.StatusText.TabIndex = 7;
            this.StatusText.Text = "Disconnected";
            // 
            // Btn_Download
            // 
            this.Btn_Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Download.Location = new System.Drawing.Point(1033, 353);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(75, 23);
            this.Btn_Download.TabIndex = 8;
            this.Btn_Download.Text = "Download ATT";
            this.Btn_Download.UseVisualStyleBackColor = true;
            this.Btn_Download.Click += new System.EventHandler(this.Btn_Download_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Delete.Location = new System.Drawing.Point(987, 423);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.Btn_Delete.TabIndex = 9;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Edit.Location = new System.Drawing.Point(1033, 175);
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.Btn_Edit.TabIndex = 11;
            this.Btn_Edit.Text = "Edit";
            this.Btn_Edit.UseVisualStyleBackColor = true;
            this.Btn_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // Btn_Add
            // 
            this.Btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Add.Location = new System.Drawing.Point(1033, 77);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(75, 23);
            this.Btn_Add.TabIndex = 10;
            this.Btn_Add.Text = "Add";
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // getalluser
            // 
            this.getalluser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getalluser.Location = new System.Drawing.Point(1033, 217);
            this.getalluser.Name = "getalluser";
            this.getalluser.Size = new System.Drawing.Size(75, 23);
            this.getalluser.TabIndex = 12;
            this.getalluser.Text = "getAlluser";
            this.getalluser.UseVisualStyleBackColor = true;
            this.getalluser.Click += new System.EventHandler(this.getalluser_Click);
            // 
            // getUSerDetails
            // 
            this.getUSerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getUSerDetails.Location = new System.Drawing.Point(1033, 261);
            this.getUSerDetails.Name = "getUSerDetails";
            this.getUSerDetails.Size = new System.Drawing.Size(75, 23);
            this.getUSerDetails.TabIndex = 13;
            this.getUSerDetails.Text = "getUser";
            this.getUSerDetails.UseVisualStyleBackColor = true;
            this.getUSerDetails.Click += new System.EventHandler(this.getUSerDetails_Click);
            // 
            // textEnroll
            // 
            this.textEnroll.Location = new System.Drawing.Point(829, 425);
            this.textEnroll.Name = "textEnroll";
            this.textEnroll.Size = new System.Drawing.Size(46, 20);
            this.textEnroll.TabIndex = 14;
            // 
            // sdkversion
            // 
            this.sdkversion.Location = new System.Drawing.Point(1033, 304);
            this.sdkversion.Name = "sdkversion";
            this.sdkversion.Size = new System.Drawing.Size(75, 23);
            this.sdkversion.TabIndex = 15;
            this.sdkversion.Text = "Get Sdk Ver";
            this.sdkversion.UseVisualStyleBackColor = true;
            this.sdkversion.Click += new System.EventHandler(this.sdkversion_Click);
            // 
            // textbackup
            // 
            this.textbackup.Location = new System.Drawing.Point(904, 425);
            this.textbackup.Name = "textbackup";
            this.textbackup.Size = new System.Drawing.Size(46, 20);
            this.textbackup.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(901, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "11/12/13";
            // 
            // text_enum
            // 
            this.text_enum.Location = new System.Drawing.Point(809, 79);
            this.text_enum.Name = "text_enum";
            this.text_enum.Size = new System.Drawing.Size(66, 20);
            this.text_enum.TabIndex = 18;
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(888, 79);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(66, 20);
            this.text_name.TabIndex = 19;
            // 
            // text_pass
            // 
            this.text_pass.Location = new System.Drawing.Point(960, 79);
            this.text_pass.Name = "text_pass";
            this.text_pass.Size = new System.Drawing.Size(66, 20);
            this.text_pass.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(816, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(901, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(973, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 530);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_pass);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.text_enum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbackup);
            this.Controls.Add(this.sdkversion);
            this.Controls.Add(this.textEnroll);
            this.Controls.Add(this.getUSerDetails);
            this.Controls.Add(this.getalluser);
            this.Controls.Add(this.Btn_Edit);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.Btn_Delete);
            this.Controls.Add(this.Btn_Download);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.DisconnetBtn);
            this.Controls.Add(this.result);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.ipTextbox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alog_test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTextbox;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button DisconnetBtn;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Edit;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Button getalluser;
        private System.Windows.Forms.Button getUSerDetails;
        private System.Windows.Forms.TextBox textEnroll;
        private System.Windows.Forms.Button sdkversion;
        private System.Windows.Forms.TextBox textbackup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_enum;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.TextBox text_pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

