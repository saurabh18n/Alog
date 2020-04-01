namespace AManager
{
    partial class Uc_dashboard
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
            Syncfusion.Windows.Forms.Chart.ChartSeries chartSeries1 = new Syncfusion.Windows.Forms.Chart.ChartSeries();
            Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo chartCustomShapeInfo1 = new Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo();
            Syncfusion.Windows.Forms.Chart.ChartLineInfo chartLineInfo1 = new Syncfusion.Windows.Forms.Chart.ChartLineInfo();
            Syncfusion.Windows.Forms.Gauge.Range range1 = new Syncfusion.Windows.Forms.Gauge.Range();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.classPresentChart = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.panel_serviceStatus = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Btn_removeControl = new System.Windows.Forms.Button();
            this.btn_layoutEditor = new System.Windows.Forms.Button();
            this.Btn_addControl = new System.Windows.Forms.Button();
            this.RG_student = new Syncfusion.Windows.Forms.Gauge.RadialGauge();
            this.CB_Colntrols = new System.Windows.Forms.ComboBox();
            this.panelContainer.SuspendLayout();
            this.panel_serviceStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContainer.Controls.Add(this.classPresentChart);
            this.panelContainer.Controls.Add(this.panel_serviceStatus);
            this.panelContainer.Controls.Add(this.Btn_removeControl);
            this.panelContainer.Controls.Add(this.btn_layoutEditor);
            this.panelContainer.Controls.Add(this.Btn_addControl);
            this.panelContainer.Controls.Add(this.RG_student);
            this.panelContainer.Controls.Add(this.CB_Colntrols);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(907, 552);
            this.panelContainer.TabIndex = 2;
            // 
            // classPresentChart
            // 
            this.classPresentChart.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, System.Drawing.Color.Black, System.Drawing.Color.Transparent);
            this.classPresentChart.ChartArea.AdjustPlotAreaMargins = Syncfusion.Windows.Forms.Chart.ChartSetMode.None;
            this.classPresentChart.ChartArea.AutoScale = true;
            this.classPresentChart.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent);
            this.classPresentChart.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.classPresentChart.ChartArea.CursorReDraw = false;
            this.classPresentChart.ChartInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(212)))), ((int)(((byte)(235))))));
            this.classPresentChart.CustomPalette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(164)))), ((int)(((byte)(51))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(125)))), ((int)(((byte)(187))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(96)))), ((int)(((byte)(48))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(83)))), ((int)(((byte)(54))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(106))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(107)))), ((int)(((byte)(66)))))};
            this.classPresentChart.DataSourceName = "[none]";
            this.classPresentChart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.classPresentChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(48)))), ((int)(((byte)(133)))));
            this.classPresentChart.IsWindowLess = false;
            // 
            // 
            // 
            this.classPresentChart.Legend.Location = new System.Drawing.Point(291, 75);
            this.classPresentChart.Legend.Visible = false;
            this.classPresentChart.Localize = null;
            this.classPresentChart.Location = new System.Drawing.Point(427, 78);
            this.classPresentChart.Name = "classPresentChart";
            this.classPresentChart.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Custom;
            this.classPresentChart.PrimaryXAxis.DrawGrid = false;
            this.classPresentChart.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classPresentChart.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classPresentChart.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.classPresentChart.PrimaryXAxis.Margin = true;
            this.classPresentChart.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classPresentChart.PrimaryXAxis.Title = "Class";
            this.classPresentChart.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText;
            this.classPresentChart.PrimaryYAxis.ForceZero = true;
            this.classPresentChart.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classPresentChart.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classPresentChart.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.classPresentChart.PrimaryYAxis.Margin = true;
            this.classPresentChart.PrimaryYAxis.Range = new Syncfusion.Windows.Forms.Chart.MinMaxInfo(0D, 100D, 100D);
            this.classPresentChart.PrimaryYAxis.RangeType = Syncfusion.Windows.Forms.Chart.ChartAxisRangeType.Set;
            this.classPresentChart.PrimaryYAxis.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.classPresentChart.PrimaryYAxis.Title = "Present %";
            this.classPresentChart.PrimaryYAxis.TitleColor = System.Drawing.SystemColors.ControlText;
            chartSeries1.FancyToolTip.ResizeInsideSymbol = true;
            chartSeries1.Name = "Default0";
            chartSeries1.Resolution = 0D;
            chartSeries1.StackingGroup = "Default Group";
            chartSeries1.Style.AltTagFormat = "";
            chartSeries1.Style.DisplayText = true;
            chartSeries1.Style.DrawTextShape = false;
            chartSeries1.Style.TextOrientation = Syncfusion.Windows.Forms.Chart.ChartTextOrientation.Down;
            chartLineInfo1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            chartLineInfo1.Color = System.Drawing.SystemColors.ControlText;
            chartLineInfo1.DashPattern = null;
            chartLineInfo1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartLineInfo1.Width = 1F;
            chartCustomShapeInfo1.Border = chartLineInfo1;
            chartCustomShapeInfo1.Color = System.Drawing.SystemColors.HighlightText;
            chartCustomShapeInfo1.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square;
            chartSeries1.Style.TextShape = chartCustomShapeInfo1;
            chartSeries1.Text = "Default0";
            this.classPresentChart.Series.Add(chartSeries1);
            this.classPresentChart.Size = new System.Drawing.Size(400, 212);
            this.classPresentChart.TabIndex = 12;
            // 
            // 
            // 
            this.classPresentChart.Title.Name = "Default";
            this.classPresentChart.VisualTheme = "";
            // 
            // panel_serviceStatus
            // 
            this.panel_serviceStatus.AutoSize = true;
            this.panel_serviceStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_serviceStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_serviceStatus.Controls.Add(this.label4);
            this.panel_serviceStatus.Controls.Add(this.label3);
            this.panel_serviceStatus.Controls.Add(this.label2);
            this.panel_serviceStatus.Controls.Add(this.label1);
            this.panel_serviceStatus.Controls.Add(this.pictureBox4);
            this.panel_serviceStatus.Controls.Add(this.pictureBox3);
            this.panel_serviceStatus.Controls.Add(this.pictureBox2);
            this.panel_serviceStatus.Controls.Add(this.pictureBox1);
            this.panel_serviceStatus.Location = new System.Drawing.Point(180, 34);
            this.panel_serviceStatus.Name = "panel_serviceStatus";
            this.panel_serviceStatus.Size = new System.Drawing.Size(130, 176);
            this.panel_serviceStatus.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15F);
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(62, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "5 MS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15F);
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(62, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "OK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15F);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(62, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "OK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(62, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "OK";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::AManager.Properties.Resources.machine;
            this.pictureBox4.Location = new System.Drawing.Point(3, 133);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(53, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AManager.Properties.Resources.service_1;
            this.pictureBox3.Location = new System.Drawing.Point(3, 87);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AManager.Properties.Resources.service_2;
            this.pictureBox2.Location = new System.Drawing.Point(3, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AManager.Properties.Resources.SQL;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Btn_removeControl
            // 
            this.Btn_removeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_removeControl.AutoSize = true;
            this.Btn_removeControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_removeControl.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_removeControl.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.Btn_removeControl.Location = new System.Drawing.Point(834, 17);
            this.Btn_removeControl.Name = "Btn_removeControl";
            this.Btn_removeControl.Size = new System.Drawing.Size(22, 23);
            this.Btn_removeControl.TabIndex = 11;
            this.Btn_removeControl.Text = "-";
            this.Btn_removeControl.UseVisualStyleBackColor = true;
            this.Btn_removeControl.Visible = false;
            this.Btn_removeControl.Click += new System.EventHandler(this.Btn_removeControl_Click);
            // 
            // btn_layoutEditor
            // 
            this.btn_layoutEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_layoutEditor.AutoSize = true;
            this.btn_layoutEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_layoutEditor.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btn_layoutEditor.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.btn_layoutEditor.Location = new System.Drawing.Point(864, 17);
            this.btn_layoutEditor.Name = "btn_layoutEditor";
            this.btn_layoutEditor.Size = new System.Drawing.Size(38, 23);
            this.btn_layoutEditor.TabIndex = 10;
            this.btn_layoutEditor.Text = "Edit";
            this.btn_layoutEditor.UseVisualStyleBackColor = true;
            this.btn_layoutEditor.Click += new System.EventHandler(this.Btn_layoutEditor_Click);
            // 
            // Btn_addControl
            // 
            this.Btn_addControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_addControl.AutoSize = true;
            this.Btn_addControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_addControl.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Btn_addControl.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.Btn_addControl.Location = new System.Drawing.Point(801, 17);
            this.Btn_addControl.Name = "Btn_addControl";
            this.Btn_addControl.Size = new System.Drawing.Size(26, 23);
            this.Btn_addControl.TabIndex = 1;
            this.Btn_addControl.Text = "+";
            this.Btn_addControl.UseVisualStyleBackColor = true;
            this.Btn_addControl.Visible = false;
            this.Btn_addControl.Click += new System.EventHandler(this.Btn_addControl_Click);
            // 
            // RG_student
            // 
            this.RG_student.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.RG_student.ArcThickness = 6F;
            this.RG_student.BackgroundGradientEndColor = System.Drawing.Color.Transparent;
            this.RG_student.BackgroundGradientStartColor = System.Drawing.Color.Transparent;
            this.RG_student.Cursor = System.Windows.Forms.Cursors.Default;
            this.RG_student.EnableCustomNeedles = false;
            this.RG_student.FillColor = System.Drawing.Color.DarkGray;
            this.RG_student.FrameThickness = 1;
            this.RG_student.GaugeArcColor = System.Drawing.Color.DarkGray;
            this.RG_student.GaugeLabel = "Student Present";
            this.RG_student.GaugeLableFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RG_student.GaugeValueFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RG_student.InnerFrameGradientEndColor = System.Drawing.Color.Transparent;
            this.RG_student.InnerFrameGradientStartColor = System.Drawing.Color.Transparent;
            this.RG_student.Location = new System.Drawing.Point(0, 0);
            this.RG_student.MajorDifference = 1F;
            this.RG_student.MajorTickMarkHeight = 0;
            this.RG_student.Margin = new System.Windows.Forms.Padding(0);
            this.RG_student.MaximumValue = 2000F;
            this.RG_student.MinimumSize = new System.Drawing.Size(125, 125);
            this.RG_student.MinorInnerLinesHeight = 0;
            this.RG_student.MinorTickMarkHeight = 0;
            this.RG_student.Name = "RG_student";
            this.RG_student.OuterFrameGradientEndColor = System.Drawing.Color.Transparent;
            this.RG_student.OuterFrameGradientStartColor = System.Drawing.Color.Transparent;
            range1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            range1.EndValue = 1100F;
            range1.Height = 7;
            range1.InRange = true;
            range1.Name = "GaugeRange1";
            range1.RangePlacement = Syncfusion.Windows.Forms.Gauge.TickPlacement.OutSide;
            range1.StartValue = 0F;
            this.RG_student.Ranges.Add(range1);
            this.RG_student.ShowGaugeValue = true;
            this.RG_student.ShowNeedle = false;
            this.RG_student.ShowScaleLabel = false;
            this.RG_student.ShowTicks = true;
            this.RG_student.Size = new System.Drawing.Size(150, 150);
            this.RG_student.TabIndex = 8;
            this.RG_student.ThemeStyle.ArcThickness = 0F;
            this.RG_student.ThemeStyle.InnerFrameThickness = 0;
            this.RG_student.TickPlacement = Syncfusion.Windows.Forms.Gauge.TickPlacement.OutSide;
            this.RG_student.Value = 500F;
            // 
            // CB_Colntrols
            // 
            this.CB_Colntrols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Colntrols.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::AManager.Properties.Settings.Default, "labelFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CB_Colntrols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Colntrols.Font = global::AManager.Properties.Settings.Default.labelFont;
            this.CB_Colntrols.FormattingEnabled = true;
            this.CB_Colntrols.Items.AddRange(new object[] {
            "Select",
            "Attandence",
            "Classwise Attandence",
            "Service Status"});
            this.CB_Colntrols.Location = new System.Drawing.Point(646, 17);
            this.CB_Colntrols.Name = "CB_Colntrols";
            this.CB_Colntrols.Size = new System.Drawing.Size(146, 21);
            this.CB_Colntrols.TabIndex = 0;
            this.CB_Colntrols.Visible = false;
            // 
            // Uc_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelContainer);
            this.Name = "Uc_dashboard";
            this.Size = new System.Drawing.Size(907, 552);
            this.Load += new System.EventHandler(this.Uc_dashboard_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panel_serviceStatus.ResumeLayout(false);
            this.panel_serviceStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.ComboBox CB_Colntrols;
        private System.Windows.Forms.Button Btn_addControl;
        private System.Windows.Forms.Panel panelContainer;
        private Syncfusion.Windows.Forms.Gauge.RadialGauge RG_student;
        private System.Windows.Forms.Panel panel_serviceStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_layoutEditor;
        private System.Windows.Forms.Button Btn_removeControl;
        private Syncfusion.Windows.Forms.Chart.ChartControl classPresentChart;
    }
}
