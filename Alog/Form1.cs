using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace Alog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisconnetBtn.Enabled = false;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        CZKEMClass myCZKEMClass;
        Boolean bIsConnected;
        int iMachineNumber = 1;
        int errorcode;
        //public zkemkeeper.CZKEM deviceConnection = new zkemkeeper.CZKEM();
        private void Connect_Click(object sender, EventArgs e)
        {
            result.AppendText(DateTime.Now.ToString() + "   " + "Application Started.");
            result.AppendText(Environment.NewLine);
            myCZKEMClass = new CZKEMClass();
            try
            {
                bIsConnected = myCZKEMClass.Connect_Net(ipTextbox.Text.Trim(), Convert.ToInt32(portText.Text));   // 4370 is port no of attendance machine
                if (bIsConnected == true)
                {
                    Connect.Enabled = false;
                    DisconnetBtn.Enabled = true;
                    StatusText.Text = "Connected";
                    result.AppendText(DateTime.Now.ToString() + "   " + "Device Connected Successfully");
                    result.AppendText(Environment.NewLine);
                    //Download and display data =========================================================================================================

                    //result.AppendText(DateTime.Now.ToString() + "   " + "Data Download End");
                    //result.AppendText(Environment.NewLine);
                    //register realtime event handler ====================================================================================================
                    result.AppendText(DateTime.Now.ToString() + "   " + "Registerinig for realtime In/Out update");
                    result.AppendText(Environment.NewLine);
                    //if (myCZKEMClass.RegEvent(1, 65535))
                    //{
                    //    myCZKEMClass.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(handleAtt);
                    //    myCZKEMClass.OnConnected += new zkemkeeper._IZKEMEvents_OnConnectedEventHandler(HandleConnect);
                    //    myCZKEMClass.OnDisConnected += new zkemkeeper._IZKEMEvents_OnDisConnectedEventHandler(HandleConnect);
                    //    result.AppendText(DateTime.Now.ToString() + "   " + "Registration Successfull");
                    //    result.AppendText(Environment.NewLine);
                    //    result.AppendText(DateTime.Now.ToString() + "   " + "Please try test finger to realtime test");
                    //    result.AppendText(Environment.NewLine);
                    //}
                    //else
                    //{
                    //    result.AppendText(DateTime.Now.ToString() + "   " + "Registration Not Successfull");
                    //    result.AppendText(Environment.NewLine);
                    //}



                }
                else
                {
                    result.AppendText(DateTime.Now.ToString() + "   " + "Device Not Conneted");
                    result.AppendText(Environment.NewLine);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void handleAtt(string EnrollNumber, int IsInValid, int AttState, int VerificationMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            result.AppendText(DateTime.Now.ToString() + "   Number " + EnrollNumber + " Verified on Realtime");
            result.AppendText(Environment.NewLine);

        }

        private void HandleConnect()
        {
            MessageBox.Show("Device Connected");

        }

        private void DisconnetBtn_Click(object sender, EventArgs e)
        {
            myCZKEMClass.Disconnect();
            DisconnetBtn.Enabled = false;
            Connect.Enabled = true;
            StatusText.Text = "Disconnected";
        }

        private void Btn_Download_Click(object sender, EventArgs e)
        {
            result.AppendText(DateTime.Now.ToString() + "   " + "Trying to download Log");
            result.AppendText(Environment.NewLine);
            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;
            int idwErrorCode = 0;
            int iGLCount = 0;
            try
            {
                myCZKEMClass.EnableDevice(iMachineNumber, false);//disable the device
                if (myCZKEMClass.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    while (myCZKEMClass.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                    {
                        string line;
                        line = iGLCount.ToString() + " | " + sdwEnrollNumber + " | " + idwVerifyMode.ToString() + " | " + idwInOutMode.ToString() + " | " + idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString() + " | " + idwWorkcode.ToString();
                        iGLCount++;
                        result.AppendText(line);
                        result.AppendText(Environment.NewLine);
                    }
                }
                else
                {
                    myCZKEMClass.GetLastError(ref idwErrorCode);

                    if (idwErrorCode != 0)
                    {
                        result.AppendText("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString());
                        result.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        result.AppendText("No data from terminal returns!");
                        result.AppendText(Environment.NewLine);
                    }
                }

            }
            catch (Exception ex)
            {
                result.AppendText("Error" + ex.ToString());
                result.AppendText(Environment.NewLine);
            }
            finally
            {
                myCZKEMClass.EnableDevice(iMachineNumber, true);
            }


        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {            
            try
            {
                myCZKEMClass.EnableDevice(iMachineNumber, false);
                int enrollnumber =Convert.ToInt32(textEnroll.Text);                
                if(myCZKEMClass.SSR_DeleteEnrollDataExt(1, textEnroll.Text,Convert.ToInt32(textbackup.Text)))
                    // Index of the fingerprint The value ranges from 0 to 9. It this case, the device also checks
                    //whether the user has other fingerprints or passwords. If no, the device deletes the user. When the 
                    //value is 0, the device deletes the password. The device also checks whether the user has fingerprint data.
                    //If no, the device deletes the user.
                    //When the value is 11 or 13, the device deletes all fingerprint data of the user.When the value is 12, 
                    //the device deletes the user(including all fingerprints, card numbers and passwords of the user).
                {
                    myCZKEMClass.RefreshData(1);
                    result.AppendText("User Delete Successfull -- SSR_DeleteEnrollDataExt");
                    result.AppendText(Environment.NewLine);
                }else
                {
                    myCZKEMClass.GetLastError(ref errorcode);
                    result.AppendText("User Delete Error code " + errorcode.ToString());
                    result.AppendText(Environment.NewLine);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                myCZKEMClass.EnableDevice(iMachineNumber, true);
            }


        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if(myCZKEMClass.SSR_SetUserInfo(1,text_enum.Text,text_name.Text,text_pass.Text,0,true))
                {
                    result.AppendText(DateTime.Now.ToString() +  " User Added Successfully");
                    result.AppendText(Environment.NewLine);
                }
                else
                {
                    result.AppendText(DateTime.Now.ToString() + " User Added Error");
                    result.AppendText(Environment.NewLine);
                    int errorcode = 99;
                    myCZKEMClass.GetLastError(errorcode);
                    result.AppendText(errorcode.ToString());
                }

            }
            catch (Exception ex)
            {
                result.AppendText(ex.Message);
                result.AppendText(Environment.NewLine);
            }
                    }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void getUSerDetails_Click(object sender, EventArgs e)
        {
            int verifyStyle = 0;
            byte res = new byte();
            string name = "";
            string pass = "";
            int priv = 0;
            bool en = false;
            if (myCZKEMClass.SSR_GetUserInfo(1,textEnroll.Text,out name,out pass,out priv,out en))
            {
                result.AppendText("Details for Enrollment number " + Convert.ToInt32(textEnroll.Text));
                result.AppendText(Environment.NewLine);
                result.AppendText("User Name " + name);
                result.AppendText(Environment.NewLine);
                result.AppendText("Password " + pass);
                result.AppendText(Environment.NewLine);
                result.AppendText("Privilage " + priv.ToString());
                result.AppendText(Environment.NewLine);
                result.AppendText("Enabled " + en.ToString());
                result.AppendText(Environment.NewLine);

                if (myCZKEMClass.GetUserInfoEx(1, Convert.ToInt32(textEnroll.Text), out verifyStyle, out res))
                {
                    result.AppendText("Verify Style " + verifyStyle.ToString());
                    result.AppendText(Environment.NewLine);
                    result.AppendText("Extra data " + res.ToString());
                    result.AppendText(Environment.NewLine);

                }
                else
                {
                    myCZKEMClass.GetLastError(errorcode);
                    result.AppendText("Error getting user details in Ex " + errorcode.ToString());
                    result.AppendText(Environment.NewLine);

                } 
            }
            else
            {
                myCZKEMClass.GetLastError(errorcode);
                result.AppendText("Error getting user details " + errorcode.ToString());
                result.AppendText(Environment.NewLine);

            }

        }

        private void getalluser_Click(object sender, EventArgs e)
        {
            string dwEnrollNumber = "";
            String name = "";
            string password = "";
            int privilege = 0;
            bool enabled = false;
            int i = 0;
            try
            {
                myCZKEMClass.EnableDevice(iMachineNumber, false);
                if (myCZKEMClass.ReadAllUserID(1))
                {
                    if (myCZKEMClass.ReadAllTemplate(1))
                    {
                        while (myCZKEMClass.SSR_GetAllUserInfo(1, out dwEnrollNumber,out name,out password,out privilege,out enabled))
                        {
                            string line = i.ToString() + "     " + dwEnrollNumber.ToString() + "     " + name;
                            result.AppendText(line);
                            result.AppendText(Environment.NewLine);
                            i++;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                result.AppendText(ex.Message);
            }finally
            {
                myCZKEMClass.EnableDevice(iMachineNumber, true);
            }
            
            

        }

        private void sdkversion_Click(object sender, EventArgs e)
        {
            string version = "";
            try
            {
                if (myCZKEMClass.GetDeviceStrInfo(1,Convert.ToInt32(textEnroll.Text), out version))
                {
                    result.AppendText(version);
                    result.AppendText(Environment.NewLine);
                }
                else
                {
                    myCZKEMClass.GetLastError(ref errorcode);
                    result.AppendText("Error Getting Version " + errorcode);
                    result.AppendText(Environment.NewLine);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
