using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            hideAdminControls();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            labelUser.Text = userInfo.userName;
            Btn_Home_Click(null, null);
            
        }

        private void Btn_Home_Click(object sender, EventArgs e)
        {
            label_state.Text = "Home";
            Uc_dashboard _uc_Dashboard = new Uc_dashboard();
            if (panelContainer.Contains(_uc_Dashboard))
            {
                _uc_Dashboard.BringToFront();
            }
            else
            {
                panelContainer.Controls.Add(_uc_Dashboard);
                _uc_Dashboard.Dock = DockStyle.Fill;
                _uc_Dashboard.Show();
                _uc_Dashboard.BringToFront();
            }   
        }

        private void Btn_Student_Click(object sender, EventArgs e)
        {
            label_state.Text = "Student";
            Uc_student _uc_student = new Uc_student();
            if (panelContainer.Contains(_uc_student))
            {
                _uc_student.BringToFront();
                _uc_student.Width = panelContainer.Width;
                _uc_student.Height = panelContainer.Height;
            }
            else
            {
                panelContainer.Controls.Add(_uc_student);
                _uc_student.Dock = DockStyle.Fill;
                _uc_student.Show();
                _uc_student.BringToFront();
            }
        }

        private void Btn_messasing_Click(object sender, EventArgs e)
        {
            label_state.Text = "Messaging";
            Ucmessaging _Uc_messaging = new Ucmessaging();
            if (panelContainer.Contains(_Uc_messaging))
            {
                _Uc_messaging.BringToFront();
            }
            else
            {
                panelContainer.Controls.Add(_Uc_messaging);
                _Uc_messaging.Dock = DockStyle.Fill;
                _Uc_messaging.Show();
                _Uc_messaging.BringToFront();
            }
        }

        private void Btn_report_Click(object sender, EventArgs e)
        {
            label_state.Text = "Reports";
            Uc_report _Uc_report = new Uc_report();
            if (panelContainer.Contains(_Uc_report))
            {
                _Uc_report.BringToFront();
            }
            else
            {
                panelContainer.Controls.Add(_Uc_report);
                _Uc_report.Dock = DockStyle.Fill;
                _Uc_report.Show();
                _Uc_report.BringToFront();
            }

        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            label_state.Text = "Settings";
            Uc_settings _uc_Settings = new Uc_settings();
            if (panelContainer.Contains(_uc_Settings))
            {
                _uc_Settings.BringToFront();
            }
            else
            {
                panelContainer.Controls.Add(_uc_Settings);
                _uc_Settings.Dock = DockStyle.Fill;
                _uc_Settings.Show();
                _uc_Settings.BringToFront();
            }

        }

        private void hideAdminControls()
        {
            btn_settings.Visible = userInfo.isAdmin;
        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_classes_Click(object sender, EventArgs e)
        {
            label_state.Text = "Classes";
            Uc_classes _uc_classes = new Uc_classes();
            if (panelContainer.Contains(_uc_classes))
            {
                _uc_classes.BringToFront();
            }
            else
            {
                panelContainer.Controls.Add(_uc_classes);
                _uc_classes.Dock = DockStyle.Fill;
                _uc_classes.Show();
                _uc_classes.BringToFront();
            }

        }
    }
}
