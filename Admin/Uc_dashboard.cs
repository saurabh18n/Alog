using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;

namespace AManager
{
    public delegate void updateRG();
    public partial class Uc_dashboard : UserControl
    {
        private bool inEditMode = false;
        CustomRenderer custom;
        
        public Uc_dashboard()
        {
            InitializeComponent();
            this.RG_student.GaugeArcColor = ColorTranslator.FromHtml("#ededed");
            this.RG_student.GaugeLableColor = ColorTranslator.FromHtml("#8cc34b");
            this.RG_student.Ranges[0].Color = ColorTranslator.FromHtml("#8cc34b");
            custom = new CustomRenderer(this.RG_student);
            this.RG_student.Renderer = custom;

        }

        private async void Uc_dashboard_Load(object sender, EventArgs e)
        {
            CB_Colntrols.SelectedIndex = 0;            
            setControlProperties();
            InitializeChartData();
            panel_serviceStatus.Resize += Panel_serviceStatus_Resize;
            await Task.Run(() => updateradiul()).ConfigureAwait(false);
        }

        private void Panel_serviceStatus_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("Hit");
        }

        private void updateradiul()
        {
            if (this.InvokeRequired)
            {
                updateRG update = new updateRG(updateradiul);
                this.Invoke(update);
            }
            else
            {
                int presentStudent = 258;
                RG_student.MaximumValue = 302 * 10;
                RG_student.MinimumValue = 0;
                RG_student.MajorDifference = 302;               
                RG_student.Value = presentStudent;
                RG_student.Ranges[0].StartValue = 0;
                RG_student.Ranges[0].EndValue = presentStudent * 10;                
            }
        }

        private void Btn_layoutEditor_Click(object sender, EventArgs e)
        {
            if (inEditMode)
            {
                inEditMode = false;
                btn_layoutEditor.Text = "Edit";
                enableShowHideControls(false);
                changeMoveCursor(false);
                ControlExtension.Draggable(RG_student, false);
                ControlExtension.Draggable(panel_serviceStatus, false);
                ControlExtension.Draggable(classPresentChart, false);
                saveControlsProperty();

            }
            else
            {
                inEditMode = true;
                btn_layoutEditor.Text = "Save";
                enableShowHideControls(true);
                changeMoveCursor(true);
                ControlExtension.Draggable(RG_student, true);               
                ControlExtension.Draggable(panel_serviceStatus, true);
                ControlExtension.Draggable(classPresentChart, true);                
            }

        }

        private void enableShowHideControls(bool newState)
        {
            Btn_addControl.Visible = newState;
            Btn_removeControl.Visible = newState;
            CB_Colntrols.Visible = newState;
        }

        private void changeMoveCursor(bool newState)
        {
            if (newState)
            {
                RG_student.Cursor = System.Windows.Forms.Cursors.Hand;
                panel_serviceStatus.Cursor = System.Windows.Forms.Cursors.Hand;

            }
            else
            {
                RG_student.Cursor = System.Windows.Forms.Cursors.Default;
                panel_serviceStatus.Cursor = System.Windows.Forms.Cursors.Default;
            }
            
        }

        private void saveControlsProperty()
        {
            Properties.Settings.Default.Loc_RG_student = RG_student.Location;
            Properties.Settings.Default.Loc_pann_service = panel_serviceStatus.Location;
            Properties.Settings.Default.Display_RG_student = RG_student.Visible;
            Properties.Settings.Default.Display_Pann_service = panel_serviceStatus.Visible;
            Properties.Settings.Default.Display_classwisechart = classPresentChart.Visible;
            Properties.Settings.Default.loc_classwisechart = classPresentChart.Location;
            Properties.Settings.Default.Save();
        }

        private void setControlProperties()
        {
            RG_student.Location = Properties.Settings.Default.Loc_RG_student;
            RG_student.Visible = Properties.Settings.Default.Display_RG_student;
            panel_serviceStatus.Location = Properties.Settings.Default.Loc_pann_service;
            panel_serviceStatus.Visible = Properties.Settings.Default.Display_Pann_service;
            classPresentChart.Visible = Properties.Settings.Default.Display_classwisechart;
            classPresentChart.Location = Properties.Settings.Default.loc_classwisechart;

        }

        private void Btn_addControl_Click(object sender, EventArgs e)
        {
            if(CB_Colntrols.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Control");
            }
            else
            {
                if (CB_Colntrols.SelectedIndex == 1) // Attandence
                {
                    RG_student.Visible = true;

                }
                else if (CB_Colntrols.SelectedIndex == 2)
                {
                    classPresentChart.Visible = true;
                }
                else if (CB_Colntrols.SelectedIndex == 3) 
                {
                    panel_serviceStatus.Visible = true;
                }   

        }
        }

        private void Btn_removeControl_Click(object sender, EventArgs e)
        {
            if (CB_Colntrols.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Control");
            }
            else
            {
                if (CB_Colntrols.SelectedIndex == 1) // Attandence
                {
                    RG_student.Visible = false;

                }
                else if (CB_Colntrols.SelectedIndex == 2)
                {
                    classPresentChart.Visible = false;

                }
                else if (CB_Colntrols.SelectedIndex == 3)
                {
                    panel_serviceStatus.Visible = false;

                }


            }
        }
        private void InitializeChartData()
        {
            ChartSeries series = classPresentChart.Series[0];
            series.Name = "Attandence";
            series.XAxis.ValueType = ChartValueType.Category;
            series.Points.Add("1", 80);
            series.Points.Add("1B", 70);
            series.Points.Add("2A", 60);
            series.Points.Add("2", 80);
            series.Points.Add("3A", 72);
            series.Points.Add("3", 40);
            series.Points.Add("5", 65);
            series.Points.Add("5B", 75);
            series.Type = ChartSeriesType.Column;            
            series.Text = series.Name;
        }
    }
}
