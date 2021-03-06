﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;

namespace AManager
{
    public delegate void updateRG();
    public partial class Uc_dashboard : UserControl
    {
        private bool inEditMode = false;

        System.Timers.Timer updateTimer;

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

        private void Uc_dashboard_Load(object sender, EventArgs e)
        {
            CB_Colntrols.SelectedIndex = 0;            
            setControlProperties();
            panel_serviceStatus.Resize += Panel_serviceStatus_Resize;
            Task.Run(() => updateDashboard()).ConfigureAwait(false);
        }

        private void Uc_dashboard_LostFocus(object sender, EventArgs e)
        {
            Console.WriteLine("Lost");
        }

        private void updateDashboard()
        {
            updateradiul();
            updateTimer = new System.Timers.Timer(Properties.Settings.Default.refreshInterval * 1000);
            updateTimer.AutoReset = true;
            updateTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e)=> {
                Console.WriteLine("Updating Dashboard");
                updateTimer.Stop();
                try
                {
                    updateradiul();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
                finally
                {
                    updateTimer.Start();
                }
            };
            updateTimer.Start();
        }

        private void Panel_serviceStatus_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("Hit");
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

        private void updateradiul()
        {
            if (this.InvokeRequired)
            {
                updateRG update = new updateRG(updateradiul);
                this.Invoke(update);
            }
            else
            {
                using (DataTable dt = new DataTable())
                {
                    using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.connection))
                    {
                        using (SqlCommand command = new SqlCommand("sp_get_dashboard_data", myConn))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            try
                            {
                                myConn.Open();
                                dt.Load(command.ExecuteReader());
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("SqlError Getting Dashboard Update " + ex.Message);
                            }

                        }
                    } 

                    if(dt.Rows.Count > 0)
                    {
                        ChartSeries series = classPresentChart.Series[0];
                        series.Name = "Attandence";
                        series.XAxis.ValueType = ChartValueType.Category;

                        int totalstudent = 0;
                        int presentStudent = 0;
                        series.Points.Clear();
                        foreach (DataRow Row in dt.Rows)
                        {
                            totalstudent += (int)Row[1];
                            presentStudent += (int)Row[2];                           
                            series.Points.Add((string)Row[0], ((int)Row[2]*100)/(int)Row[1]);
                        }
                        series.Type = ChartSeriesType.Column;
                        series.Text = series.Name;
                        RG_student.MaximumValue = totalstudent * 10;
                        RG_student.MinimumValue = 0;
                        RG_student.MajorDifference = totalstudent;
                        RG_student.Value = presentStudent;
                        RG_student.Ranges[0].StartValue = 0;
                        RG_student.Ranges[0].EndValue = presentStudent * 10;
                    }
                }

                
            }
        }

    }
}
