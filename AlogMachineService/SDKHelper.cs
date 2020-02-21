using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AlogService
{    
    public class SDKHelper
    {

        public zkemkeeper.CZKEMClass devCon = new zkemkeeper.CZKEMClass();
        private static bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private static int iMachineNumber = 1;
        private static int idwErrorCode = 0;
        Log logger;
        public SDKHelper(Log log)
        {
            logger = log;
        }

        #region UserBioTypeClass

        private string _biometricType = string.Empty;
        private string _biometricVersion = string.Empty;

        private SupportBiometricType _supportBiometricType = new SupportBiometricType();

        public const string PersBioTableName = "Pers_Biotemplate";

        public const string PersBioTableFields = "*";

        public SupportBiometricType supportBiometricType
        {
            get { return _supportBiometricType; }
        }

        public string biometricType
        {
            get { return _biometricType; }
        }

        public class Employee
        {
            public string pin { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public int privilege { get; set; }
            public string cardNumber { get; set; }
        }

        public class SupportBiometricType
        {
            public bool fp_available { get; set; }
            public bool face_available { get; set; }
            public bool fingerVein_available { get; set; }
            public bool palm_available { get; set; }
        }

        public class BioTemplate
        {
            /// <summary>
            /// is valid,0:invalid,1:valid,default=1
            /// </summary>
            private int validFlag = 1;
            public virtual int valid_flag
            {
                get { return validFlag; }
                set { validFlag = value; }
            }

            /// <summary>
            /// is duress,0:not duress,1:duress,default=0
            /// </summary>
            public virtual int is_duress { get; set; }

            /// <summary>
            /// Biometric Type
            /// 0： General
            /// 1： Finger Printer
            /// 2： Face
            /// 3： Voiceprint
            /// 4： Iris
            /// 5： Retina
            /// 6： Palm prints
            /// 7： FingerVein
            /// 8： Palm Vein
            /// </summary>
            public virtual int bio_type { get; set; }

            /// <summary>
            /// template version
            /// </summary>
            public virtual string version { get; set; }

            /// <summary>
            /// data format
            /// ZK\ISO\ANSI 
            /// 0： ZK
            /// 1： ISO
            /// 2： ANSI
            /// </summary>
            public virtual int data_format { get; set; }

            /// <summary>
            /// template no
            /// </summary>
            public virtual int template_no { get; set; }

            /// <summary>
            /// template index
            /// </summary>
            public virtual int template_no_index { get; set; }

            /// <summary>
            /// template data
            /// </summary>
            public virtual string template_data { get; set; }

            /// <summary>
            /// pin
            /// </summary>
            public virtual string pin { get; set; }
        }

        public class BioType
        {
            public string name { get; set; }
            public int value { get; set; }

            public override string ToString()
            {
                return name;
            }
        }
        #endregion

        #region ConnectDevice

        public static bool IsConnected()
        {
            return bIsConnected;
        }

        public static void SetIsConnected(bool state)
        {
            bIsConnected = state;
        }

        public bool Connect(string ip, string port)
        {
            int idwErrorCode = 0;
            //devCon.SetCommPassword(Convert.ToInt32(commKey)); Set Comkey is use of password is required
            if (devCon.Connect_Net(ip, Convert.ToInt32(port)) == true)
            {
                SetIsConnected(true);
                sta_getBiometricType();
                logger.Write($"Device Connection to {ip} : {port} Connected Successfully");
                if(devCon.RegEvent(iMachineNumber, 65535))
                {
                    logger.Write("Realtime Event Registration Successfull");
                    return true;
                }
                else
                {
                    devCon.GetLastError(ref idwErrorCode);
                    logger.Write($"Unable to Register to realtime updates, ErrorCode {idwErrorCode.ToString()}");
                }
                return false;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                logger.Write($"Unable to connect the device,ErrorCode {idwErrorCode.ToString()}");
                return false;
            }
        }

        public void DisConnect()
        {
            if (IsConnected() == true)
            {
                devCon.Disconnect();
                sta_UnRegRealTime();
            }
        }

        #endregion

        #region DeviceType

        public int GetDeviceType()
        {
            string sPlatform = "";
            int iFaceDevice = 0;

            if (devCon.IsTFTMachine(iMachineNumber))
            {
                devCon.GetDeviceInfo(iMachineNumber, 75, ref iFaceDevice);
                devCon.GetPlatform(iMachineNumber, ref sPlatform);
                if (sPlatform.Contains("ZMM"))
                {
                    return 1;//new firmware device
                }
                else if (iFaceDevice == 1)
                {
                    return 2;//face serial
                }
                else
                {
                    return 3;//color device
                }
            }
            else
            {
                return 4;//black&whith device
            }
            
        }

        #endregion

        #region RealTimeEvent

        public void sta_UnRegRealTime()
        {
            this.devCon.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(devCon_OnFinger);
            this.devCon.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(devCon_OnVerify);
            this.devCon.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(devCon_OnAttTransactionEx);
            this.devCon.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(devCon_OnFingerFeature);
            this.devCon.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(devCon_OnDeleteTemplate);
            this.devCon.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(devCon_OnNewUser);
            this.devCon.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(devCon_OnHIDNum);
            this.devCon.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(devCon_OnAlarm);
            this.devCon.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(devCon_OnDoor);
            this.devCon.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(devCon_OnEnrollFingerEx);
            this.devCon.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(devCon_OnWriteCard);
            this.devCon.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(devCon_OnEmptyCard);
            this.devCon.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(devCon_OnHIDNum);
            this.devCon.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(devCon_OnAttTransaction);
            this.devCon.OnKeyPress -= new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(devCon_OnKeyPress);
            this.devCon.OnEnrollFinger -= new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(devCon_OnEnrollFinger);

        }

        public int sta_RegRealTime()
        {
            if (IsConnected() == false)
            {                
                return -1024;
            }
            //checking if connected
            int ret = 0;

            if (devCon.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            {
                //common interface
                this.devCon.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(devCon_OnFinger);
                this.devCon.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(devCon_OnVerify);
                this.devCon.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(devCon_OnFingerFeature);
                this.devCon.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(devCon_OnDeleteTemplate);
                this.devCon.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(devCon_OnNewUser);
                this.devCon.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(devCon_OnHIDNum);
                this.devCon.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(devCon_OnAlarm);
                this.devCon.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(devCon_OnDoor);

                //only for color device
                this.devCon.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(devCon_OnAttTransactionEx);
                this.devCon.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(devCon_OnEnrollFingerEx);

                //only for black&white device
                this.devCon.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(devCon_OnAttTransaction);
                this.devCon.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(devCon_OnWriteCard);
                this.devCon.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(devCon_OnEmptyCard);
                this.devCon.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(devCon_OnKeyPress);
                this.devCon.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(devCon_OnEnrollFinger);


                ret = 1;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    ////lblOutputInfo.Items.Add("*RegEvent failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    ////lblOutputInfo.Items.Add("*No data from terminal returns!");
                }
            }
            return ret;
        }

        //When you are enrolling your finger,this event will be triggered.
        void devCon_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                //gRealEventListBox.Items.Add("Enroll finger succeed. UserID=" + EnrollNumber.ToString() + "...FingerIndex=" + FingerIndex.ToString());
            }
            else
            {
                //gRealEventListBox.Items.Add("Enroll finger failed. Result=" + ActionResult.ToString());
            }
            throw new NotImplementedException();
        }

        //Door sensor event
        void devCon_OnDoor(int EventType)
        {
            //gRealEventListBox.Items.Add("Door opened" + "...EventType=" + EventType.ToString());

            throw new NotImplementedException();
        }

        //When the dismantling machine or duress alarm occurs, trigger this event.
        void devCon_OnAlarm(int AlarmType, int EnrollNumber, int Verified)
        {
            //gRealEventListBox.Items.Add("Alarm triggered" + "...AlarmType=" + AlarmType.ToString() + "...EnrollNumber=" + EnrollNumber.ToString() + "...Verified=" + Verified.ToString());

            throw new NotImplementedException();
        }

        //When you swipe a card to the device, this event will be triggered to show you the card number.
        void devCon_OnHIDNum(int CardNumber)
        {
            //gRealEventListBox.Items.Add("Card event" + "...Cardnumber=" + CardNumber.ToString());

            throw new NotImplementedException();
        }

        //When you have enrolled a new user,this event will be triggered.
        void devCon_OnNewUser(int EnrollNumber)
        {
            //gRealEventListBox.Items.Add("Enroll a　new user" + "...UserID=" + EnrollNumber.ToString());

            throw new NotImplementedException();
        }

        //When you have deleted one one fingerprint template,this event will be triggered.
        void devCon_OnDeleteTemplate(int EnrollNumber, int FingerIndex)
        {
            //gRealEventListBox.Items.Add("Delete a finger template" + "...UserID=" + EnrollNumber.ToString() + "..FingerIndex=" + FingerIndex.ToString());

            throw new NotImplementedException();
        }

        //When you have enrolled your finger,this event will be triggered and return the quality of the fingerprint you have enrolled
        void devCon_OnFingerFeature(int Score)
        {
            //gRealEventListBox.Items.Add("Press finger score=" + Score.ToString());

            throw new NotImplementedException();
        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered,only for color device
        void devCon_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;

            //gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

            throw new NotImplementedException();
        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered,only for black%white device
        private void devCon_OnAttTransaction(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;
            //gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber.ToString() + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

            throw new NotImplementedException();
        }

        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        void devCon_OnVerify(int UserID)
        {
            if (UserID != -1)
            {
                //gRealEventListBox.Items.Add("User fingerprint verified... UserID=" + UserID.ToString());
            }
            else
            {
                //gRealEventListBox.Items.Add("Failed to verify... ");
            }

            throw new NotImplementedException();
        }

        //When you place your finger on sensor of the device,this event will be triggered
        void devCon_OnFinger()
        {
            //gRealEventListBox.Items.Add("OnFinger event ");

            throw new NotImplementedException();
        }

        //When you have written into the Mifare card ,this event will be triggered.
        void devCon_OnWriteCard(int iEnrollNumber, int iActionResult, int iLength)
        {
            if (iActionResult == 0)
            {
                //gRealEventListBox.Items.Add("Write Mifare Card OK" + "...EnrollNumber=" + iEnrollNumber.ToString() + "...TmpLength=" + iLength.ToString());
            }
            else
            {
                //gRealEventListBox.Items.Add("...Write Failed");
            }
        }

        //When you have emptyed the Mifare card,this event will be triggered.
        void devCon_OnEmptyCard(int iActionResult)
        {
            if (iActionResult == 0)
            {
                //gRealEventListBox.Items.Add("Empty Mifare Card OK...");
            }
            else
            {
                //gRealEventListBox.Items.Add("Empty Failed...");
            }
        }

        //When you press the keypad,this event will be triggered.
        void devCon_OnKeyPress(int iKey)
        {
            //gRealEventListBox.Items.Add("RTEvent OnKeyPress Has been Triggered, Key: " + iKey.ToString());
        }

        //When you are enrolling your finger,this event will be triggered.
        void devCon_OnEnrollFinger(int EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                //gRealEventListBox.Items.Add("Enroll finger succeed. UserID=" + EnrollNumber + "...FingerIndex=" + FingerIndex.ToString());
            }
            else
            {
                //gRealEventListBox.Items.Add("Enroll finger failed. Result=" + ActionResult.ToString());
            }
            throw new NotImplementedException();
        }

        #endregion

        #region UserMng

        #region UserInfo

        public bool DeleteUser(string enrollNumber)
        {
            
            int idwErrorCode = 0;
            int iBackupNumber = 12;
            bool returnStatus = false;

            if (devCon.SSR_DeleteEnrollDataExt(iMachineNumber, enrollNumber, iBackupNumber))
            {
                devCon.RefreshData(iMachineNumber); //the data in the device should be refreshed
                returnStatus = true;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                logger.Write($"User delete error for user enroll number {enrollNumber} error code {idwErrorCode}");
                returnStatus = false;
            }

            return returnStatus;
        }

        public int sta_DelUserTmp()
        {
            //if (IsConnected() == false)
            //{
            //    ////lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (cbUseID.Text.Trim() == "" || cbFingerIndex.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //int idwErrorCode = 0;
            //string sUserID = cbUseID.Text.Trim();
            //int iFingerIndex = Convert.ToInt32(cbFingerIndex.Text.Trim());

            //if (devCon.SSR_DelUserTmpExt(iMachineNumber, sUserID, iFingerIndex))
            //{
            //    devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
            //    //lblOutputInfo.Items.Add("SSR_DelUserTmpExt,UserID:" + sUserID + " FingerIndex:" + iFingerIndex.ToString());
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}

            return 1;
        }

        public int sta_OnlineEnroll()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (txtUserID.Text.Trim() == "" || cbFingerIndex.Text.Trim() == "" || cbFlag.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //int iPIN2Width = 0;
            //int iIsABCPinEnable = 0;
            //int iT9FunOn = 0;
            //string strTemp = "";
            //devCon.GetSysOption(iMachineNumber, "~PIN2Width", out strTemp );
            //iPIN2Width = Convert.ToInt32(strTemp);
            //devCon.GetSysOption(iMachineNumber, "~IsABCPinEnable", out strTemp);
            //iIsABCPinEnable = Convert.ToInt32(strTemp);
            //devCon.GetSysOption(iMachineNumber, "~T9FunOn",out strTemp);
            //iT9FunOn = Convert.ToInt32(strTemp);

            /*
            devCon.GetDeviceInfo(iMachineNumber, 76, ref iPIN2Width);
            devCon.GetDeviceInfo(iMachineNumber, 77, ref iIsABCPinEnable);
            devCon.GetDeviceInfo(iMachineNumber, 78, ref iT9FunOn);
             */

            //if (txtUserID.Text.Length > iPIN2Width)
            //{
            //    //lblOutputInfo.Items.Add("*User ID error! The max length is " + iPIN2Width.ToString());
            //    return -1022;
            //}

            //if (iIsABCPinEnable == 0 || iT9FunOn == 0)
            //{
            //    if (txtUserID.Text.Substring(0, 1) == "0")
            //    {
            //        //lblOutputInfo.Items.Add("*User ID error! The first letter can not be as 0");
            //        return -1022;
            //    }

            //    foreach (char tempchar in txtUserID.Text.ToCharArray())
            //    {
            //        if (!(char.IsDigit(tempchar)))
            //        {
            //            //lblOutputInfo.Items.Add("*User ID error! User ID only support digital");
            //            return -1022;
            //        }
            //    }
            //}

            //int idwErrorCode = 0;
            //string sUserID = txtUserID.Text.Trim();
            //int iFingerIndex = Convert.ToInt32(cbFingerIndex.Text.Trim());
            //int iFlag = Convert.ToInt32(cbFlag.Text.Trim());

            //devCon.CancelOperation();
            ////If the specified index of user's templates has existed ,delete it first
            //devCon.SSR_DelUserTmpExt(iMachineNumber, sUserID, iFingerIndex);
            //if (devCon.StartEnrollEx(sUserID, iFingerIndex, iFlag))
            //{
            //    //lblOutputInfo.Items.Add("Start to Enroll a new User,UserID=" + sUserID + " FingerID=" + iFingerIndex.ToString() + " Flag=" + iFlag.ToString());
            //    if (devCon.StartIdentify())
            //    {
            //        //lblOutputInfo.Items.Add("Enroll a new User,UserID" + sUserID);
            //    }
            //    ;//After enrolling templates,you should let the device into the 1:N verification condition
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}

            return 1;
        }

        public bool AddUser(string sEnrollNumber,string sName)
        {
            #region Oldfun
            //int iPIN2Width = 0;
            //int iIsABCPinEnable = 0;
            //int iT9FunOn = 0;
            //string strTemp = "";
            //devCon.GetSysOption(iMachineNumber, "~PIN2Width", out strTemp);
            //iPIN2Width = Convert.ToInt32(strTemp);
            //devCon.GetSysOption(iMachineNumber, "~IsABCPinEnable", out strTemp);
            //iIsABCPinEnable = Convert.ToInt32(strTemp);
            //devCon.GetSysOption(iMachineNumber, "~T9FunOn", out strTemp);
            //iT9FunOn = Convert.ToInt32(strTemp);
            /*
            devCon.GetDeviceInfo(iMachineNumber, 76, ref iPIN2Width);
            devCon.GetDeviceInfo(iMachineNumber, 77, ref iIsABCPinEnable);
            devCon.GetDeviceInfo(iMachineNumber, 78, ref iT9FunOn);
            */

            //if (txtUserID.Text.Length > iPIN2Width)
            //{
            //    //lblOutputInfo.Items.Add("*User ID error! The max length is " + iPIN2Width.ToString());
            //    return -1022;
            //}

            //if (iIsABCPinEnable == 0 || iT9FunOn == 0)
            //{
            //    if (txtUserID.Text.Substring(0,1) == "0")
            //    {
            //        //lblOutputInfo.Items.Add("*User ID error! The first letter can not be as 0");
            //        return -1022;
            //    }

            //    foreach (char tempchar in txtUserID.Text.ToCharArray())
            //    {
            //        if (!(char.IsDigit(tempchar)))
            //        {
            //            //lblOutputInfo.Items.Add("*User ID error! User ID only support digital");
            //            return -1022;
            //        }
            //    }   
            //}
            #endregion

            int idwErrorCode = 0;
            bool returnCode = false;

            devCon.EnableDevice(iMachineNumber, false);
            devCon.SetStrCardNumber(sEnrollNumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
            if (devCon.SSR_SetUserInfo(iMachineNumber, sEnrollNumber, sName, "1234", 0, true))//upload the user's information(card number included)
            {
                returnCode =  true;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                logger.Write($"Writing user to machine Error for user {sEnrollNumber} {sName} And Error code {idwErrorCode}");
                returnCode  = false;
            }
            devCon.RefreshData(iMachineNumber); //the data in the device should be refreshed
            devCon.EnableDevice(iMachineNumber, true);
            return returnCode;
        }

        public bool isUserExist(string sEnrollNumber)
        {
            //int iPIN2Width = 0;
            //string strTemp = "";
            //devCon.GetSysOption(iMachineNumber, "~PIN2Width", out strTemp);
            //iPIN2Width = Convert.ToInt32(strTemp);

            //if (txtUserID.Text.Length > iPIN2Width)
            //{
            //    //lblOutputInfo.Items.Add("*User ID error! The max length is " + iPIN2Width.ToString());
            //    return -1022;
            //}

            int idwErrorCode = 0;
            int iPrivilege = 0;
            string strName = "";
            string strPassword = "";
            bool bEnabled = false;
            bool flag = false;

            devCon.EnableDevice(iMachineNumber, false);
            if (!devCon.SSR_GetUserInfo(iMachineNumber, sEnrollNumber , out strName, out strPassword, out iPrivilege, out bEnabled))//upload the user's information(card number included)
            {
                logger.Write($"User {sEnrollNumber} does not exists on machine.");
                flag  = false;                
            }
            else
            {
                logger.Write($"User {sEnrollNumber} exists on machine.");
                flag = true;
            }
            devCon.EnableDevice(iMachineNumber, true);
            return flag;
        }

        public int sta_GetUserVerifyStyle()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (cbUserID7.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input user ID first!");
            //    return -1023;
            //}

            //int iVerifyStyle = 0;
            //byte bReserved;
            //string sUserID = cbUserID7.Text.Trim();

            //if (devCon.GetUserInfoEx(iMachineNumber, Convert.ToInt32(sUserID), out iVerifyStyle, out bReserved))
            //{
            //    switch (iVerifyStyle)
            //    {
            //        case 0: cbVerifyStyle.SelectedIndex = 0; break;
            //        case 128: cbVerifyStyle.SelectedIndex = 1; break;
            //        case 129: cbVerifyStyle.SelectedIndex = 2; break;
            //        case 130: cbVerifyStyle.SelectedIndex = 3; break;
            //        case 131: cbVerifyStyle.SelectedIndex = 4; break;
            //        case 132: cbVerifyStyle.SelectedIndex = 5; break;
            //        case 133: cbVerifyStyle.SelectedIndex = 6; break;
            //        case 134: cbVerifyStyle.SelectedIndex = 7; break;
            //        case 135: cbVerifyStyle.SelectedIndex = 8; break;
            //        case 136: cbVerifyStyle.SelectedIndex = 9; break;
            //        case 137: cbVerifyStyle.SelectedIndex = 10; break;
            //        case 138: cbVerifyStyle.SelectedIndex = 11; break;
            //        case 139: cbVerifyStyle.SelectedIndex = 12; break;
            //        case 140: cbVerifyStyle.SelectedIndex = 13; break;
            //        case 141: cbVerifyStyle.SelectedIndex = 14; break;
            //        case 142: cbVerifyStyle.SelectedIndex = 15; break;
            //    }
            //    //lblOutputInfo.Items.Add("Get user verify style successfully");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            
            /*
            if (devCon.GetUserVerifyStyle(1, sUserID, out iVerifyStyle, out bReserved))
            {
                switch (iVerifyStyle)
                {
                    case 0: cbVerifyStyle.SelectedIndex = 0; break;
                    case 128: cbVerifyStyle.SelectedIndex = 1; break;
                    case 129: cbVerifyStyle.SelectedIndex = 2; break;
                    case 130: cbVerifyStyle.SelectedIndex = 3; break;
                    case 131: cbVerifyStyle.SelectedIndex = 4; break;
                    case 132: cbVerifyStyle.SelectedIndex = 5; break;
                    case 133: cbVerifyStyle.SelectedIndex = 6; break;
                    case 134: cbVerifyStyle.SelectedIndex = 7; break;
                    case 135: cbVerifyStyle.SelectedIndex = 8; break;
                    case 136: cbVerifyStyle.SelectedIndex = 9; break;
                    case 137: cbVerifyStyle.SelectedIndex = 10; break;
                    case 138: cbVerifyStyle.SelectedIndex = 11; break;
                    case 139: cbVerifyStyle.SelectedIndex = 12; break;
                    case 140: cbVerifyStyle.SelectedIndex = 13; break;
                    case 141: cbVerifyStyle.SelectedIndex = 14; break;
                    case 142: cbVerifyStyle.SelectedIndex = 15; break;
                }
                //lblOutputInfo.Items.Add("Get user verify style successfully");
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }
            */

            ////lblOutputInfo.Items.Add("[func GetUserVerifyStyle]Temporarily unsupported");
            return 1;
        }

        public int sta_SetUserVerifyStyle()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (cbUserID7.Text.Trim() == "" || cbVerifyStyle.Text == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input the UserID or VerifyStyle!");
            //    return -1023;
            //}
            //int idwErrorCode = 0;

            //byte bReserved = 0;
            //string sUserID = cbUserID7.Text.Trim();

            //int iVerifyStyle = 0;
            //switch (cbVerifyStyle.SelectedIndex)
            //{
            //    case 0: iVerifyStyle = 0; break;
            //    case 1: iVerifyStyle = 128; break;
            //    case 2: iVerifyStyle = 129; break;
            //    case 3: iVerifyStyle = 130; break;
            //    case 4: iVerifyStyle = 131; break;
            //    case 5: iVerifyStyle = 132; break;
            //    case 6: iVerifyStyle = 133; break;
            //    case 7: iVerifyStyle = 134; break;
            //    case 8: iVerifyStyle = 135; break;
            //    case 9: iVerifyStyle = 136; break;
            //    case 10: iVerifyStyle = 137; break;
            //    case 11: iVerifyStyle = 138; break;
            //    case 12: iVerifyStyle = 139; break;
            //    case 13: iVerifyStyle = 140; break;
            //    case 14: iVerifyStyle = 141; break;
            //    case 15: iVerifyStyle = 142; break;
            //}

            //if (devCon.SetUserInfoEx(iMachineNumber, Convert.ToInt32(sUserID), iVerifyStyle, ref bReserved))
            //{
            //    //lblOutputInfo.Items.Add("Set verify style successfully!");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            /*
            if (devCon.SetUserVerifyStyle(1, sUserID, iVerifyStyle, ref bReserved))
            {
                //lblOutputInfo.Items.Add("Set verify style successfully!");
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }
            */
            ////lblOutputInfo.Items.Add("[func SetUserVerifyStyle]Temporarily unsupported");
            

            return 1;
        }

        #endregion

        #region UesrFP
        public int sta_GetAllUserFPInfo()
        {
            if (IsConnected() == false)
            {                
                return -1024;
            }

            string sEnrollNumber = "";
            bool bEnabled = false;
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            string sFPTmpData = "";
            string sCardnumber = "";
            int idwFingerIndex = 0;
            int iFlag = 0;
            int iFPTmpLength = 0;
            int i = 0;
            int num = 0;
            int iFpCount = 0;
            int index = 0;
            int xx = 1;
            devCon.EnableDevice(iMachineNumber, false);
            devCon.ReadAllUserID(iMachineNumber);//read all the user information to the memory  except fingerprint Templates
            devCon.ReadAllTemplate(iMachineNumber);//read all the users' fingerprint templates to the memory
            while (devCon.SSR_GetAllUserInfo(iMachineNumber, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
            {
                devCon.GetStrCardNumber(out sCardnumber);//get the card number from the memory             

                //lvUserInfo.Items.Add(sEnrollNumber);

                if (bEnabled == true)
                {
                    //lvUserInfo.Items[index].SubItems.Add("true");
                }
                else
                {
                 //   lvUserInfo.Items[index].SubItems.Add("false");
                }

                //lvUserInfo.Items[index].SubItems.Add(sName);
                //lvUserInfo.Items[index].SubItems.Add(sCardnumber);
                //lvUserInfo.Items[index].SubItems.Add(sPassword);

                i = 0;
                xx = 1;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (devCon.GetUserTmpExStr(iMachineNumber, sEnrollNumber, idwFingerIndex, out iFlag, out sFPTmpData, out iFPTmpLength))//get the corresponding templates string and length from the memory
                    {
                        if (xx == 1)
                        {
                            //lvUserInfo.Items[index].SubItems.Add(idwFingerIndex.ToString());
                            //lvUserInfo.Items[index].SubItems.Add(iFlag.ToString());
                            //lvUserInfo.Items[index].SubItems.Add(sFPTmpData);
                            //lvUserInfo.Items[index].SubItems.Add(iPrivilege.ToString());
                        }
                        else
                        {
                            //lvUserInfo.Items.Add(sEnrollNumber);
                            if (bEnabled == true)
                            {
                                //lvUserInfo.Items[index].SubItems.Add("true");
                            }
                            else
                            {
                                //lvUserInfo.Items[index].SubItems.Add("false");
                            }

                            //lvUserInfo.Items[index].SubItems.Add(sName);
                            //lvUserInfo.Items[index].SubItems.Add(sCardnumber);
                            //lvUserInfo.Items[index].SubItems.Add(sPassword);
                            //lvUserInfo.Items[index].SubItems.Add(idwFingerIndex.ToString());
                            //lvUserInfo.Items[index].SubItems.Add(iFlag.ToString());
                            //lvUserInfo.Items[index].SubItems.Add(sFPTmpData);
                            //lvUserInfo.Items[index].SubItems.Add(iPrivilege.ToString());
                        }

                        index++;
                        xx = 0;
                        iFpCount++;
                    }
                    else
                    {
                        i++;
                    }
                }

                if (i == 10)
                {
                    //lvUserInfo.Items[index].SubItems.Add("");
                    //lvUserInfo.Items[index].SubItems.Add("");
                    //lvUserInfo.Items[index].SubItems.Add("");
                    //lvUserInfo.Items[index].SubItems.Add(iPrivilege.ToString());
                    index++;
                }
                num++;
                
            }
            ////lblOutputInfo.Items.Add("Download user count : " + num.ToString() + " ,  fingerprint count : " + iFpCount.ToString());
            devCon.EnableDevice(iMachineNumber, true);
            return 1;
        }

        public int sta_SetAllUserFPInfo()
        {
            if (IsConnected() == false)
            {
                ////lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            //if (lvUserInfo.Items.Count == 0)
            //{
            //    //lblOutputInfo.Items.Add("*There is no data can upload!");
            //    return -1023;
            //}

            string sEnrollNumber = "";
            string sEnabled = "";
            bool bEnabled = false;

            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            string sFPTmpData = "";
            string sCardnumber = "";
            int idwFingerIndex = 0;
            string sdwFingerIndex = "";
            int iFlag = 0;
            string sFlag = "";
            int num = 0;
            devCon.EnableDevice(iMachineNumber, false);
            //for (int i = 0; i < lvUserInfo.Items.Count; i++)
            //{
            //    sEnrollNumber = lvUserInfo.Items[i].SubItems[0].Text;
            //    sEnabled = lvUserInfo.Items[i].SubItems[1].Text;
            //    if (sEnabled == "true")
            //    {
            //        bEnabled = true;
            //    }
            //    else
            //    {
            //        bEnabled = false;
            //    }
            //    sName = lvUserInfo.Items[i].SubItems[2].Text;
            //    sCardnumber = lvUserInfo.Items[i].SubItems[3].Text;
            //    sPassword = lvUserInfo.Items[i].SubItems[4].Text;
            //    sdwFingerIndex = lvUserInfo.Items[i].SubItems[5].Text;
            //    sFlag = lvUserInfo.Items[i].SubItems[6].Text;
            //    sFPTmpData = lvUserInfo.Items[i].SubItems[7].Text;
            //    iPrivilege = Convert.ToInt32(lvUserInfo.Items[i].SubItems[8].Text);

            //    if (sCardnumber != "" && sCardnumber != "0")
            //    {
            //        devCon.SetStrCardNumber(sCardnumber);
            //    }
            //    if (devCon.SSR_SetUserInfo(iMachineNumber, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the device
            //    {
            //        if (sdwFingerIndex != "" && sFlag != "" && sFPTmpData != "")
            //        {
            //            idwFingerIndex = Convert.ToInt32(sdwFingerIndex);
            //            iFlag = Convert.ToInt32(sFlag);
            //            devCon.SetUserTmpExStr(iMachineNumber, sEnrollNumber, idwFingerIndex, iFlag, sFPTmpData);//upload templates information to the device
            //        }
            //        num++;
            //        prgSta.Value = num % 100;
            //    }
            //    else
            //    {
            //        devCon.GetLastError(ref idwErrorCode);
            //        //lblOutputInfo.Items.Add("*Upload user " + sEnrollNumber + " error,ErrorCode=!" + idwErrorCode.ToString());
            //        //devCon.EnableDevice(iMachineNumber, true);
            //        //return -1022;
            //    }

            //}
            devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
            devCon.EnableDevice(iMachineNumber, true);
            return 1;
        }

        //public int sta_batch_SetAllUserFPInfo()
        //{
        //    //if (IsConnected() == false)
        //    //{
        //    //    //lblOutputInfo.Items.Add("*Please connect first!");
        //    //    return -1024;
        //    //}

        //    //if (lvUserInfo.Items.Count == 0)
        //    //{
        //    //    //lblOutputInfo.Items.Add("*There is no data can upload!");
        //    //    return -1023;
        //    //}

        //    string sEnrollNumber = "";
        //    string sEnabled = "";
        //    bool bEnabled = false;

        //    string sName = "";
        //    string sPassword = "";
        //    int iPrivilege = 0;
        //    string sFPTmpData = "";
        //    string sCardnumber = "";
        //    int idwFingerIndex = 0;
        //    string sdwFingerIndex = "";
        //    int iFlag = 0;
        //    string sFlag = "";
        //    int num = 0;
            
        //    devCon.EnableDevice(iMachineNumber, false);
        //    if (devCon.BeginBatchUpdate(iMachineNumber, 1))//create memory space for batching data
        //    {
        //        //for (int i = 0; i < lvUserInfo.Items.Count; i++)
        //        //{
        //        //    sEnrollNumber = lvUserInfo.Items[i].SubItems[0].Text;
        //        //    sEnabled = lvUserInfo.Items[i].SubItems[1].Text;
        //        //    if (sEnabled == "true")
        //        //    {
        //        //        bEnabled = true;
        //        //    }
        //        //    else
        //        //    {
        //        //        bEnabled = false;
        //        //    }
        //        //    sName = lvUserInfo.Items[i].SubItems[2].Text;
        //        //    sCardnumber = lvUserInfo.Items[i].SubItems[3].Text;
        //        //    sPassword = lvUserInfo.Items[i].SubItems[4].Text;
        //        //    sdwFingerIndex = lvUserInfo.Items[i].SubItems[5].Text;
        //        //    sFlag = lvUserInfo.Items[i].SubItems[6].Text;
        //        //    sFPTmpData = lvUserInfo.Items[i].SubItems[7].Text;
        //        //    iPrivilege = Convert.ToInt32(lvUserInfo.Items[i].SubItems[8].Text);

        //        //    if (sCardnumber != "" && sCardnumber != "0")
        //        //    {
        //        //        devCon.SetStrCardNumber(sCardnumber);
        //        //    }
        //        //    if (devCon.SSR_SetUserInfo(iMachineNumber, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the device
        //        //    {
        //        //        if (sdwFingerIndex != "" && sFlag != "" && sFPTmpData != "")
        //        //        {
        //        //            idwFingerIndex = Convert.ToInt32(sdwFingerIndex);
        //        //            iFlag = Convert.ToInt32(sFlag);
        //        //            devCon.SetUserTmpExStr(iMachineNumber, sEnrollNumber, idwFingerIndex, iFlag, sFPTmpData);//upload templates information to the device
        //        //        }
        //        //        num++;
        //        //        prgSta.Value = num % 100;
        //        //    }
        //        //    else
        //        //    {
        //        //        devCon.GetLastError(ref idwErrorCode);
        //        //        //lblOutputInfo.Items.Add("*Upload user " + sEnrollNumber + " error,ErrorCode=!" + idwErrorCode.ToString());
        //        //        //devCon.EnableDevice(iMachineNumber, true);
        //        //        //return -1022;
        //        //    }
        //        //}
        //    }
            
        //    devCon.BatchUpdate(iMachineNumber);//upload all the information in the memory
        //    devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
        //    devCon.EnableDevice(iMachineNumber, true);
        //    //lblOutputInfo.Items.Add("Upload user successfully in batch");
        //    return 1;
        //}

        #endregion

        #region SMS

        public int sta_GetSMS()
        {
            //if (IsConnected() == false)
            //{
            //    ////lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (txtSMSID.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //int idwErrorCode = 0;
            //int iSMSID = Convert.ToInt32(txtSMSID.Text.Trim());
            //int iTag = 0;
            //int iValidMins = 0;
            //string sStartTime = "";
            //string sContent = "";

            //devCon.EnableDevice(iMachineNumber, false);

            //if (devCon.GetSMS(iMachineNumber, iSMSID, ref iTag, ref iValidMins, ref sStartTime, ref sContent))
            //{
            //    switch (iTag)
            //    {
            //        case 253: cbTag.SelectedIndex = 0; break;
            //        case 254: cbTag.SelectedIndex = 1; break;
            //        case 255: cbTag.SelectedIndex = 2; break;
            //    }

            //    txtSMSID.Text = iSMSID.ToString();
            //    cbTag.Text = iTag.ToString();
            //    txtValidMin.Text = iValidMins.ToString();
            //    dtStartTime.Text = sStartTime;
            //    txtContent.Text = sContent;
            //    //lblOutputInfo.Items.Add("Get SMS successfully");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    ////lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}

            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_SetSMS()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (txtSMSID.Text.Trim() == "" || cbTag.Text.Trim() == "" || txtValidMin.Text.Trim() == "" || dtStartTime.Text.Trim() == "" || txtContent.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //if (Convert.ToInt32(txtSMSID.Text.Trim()) <= 0)
            //{
            //    //lblOutputInfo.Items.Add("*SMS ID error!");
            //    return -1023;
            //}

            //if (Convert.ToInt32(txtValidMin.Text.Trim()) < 0 || Convert.ToInt32(txtValidMin.Text.Trim()) > 65535)
            //{
            //    //lblOutputInfo.Items.Add("*Expired time error!");
            //    return -1023;
            //}

            //int idwErrorCode = 0;
            //int iSMSID = Convert.ToInt32(txtSMSID.Text.Trim());
            //int iTag = 0;
            //int iValidMins = Convert.ToInt32(txtValidMin.Text.Trim());
            //string sStartTime = dtStartTime.Text.Trim();
            //string sContent = txtContent.Text.Trim();
            //string sTag = cbTag.Text.Trim();

            //for (iTag = 253; iTag <= 255; iTag++)
            //{
            //    if (sTag.IndexOf(iTag.ToString()) > -1)
            //    {
            //        break;
            //    }
            //}

            //devCon.EnableDevice(iMachineNumber, false);
            //if (devCon.SetSMS(iMachineNumber, iSMSID, iTag, iValidMins, sStartTime, sContent))
            //{
            //    devCon.RefreshData(iMachineNumber);//After you have set the short message,you should refresh the data of the device
            //    //lblOutputInfo.Items.Add("Successfully set SMS! SMSType=" + iTag.ToString());
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_SetUserSMS()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (txtSMSID.Text.Trim() == "" || cbUserID.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //int idwErrorCode = 0;
            //int iSMSID = Convert.ToInt32(txtSMSID.Text.Trim());
            //int iTag = 0;
            //int iValidMins = 0;
            //string sStartTime = "";
            //string sContent = "";
            //string sEnrollNumber = cbUserID.Text.Trim();

            //devCon.EnableDevice(iMachineNumber, false);

            //if (devCon.GetSMS(iMachineNumber, iSMSID, ref iTag, ref iValidMins, ref sStartTime, ref sContent) == false)
            //{
            //    //lblOutputInfo.Items.Add("*The SMSID doesn't exist!!");
            //    devCon.EnableDevice(iMachineNumber, true);
            //    return -1022;
            //}

            //if (iTag != 254)
            //{
            //    //lblOutputInfo.Items.Add("*The SMS does not Personal SMS,please set it as Personal SMS first!!");
            //    devCon.EnableDevice(iMachineNumber, true);
            //    return -1022;
            //}

            //if (devCon.SSR_SetUserSMS(iMachineNumber, sEnrollNumber, iSMSID))
            //{
            //    devCon.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
            //    //lblOutputInfo.Items.Add("Successfully set user SMS! ");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_DelSMS()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (txtSMSID.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //int idwErrorCode = 0;
            //int iSMSID = Convert.ToInt32(txtSMSID.Text.Trim());

            //devCon.EnableDevice(iMachineNumber, false);
            //if (devCon.DeleteSMS(iMachineNumber, iSMSID))
            //{
            //    devCon.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
            //    //lblOutputInfo.Items.Add("Successfully delete SMS! ");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_DelUserSMS()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (txtSMSID.Text.Trim() == "" || cbUserID.Text.Trim() == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input data first!");
            //    return -1023;
            //}

            //int idwErrorCode = 0;
            //int iSMSID = Convert.ToInt32(txtSMSID.Text.Trim());
            //string sEnrollNumber = cbUserID.Text.Trim();

            //devCon.EnableDevice(iMachineNumber, false);
            //if (devCon.SSR_DeleteUserSMS(iMachineNumber, sEnrollNumber, iSMSID))
            //{
            //    devCon.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
            //    //lblOutputInfo.Items.Add("Successfully delete user SMS! ");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_ClearSMS()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //int idwErrorCode = 0;

            //devCon.EnableDevice(iMachineNumber, false);
            //if (devCon.ClearSMS(iMachineNumber))
            //{
            //    devCon.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
            //    //lblOutputInfo.Items.Add("Successfully clear all the SMS! ");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_ClearUserSMS()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //int idwErrorCode = 0;

            //devCon.EnableDevice(iMachineNumber, false);
            //if (devCon.ClearUserSMS(iMachineNumber))
            //{
            //    devCon.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
            //    //lblOutputInfo.Items.Add("Successfully clear all the user SMS! ");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }
        #endregion

        #region Workcode
        //public int sta_GetWorkCode(ListBox //lblOutputInfo, TextBox txtWorkcodeID, TextBox txtWorkcodeName)
        //{
        //    if (IsConnected() == false)
        //    {
        //        //lblOutputInfo.Items.Add("*Please connect first!");
        //        return -1024;
        //    }

        //    if (txtWorkcodeID.Text.Trim() == "")
        //    {
        //        //lblOutputInfo.Items.Add("*Please input data first!");
        //        return -1023;
        //    }

        //    int idwErrorCode = 0;
        //    int iWorkcodeID = Convert.ToInt32(txtWorkcodeID.Text.Trim());
        //    string sName = "";

        //    devCon.EnableDevice(iMachineNumber, false);
        //    if (devCon.SSR_GetWorkCode(iWorkcodeID, out sName))
        //    {
        //        txtWorkcodeName.Text = sName;
        //        //lblOutputInfo.Items.Add("Get workcode successfully");
        //    }
        //    else
        //    {
        //        devCon.GetLastError(ref idwErrorCode);
        //        //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
        //    }

        //    devCon.EnableDevice(iMachineNumber, true);

        //    return 1;
        //}

        //public int sta_SetWorkCode(ListBox //lblOutputInfo, TextBox txtWorkcodeID, TextBox txtWorkcodeName)
        //{
        //    if (IsConnected() == false)
        //    {
        //        //lblOutputInfo.Items.Add("*Please connect first!");
        //        return -1024;
        //    }

        //    if (txtWorkcodeID.Text.Trim() == "" || txtWorkcodeName.Text.Trim() == "")
        //    {
        //        //lblOutputInfo.Items.Add("*Please input data first!");
        //        return -1023;
        //    }

        //    int idwErrorCode = 0;
        //    int iTmpID = 0;
        //    int iWorkcodeID = Convert.ToInt32(txtWorkcodeID.Text.Trim());
        //    string sName = txtWorkcodeName.Text.Trim();
        //    /*
        //    devCon.SSR_GetWorkCodeIDByName(iMachineNumber, sName, out iTmpID);
           
            
        //    if (iTmpID > 0)
        //    {
        //        //lblOutputInfo.Items.Add("*Workcode name duplicated!");
        //        return -1022;
        //    }
            

        //    devCon.EnableDevice(iMachineNumber, false);
        //    if (devCon.SSR_SetWorkCode(iWorkcodeID, sName))
        //    {
        //        //lblOutputInfo.Items.Add("Successfully set workcode");
        //    }
        //    else
        //    {
        //        devCon.GetLastError(ref idwErrorCode);
        //        //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
        //    }
        //    */
        //    ////lblOutputInfo.Items.Add("[func SSR_GetWorkCodeIDByName]Temporarily unsupported");
        //    devCon.EnableDevice(iMachineNumber, false);
        //    if (devCon.SSR_SetWorkCode(iWorkcodeID, sName))
        //    {
        //        //lblOutputInfo.Items.Add("Successfully set workcode");
        //    }
        //    else
        //    {
        //        devCon.GetLastError(ref idwErrorCode);
        //        //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
        //    }
        //    devCon.EnableDevice(iMachineNumber, true);

        //    return 1;
        //}

        //public int sta_DelWorkCode(ListBox //lblOutputInfo, TextBox txtWorkcodeID)
        //{
        //    if (IsConnected() == false)
        //    {
        //        //lblOutputInfo.Items.Add("*Please connect first!");
        //        return -1024;
        //    }

        //    if (txtWorkcodeID.Text.Trim() == "")
        //    {
        //        //lblOutputInfo.Items.Add("*Please input data first!");
        //        return -1023;
        //    }

        //    int idwErrorCode = 0;
        //    int iWorkcodeID = Convert.ToInt32(txtWorkcodeID.Text.Trim());

        //    devCon.EnableDevice(iMachineNumber, false);
        //    if (devCon.SSR_DeleteWorkCode(iWorkcodeID))
        //    {
        //        //lblOutputInfo.Items.Add("Successfully delete workcode");
        //    }
        //    else
        //    {
        //        devCon.GetLastError(ref idwErrorCode);
        //        //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
        //    }

        //    devCon.EnableDevice(iMachineNumber, true);

        //    return 1;
        //}

        //public int sta_ClearWorkCode(ListBox //lblOutputInfo)
        //{
        //    if (IsConnected() == false)
        //    {
        //        //lblOutputInfo.Items.Add("*Please connect first!");
        //        return -1024;
        //    }

        //    int idwErrorCode = 0;

        //    devCon.EnableDevice(iMachineNumber, false);
        //    if (devCon.SSR_ClearWorkCode())
        //    {
        //        //lblOutputInfo.Items.Add("Successfully clear all workcode");
        //    }
        //    else
        //    {
        //        devCon.GetLastError(ref idwErrorCode);
        //        //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
        //    }

        //    devCon.EnableDevice(iMachineNumber, true);

        //    return 1;
        //}
        #endregion

        #region user role

        public string[] sApp=new string[]
        {
            "usermng",
            "access",
            "iccardmng",
            "comset",
            "sysset",
            "myset",
            "datamng",
            "udiskmng",
            "logquery",
            "printset",
            "sms",
            "workcode",
            "autotest",
            "sysinfo"
        };

        public string[] sFunUserMng = new string[]
        {
            "adduser",
            "userlist",
            "userliststyle"
        };

        public string[] sFunAccess = new string[] 
        {
            "timezone",
            "holiday",
            "group",
            "unlockcomb",
            "accparam",
            "duressalarm",
            "antipassbackset"
        };

        public string[] sFunICCard = new string[] 
        {
            "enrollnumcard",
            "enrollfpcard",
            "clearcard",
            "copycard",
            "setcardparam"
        };

        public string[] sFunComm = new string[]
        {
            "netset",
            "serialset",
            "linkset",
            "mobilenet",
            "wifiset",
            "admsset",
            "wiegandset"
        };

        public string[] sFunSystem = new string[]
        {
            "timeset",
            "attparam",
            "fpparam",
            "restoreset",
            "udiskupgrade",
        };

        public string[] sFunPersonalize = new string[]
        {
            "displayset",
            "voiceset",
            "bellset",
            "shortcutsset",
            "statemodeset",
            "autopowerset"
        };

        public string[] sFunDataMng = new string[]
        {
            "cleardata",
            "backupdata",
            "restoredata"
        };

        public string[] sFunUSBMng = new string[]
        {
            "udiskupload",
            "udiskdownload",
            "udiskset"
        };

        public string[] sFunAttSearch = new string[]
        {
            "attlog",
            "attpic",
            "blacklistpic"
        };

        public string[] sFunPrint = new string[]
        {
            "printinfoset",
            "printfuncset"
        };

        public string[] sFunSMS = new string[]
        {
            "addsms",
            "smslist"
        };

        public string[] sFunWorkCode = new string[]
        {
            "addworkcode",
            "workcodelist",
            "workcodesetting"
        };

        public string[] sFunAutoTest = new string[] 
        {
            "alltest",
            "screentest",
            "voicetest",
            "keytest",
            "fptest",
            "realtimetest",
            "cameratest"
        };

        public string[] sFunSysInfo = new string[]
        {
            "datacapacity",
            "devinfo",
            "firmwareinfo"
        };

        public int sta_GetUserRole()
        {
//            if (IsConnected() == false)
//            {
//                //lblOutputInfo.Items.Add("*Please connect first!");
//                return -1024;
//            }

//            if (cbUserRole.Text == "")
//            {
//                //lblOutputInfo.Items.Add("*Please input user role!");
//                return -1023;
//            }

//            int iPrivilege = cbUserRole.SelectedIndex;
///*
//            bool bFlag = false;
//            if (iPrivilege == 2)
//            {
//                devCon.IsUserDefRoleEnable(iMachineNumber, 4, out bFlag);

//                if (bFlag == false)
//                {
//                    //lblOutputInfo.Items.Add("*User Defined Role is unable!");
//                    return -1023;
//                }
//            }
//*/
//            int idwErrorCode = 0;
//            string sAppName = "";
//            string sFunName = "";
//            int i = 0, j = 1;
//            int l = 0, k = 1;
//            int iUserRole = 0;
///*
            //switch (cbUserRole.SelectedIndex)
            //{
            //    case 0: iUserRole = 1; break;
            //    case 1: iUserRole = 2; break;
            //    case 2: iUserRole = 4; break;
            //}

            //devCon.EnableDevice(iMachineNumber, false);
            
            //if (devCon.GetAppOfRole(iMachineNumber, iUserRole, out sAppName))
            //{
            //    if (devCon.GetFunOfRole(iMachineNumber, iUserRole, out sFunName))
            //    {
            //        string[] sTmp = Regex.Split(sAppName, "\r\n", RegexOptions.None);
            //        string[] sTmp1 = Regex.Split(sFunName, "\r\n", RegexOptions.None);

            //        for (l = 1; l < sTmp.Length; l++)
            //        {
            //            for (k = 0; k < sApp.Length; k++)
            //            {
            //                if (string.Compare(sTmp[l].ToString(), sApp[k].ToString()) == 0)
            //                {
            //                    iAppState[k] = 1;
            //                    switch (k)
            //                    {
            //                        case 0:
            //                            {
            //                                for (i = 0; i < sFunUserMng.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunUserMng[i].ToString()) == 0)
            //                                        {
            //                                            iFunUserMng[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 1:
            //                            {
            //                                for (i = 0; i < sFunAccess.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunAccess[i].ToString()) == 0)
            //                                        {
            //                                            iFunAccess[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 2:
            //                            {
            //                                for (i = 0; i < sFunICCard.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunICCard[i].ToString()) == 0)
            //                                        {
            //                                            iFunICCard[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 3:
            //                            {
            //                                for (i = 0; i < sFunComm.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunComm[i].ToString()) == 0)
            //                                        {
            //                                            iFunComm[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 4:
            //                            {
            //                                for (i = 0; i < sFunSystem.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunSystem[i].ToString()) == 0)
            //                                        {
            //                                            iFunSystem[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 5:
            //                            {
            //                                for (i = 0; i < sFunPersonalize.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunPersonalize[i].ToString()) == 0)
            //                                        {
            //                                            iFunPersonalize[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 6:
            //                            {
            //                                for (i = 0; i < sFunDataMng.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunDataMng[i].ToString()) == 0)
            //                                        {
            //                                            iFunDataMng[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 7:
            //                            {
            //                                for (i = 0; i < sFunUSBMng.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunUSBMng[i].ToString()) == 0)
            //                                        {
            //                                            iFunUSBMng[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 8:
            //                            {
            //                                for (i = 0; i < sFunAttSearch.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunAttSearch[i].ToString()) == 0)
            //                                        {
            //                                            iFunAttSearch[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 9:
            //                            {
            //                                for (i = 0; i < sFunPrint.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunPrint[i].ToString()) == 0)
            //                                        {
            //                                            iFunPrint[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 10:
            //                            {
            //                                for (i = 0; i < sFunSMS.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunSMS[i].ToString()) == 0)
            //                                        {
            //                                            iFunSMS[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 11:
            //                            {
            //                                for (i = 0; i < sFunWorkCode.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunWorkCode[i].ToString()) == 0)
            //                                        {
            //                                            iFunWorkCode[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 12:
            //                            {
            //                                for (i = 0; i < sFunAutoTest.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunAutoTest[i].ToString()) == 0)
            //                                        {
            //                                            iFunAutoTest[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        case 13:
            //                            {
            //                                for (i = 0; i < sFunSysInfo.Length; i++)
            //                                {
            //                                    for (j = 1; j < sTmp1.Length; j++)
            //                                    {
            //                                        if (string.Compare(sTmp1[j].ToString(), sFunSysInfo[i].ToString()) == 0)
            //                                        {
            //                                            iFunSysInfo[i] = 1;
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                                break;
            //                            }
            //                        default: break;
            //                    }
            //                    break;
            //                }
            //            }
            //        }
            //        devCon.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
            //        //lblOutputInfo.Items.Add("Get user role successfully! ");
            //    }
            //    else
            //    {
            //        devCon.GetLastError(ref idwErrorCode);
            //        //lblOutputInfo.Items.Add("*Get sub menu failed,ErrorCode=" + idwErrorCode.ToString());

            //        return 1;
            //    }
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Get top menu failed,ErrorCode=" + idwErrorCode.ToString());
            //}
            //*/
            ////lblOutputInfo.Items.Add("[func GetAppOfRole]Temporarily unsupported");
            //devCon.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_SetUserRole()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //if (cbUserRole.Text == "")
            //{
            //    //lblOutputInfo.Items.Add("*Please input user role!");
            //    return -1023;
            //}

            //int iPrivilege = cbUserRole.SelectedIndex;
/*
            bool bFlag = false;
            if (iPrivilege == 2)
            {
                devCon.IsUserDefRoleEnable(iMachineNumber, 4, out bFlag);

                if (bFlag == false)
                {
                    //lblOutputInfo.Items.Add("*User Defined Role is unable!");
                    return -1023;
                }
            }
*/
            int idwErrorCode = 0;
            int iUserRole = 0;
            int dd = 0;
 
            /*
            //SDK支持
            switch (cbUserRole.SelectedIndex)
            {
                case 0: iUserRole = 1; break;
                case 1: iUserRole = 2; break;
                case 2: iUserRole = 4; break;
            }
           
            for (int i = 0; i < iFunUserMng.Length; i++)
            {
                if (iFunUserMng[i] == 1)
                {
                    if (!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[0], sFunUserMng[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set User Mgt menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[0], sFunUserMng[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set User Mgt menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
            }

            for (int i = 0; i < iFunAccess.Length; i++)
            {
                if (iFunAccess[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[1], sFunAccess[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Access Control menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[1], sFunAccess[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Access Control menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
            }

            for (int i = 0; i < iFunICCard.Length; i++)
            {
                if (iFunICCard[i] == 1)
                {
                    if (!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[2], sFunICCard[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set IC Card menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[2], sFunICCard[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set IC Card menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
            }

            for (int i = 0; i < iFunComm.Length; i++)
            {
                if (iFunComm[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[3], sFunComm[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Comm menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[3], sFunComm[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Comm menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
            }

            for (int i = 0; i < iFunSystem.Length; i++)
            {
                if (iFunSystem[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[4], sFunSystem[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set System menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[4], sFunSystem[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set System menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunPersonalize.Length; i++)
            {
                if (iFunPersonalize[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[5], sFunPersonalize[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Personalize menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[5], sFunPersonalize[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Personalize menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunDataMng.Length; i++)
            {
                if (iFunDataMng[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[6], sFunDataMng[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Data Mgt menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[6], sFunDataMng[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Data Mgt menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunUSBMng.Length; i++)
            {
                if (iFunUSBMng[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[7], sFunUSBMng[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set USB Manager menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[7], sFunUSBMng[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set USB Manager menu failed,menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunAttSearch.Length; i++)
            {
                if (iFunAttSearch[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[8], sFunAttSearch[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Attendance menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[8], sFunAttSearch[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Attendance menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunPrint.Length; i++)
            {
                if (iFunPrint[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[9], sFunPrint[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Print menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[9], sFunPrint[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Print menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunSMS.Length; i++)
            {
                if (iFunSMS[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[10], sFunSMS[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Short Message menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[10], sFunSMS[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Short Message menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd ++;
                    }
                }
            }

            for (int i = 0; i < iFunWorkCode.Length; i++)
            {
                if (iFunWorkCode[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[11], sFunWorkCode[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Work Code menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[11], sFunWorkCode[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Work Code menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunAutoTest.Length; i++)
            {
                if (iFunAutoTest[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[12], sFunAutoTest[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Auto Test menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[12], sFunAutoTest[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set Auto Test menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            for (int i = 0; i < iFunSysInfo.Length; i++)
            {
                if (iFunSysInfo[i] == 1)
                {
                    if(!devCon.SetPermOfAppFun(iMachineNumber, iUserRole, sApp[13], sFunSysInfo[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set System Info menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
                else
                {
                    if (!devCon.DeletePermOfAppFun(iMachineNumber, iUserRole, sApp[13], sFunSysInfo[i]))
                    {
                        devCon.GetLastError(ref idwErrorCode);
                        //lblOutputInfo.Items.Add("*Set System Info menu failed,sub menu index=" + i.ToString() + ",ErrorCode=" + idwErrorCode.ToString());
                        dd++;
                    }
                }
            }

            if (dd == 0)
            {
                //lblOutputInfo.Items.Add("Set User Role successfully~");
            }
            */
            ////lblOutputInfo.Items.Add("[func SetPermOfAppFun]Temporarily unsupported");
            return 1;
        }
        #endregion

        #region UserBio

        /*
        public void connectDevice(string ip, int port, int commKey)
        {
            
            devCon.SetCommPassword(commKey);
            connected = devCon.Connect_Net(ip, port);
            if (connected)
            {
                sta_getBiometricType();
            }
        }

        public void disconnectDevice()
        {
            if (connected) devCon.Disconnect();
        }
        */

        private string sta_getSysOptions(string option)
        {
            string value = string.Empty;
            devCon.GetSysOption(iMachineNumber, option, out value);
            return value;
        }

        /// <summary>
        /// get version
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricVersion()
        {
            string result = string.Empty;
            _biometricVersion = sta_getSysOptions("BiometricVersion");
        }

        /// <summary>
        /// get support type
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricType()
        {
            string result = string.Empty;
            result = sta_getSysOptions("BiometricType");
            if (!string.IsNullOrEmpty(result))
            {
                _supportBiometricType.fp_available = result[1] == '1';
                _supportBiometricType.face_available = result[2] == '1';
                if (result.Length >= 9)
                {
                    _supportBiometricType.fingerVein_available = result[7] == '1';
                    _supportBiometricType.palm_available = result[8] == '1';
                }
            }
            _biometricType = result;
        }

        public List<Employee> sta_getEmployees()
        {
            if (!IsConnected())
            {
                return new List<Employee>();
            }
            List<Employee> employees = new List<Employee>();

            string empnoStr = string.Empty;
            string name = string.Empty;
            string pwd = string.Empty;
            int pri = 0;
            bool enable = true;
            string cardNum = string.Empty;

            devCon.EnableDevice(iMachineNumber, false);
            try
            {
                devCon.ReadAllUserID(iMachineNumber);

                while (devCon.SSR_GetAllUserInfo(iMachineNumber, out empnoStr, out name, out pwd, out pri, out enable))
                {
                    cardNum = "";
                    if (devCon.GetStrCardNumber(out cardNum))
                    {
                        if (string.IsNullOrEmpty(cardNum))
                            cardNum = "";
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        int index = name.IndexOf("\0");
                        if (index > 0)
                        {
                            name = name.Substring(0, index);
                        }
                    }

                    Employee emp = new Employee();
                    emp.pin = empnoStr;
                    emp.name = name;
                    emp.privilege = pri;
                    emp.password = pwd;
                    emp.cardNumber = cardNum;

                    employees.Add(emp);
                }
            }
            catch
            {

            }
            finally
            {
                devCon.EnableDevice(iMachineNumber, true);
            }
            return employees;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bioTemplate"></param>
        private void sta_getBioTemplateFromBuffer(string buffer, ref BioTemplate bioTemplate)
        {
            string temp;
            for (int i = 1; i <= 10; i++)
            {
                if (buffer.IndexOf(',') > 0)
                {
                    temp = buffer.Substring(0, buffer.IndexOf(','));
                }
                else
                {
                    temp = buffer;
                }

                switch (i)
                {
                    case 1:
                        bioTemplate.pin = temp ;
                        break;
                    case 2:
                        bioTemplate.valid_flag = int.Parse(temp);
                        break;
                    case 3:
                        bioTemplate.is_duress = int.Parse(temp);
                        break;
                    case 4:
                        bioTemplate.bio_type = int.Parse(temp);
                        break;
                    case 5:
                        bioTemplate.version = temp;
                        break;
                    case 6:
                        bioTemplate.version = bioTemplate.version + "." + temp;
                        break;
                    case 7:
                        bioTemplate.data_format = int.Parse(temp);
                        break;
                    case 8:
                        bioTemplate.template_no = int.Parse(temp);
                        break;
                    case 9:
                        bioTemplate.template_no_index = int.Parse(temp);
                        break;
                    case 10:
                        bioTemplate.template_data = temp;
                        break;
                }

                buffer = buffer.Substring(buffer.IndexOf(',') + 1);
            }
        }

        /// <summary>
        /// get template
        /// </summary>
        /// <param name="aBioType">
        /// <returns></returns>
        private List<string> sta_batchDownloadBioTemplates(int aBioType)
        {
            int tempNum = 50;
            int tn = 2;
            List<string> bufferList = new List<string>();
            //foreach (Employee e in employeeList)
            //{
            //    string filter;
            //    if(aBioType == 1)
            //        filter = string.Format("Type={0}",aBioType);
            //    else
            //        filter = string.Format("Pin={0}\tType={1}",e.pin, aBioType);
                
            //    int dataCount = devCon.SSR_GetDeviceDataCount(PersBioTableName, filter, string.Empty);
            //    int nC = aBioType == 1 ? 1 : aBioType == 2 ? 12 : aBioType == 7 ? 3 : aBioType == 8 ? 6 : 0;
                
            //    string strOffBuffer = string.Empty;
            //    int eBufferSize = 0;
            //    bool result = true;
            //    int n = 0;

            //    while (true)
            //    {
            //        n = 0;
            //        strOffBuffer = string.Empty;
            //        eBufferSize = dataCount * 3500 * nC;
            //        string option = string.Empty;
            //        try
            //        {
            //            result = devCon.SSR_GetDeviceData(iMachineNumber, out strOffBuffer, eBufferSize,
            //                PersBioTableName, PersBioTableFields, filter, option);
            //        }
            //        catch
            //        {
            //            result = false;
            //            int errorCode = 0;
            //            devCon.GetLastError(ref errorCode);
            //        }
            //        if (result) break;
            //        if (!result && n == 2) break;
            //        n++;
            //    }
            //    if (result)
            //    {
            //        bufferList.Add(strOffBuffer);
            //        if ((bufferList.Count / tempNum) >= 0)
            //        {
            //            procBar.Value = tn;
            //            tn += tn;
            //            if (tn >= 90)
            //                tn = 90;
            //            tempNum = tempNum + 50;
            //        }
            //    }
            //    if (aBioType == 1)   //表示指纹模板获取
            //    {
            //        break;
            //    }
            //}
            return bufferList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aBioType"></param>
        /// <returns></returns>
        public List<BioTemplate> sta_BatchGetBioTemplates(int aBioType)
        {
            //List<BioTemplate> bioTemplateList = new List<BioTemplate>();
            //List<string> bufferList = sta_batchDownloadBioTemplates(procBar, aBioType);
            //for (int i = 0; i < bufferList.Count; i++)
            //{
            //    string[] buffers = bufferList[i].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //    for (int j = 1; j < buffers.Length; j++)
            //    {
            //        BioTemplate bioTemplate = new BioTemplate();
            //        sta_getBioTemplateFromBuffer(buffers[j], ref bioTemplate);
            //        bioTemplateList.Add(bioTemplate);
            //    }
            //}

              return new List<BioTemplate>();
        }

        private string sta_AssemblesAllUserBioTemplateInfo(List<BioTemplate> bioTemplateList, int aBioType, string version)
        {
            List<BioTemplate> uploadBioTemplateList = bioTemplateList.FindAll(t => t.bio_type == aBioType && t.version.Equals(version));

            string bioTemplateVersion = string.Empty;
            string eMajorVer = string.Empty;
            string eMinorVer = string.Empty;
            StringBuilder result = new StringBuilder();
            foreach (BioTemplate template in uploadBioTemplateList)
            {
                bioTemplateVersion = template.version;
                if (bioTemplateVersion.IndexOf('.') < 0) bioTemplateVersion = bioTemplateVersion + ".0";
                eMajorVer = bioTemplateVersion.Substring(0, bioTemplateVersion.IndexOf('.'));
                eMinorVer = bioTemplateVersion.Substring(bioTemplateVersion.IndexOf('.') + 1);
                result.Append(string.Format("Pin={0}\tValid={1}\tDuress={2}\tType={3}\tMajorVer={4}\tMinorVer={5}\tFormat={6}\tNo={7}\tIndex={8}\tTmp={9}\r\n",
                    template.pin, template.valid_flag, template.is_duress, template.bio_type, eMajorVer, eMinorVer, template.data_format, template.template_no,
                    template.template_no_index, template.template_data));
            }
            return result.ToString();
        }

        public void sta_setBioTemplates(List<BioTemplate> bioTemplateList, out string message)
        {
            //message = string.Empty;
            //if (string.IsNullOrEmpty(_biometricVersion)) sta_getBiometricVersion();
            //if (string.IsNullOrEmpty(_biometricType)) sta_getBiometricType();
            //string[] versions = _biometricVersion.Split(':');

            //StringBuilder errorMsg = new StringBuilder();
            //for (int i = 0; i < _biometricType.Length; i++)
            //{
            //    if (_biometricType[i] == '1')
            //    {
            //        string buffer = sta_AssemblesAllUserBioTemplateInfo(bioTemplateList, i, versions[i]);
            //        try
            //        {
            //            int errorCode = 0;
            //            bool result = true;
            //            if (!string.IsNullOrEmpty(buffer)) 
            //            {
            //                result = devCon.SSR_SetDeviceData(1, PersBioTableName, buffer, string.Empty);
            //            }

            //            if (!result)
            //            {
            //                devCon.GetLastError(ref errorCode);
            //                errorMsg.Append(string.Format(" errorcode={0} ", errorCode));
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            errorMsg.Append(e.Message);
            //        }
            //    }
            //}
            //devCon.RefreshData(iMachineNumber);
            //devCon.EnableDevice(iMachineNumber, true);
            message = "";
        }

        public void sta_setEmployees(List<Employee> employees)
        {
            devCon.EnableDevice(1, false);
            try
            {
                bool batchUpdate = devCon.BeginBatchUpdate(iMachineNumber, 1);
                foreach (Employee emp in employees)
                {
                    devCon.SetStrCardNumber(emp.cardNumber);
                    devCon.SSR_SetUserInfo(iMachineNumber, emp.pin, emp.name, emp.password, emp.privilege, true);
                }
                if (batchUpdate)
                {
                    devCon.BatchUpdate(iMachineNumber);
                    batchUpdate = false;
                }
            }
            catch
            { }
            finally
            {
                devCon.EnableDevice(iMachineNumber, true);
            }
        }

   #endregion

        public int sta_GetAllUserID()
        {
            //if (IsConnected() == false)
            //{
            //    return -1024;
            //}

            //string sEnrollNumber = "";
            //bool bEnabled = false;
            //string sName = "";
            //string sPassword = "";
            //int iPrivilege = 0;

            //if (bAddControl == true || bEnable == true)
            //{
            //    cbUserID.Items.Clear();
            //    cbUserID1.Items.Clear();
            //    cbUserID2.Items.Clear();
            //    cbUserID3.Items.Clear();
            //    cbUserID4.Items.Clear();
            //    txtID2.Clear();
            //    cbUserID7.Items.Clear();

            //    devCon.EnableDevice(iMachineNumber, false);
            //    devCon.ReadAllUserID(iMachineNumber);//read all the user information to the memory
            //    while (devCon.SSR_GetAllUserInfo(iMachineNumber, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
            //    {
            //        cbUserID.Items.Add(sEnrollNumber);
            //        cbUserID1.Items.Add(sEnrollNumber);
            //        cbUserID2.Items.Add(sEnrollNumber);
            //        cbUserID3.Items.Add(sEnrollNumber);
            //        cbUserID4.Items.Add(sEnrollNumber);
            //        //txtID2.Text = sEnrollNumber;
            //        cbUserID7.Items.Add(sEnrollNumber);
            //    }

            //    devCon.EnableDevice(iMachineNumber, true);
            //}

            //bAddControl = false;
            //bEnable = false;

            return 1;
        }

        #endregion

        #region DataMng

        #region  AttLogMng

        public int sta_readAttLog(DataTable dt_log)
        {
            if (IsConnected() == false)
            {
                ////lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);//disable the device

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

            if (devCon.ReadGeneralLogData(iMachineNumber))
            {
                while (devCon.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_log.NewRow();
                    dr["User ID"] = sdwEnrollNumber;
                    dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    dr["Verify Type"] = idwVerifyMode;
                    dr["Verify State"] = idwInOutMode;
                    dr["WorkCode"] = idwWorkcode;
                    dt_log.Rows.Add(dr);
                }
                ret = 1;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    //lblOutputInfo.Items.Add("*Read attlog failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    //lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            devCon.EnableDevice(iMachineNumber, true);//enable the device

            return ret;
        }

        public int sta_readLogByPeriod(DataTable dt_logPeriod, string fromTime, string toTime)
        {
            if (IsConnected() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);//disable the device

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

            
            //if (devCon.ReadTimeGLogData(iMachineNumber, fromTime, toTime))
            //{
            //    while (devCon.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
            //                out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
            //    {
            //        DataRow dr = dt_logPeriod.NewRow();
            //        dr["User ID"] = sdwEnrollNumber;
            //        dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
            //        dr["Verify Type"] = idwVerifyMode;
            //        dr["Verify State"] = idwInOutMode;
            //        dr["WorkCode"] = idwWorkcode;
            //        dt_logPeriod.Rows.Add(dr);
            //    }
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    ret = idwErrorCode;

            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("*Read attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
            //    }
            //}


            ////lblOutputInfo.Items.Add("[func ReadTimeGLogData]Temporarily unsupported");
            devCon.EnableDevice(iMachineNumber, true);//enable the device

            return ret;
        }

        public int sta_DeleteAttLog()
        {
            if (IsConnected() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);//disable the device


            if (devCon.ClearGLog(iMachineNumber))
            {
                devCon.RefreshData(iMachineNumber);
                ret = 1;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    //lblOutputInfo.Items.Add("*Delete attlog, ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    //lblOutputInfo.Items.Add("No data from terminal returns!");
                }
            }

            devCon.EnableDevice(iMachineNumber, true);//enable the device

            return ret;
        }

        public int sta_DeleteAttLogByPeriod(string fromTime, string toTime)
        {
            if (IsConnected() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);//disable the device

            
            //if (devCon.DeleteAttlogBetweenTheDate(iMachineNumber, fromTime, toTime))
            //{
            //    devCon.RefreshData(iMachineNumber);
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    ret = idwErrorCode;

            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("*Delete attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
            //    }
            //}
            
            ////lblOutputInfo.Items.Add("[func DeleteAttlogBetweenTheDate]Temporarily unsupported");
            devCon.EnableDevice(iMachineNumber, true);//enable the device

            return ret;
        }

        public int sta_DelOldAttLogFromTime(string fromTime)
        {
            //if (IsConnected() == false)
            //{
            //    ////lblOutputInfo.Items.Add("Please connect first!");
            //    return -1024;
            //}

            //int ret = 0;

            //devCon.EnableDevice(iMachineNumber, false);//disable the device

            
            //if (devCon.DeleteAttlogByTime(iMachineNumber, fromTime))
            //{
            //    devCon.RefreshData(iMachineNumber);
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    ret = idwErrorCode;

            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("*Delete old attlog from time failed,ErrorCode: " + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
            //    }
            //}
            
            //////lblOutputInfo.Items.Add("[func DeleteAttlogByTime]Temporarily unsupported");
            //devCon.EnableDevice(iMachineNumber, true);//enable the device

            return 0;
        }

        public int sta_ReadNewAttLog()
        {
            //if (IsConnected() == false)
            //{
            //    ////lblOutputInfo.Items.Add("Please connect first!");
            //    return -1024;
            //}

            //int ret = 0;

            //devCon.EnableDevice(iMachineNumber, false);//disable the device

            //string sdwEnrollNumber = "";
            //int idwVerifyMode = 0;
            //int idwInOutMode = 0;
            //int idwYear = 0;
            //int idwMonth = 0;
            //int idwDay = 0;
            //int idwHour = 0;
            //int idwMinute = 0;
            //int idwSecond = 0;
            //int idwWorkcode = 0;

            
            //if (devCon.ReadNewGLogData(iMachineNumber))
            //{
            //    while (devCon.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
            //                out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
            //    {
            //        DataRow dr = dt_logNew.NewRow();
            //        dr["User ID"] = sdwEnrollNumber;
            //        dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
            //        dr["Verify Type"] = idwVerifyMode;
            //        dr["Verify State"] = idwInOutMode;
            //        dr["WorkCode"] = idwWorkcode;
            //        dt_logNew.Rows.Add(dr);
            //    }
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    ret = idwErrorCode;

            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("*Read attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
            //    }
            //}
            
            ////lblOutputInfo.Items.Add("[func ReadNewGLogData]Temporarily unsupported");
            devCon.EnableDevice(iMachineNumber, true);//enable the device

            return 0;
        }
        #endregion

        

        #region OPLOG
        public int sta_GetOplog()
        {
            //if (IsConnected() == false)
            //{
            //    ////lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}
            //int ret = 0;
            //int iSuperLogCount = 0;

            //devCon.EnableDevice(iMachineNumber, false);

            //if (devCon.ReadSuperLogData(iMachineNumber))
            //if (devCon.ReadAllSLogData(iMachineNumber))
            //{
            //    int idwTMachineNumber = 0;
            //    int iParams1 = 0;
            //    int iParams2 = 0;
            //    int idwManipulation = 0;
            //    int iParams3 = 0;

            //    int iParams4 = 0;
            //    int iYear = 0;
            //    int iMonth = 0;
            //    int iDay = 0;
            //    int iHour = 0;
            //    int iMin = 0;
            //    int iSencond = 0;
            //    int iAdmin = 0;

            //    string sUser = null;
            //    string sAdmin = null;
            //    string sTime = null;

            //    //while (devCon.SSR_GetSuperLogData(iMachineNumber, out idwTMachineNumber, out sAdmin, out sUser,
            //    //    out idwManipulation, out sTime, out iParams1, out iParams2, out iParams3))
            //    while (devCon.GetSuperLogData2(iMachineNumber, ref idwTMachineNumber, ref iAdmin, ref iParams4, ref iParams1, ref iParams2, ref idwManipulation, ref iParams3, ref iYear, ref iMonth, ref iDay, ref iHour, ref iMin,ref iSencond))
            //    {
            //        iSuperLogCount++;
            //        DataRow dr = dt_Oplog.NewRow();
            //        dr["Count"] = iSuperLogCount;
            //        dr["MachineNumber"] = iMachineNumber;
            //        dr["Admin"] = iAdmin;
            //        //dr["UserPIN2"] = sUser;
            //        dr["Operation"] = idwManipulation;
            //        sTime = iYear + "-" + iMonth + "-" + iDay + " " + iHour + ":" + iMin + ":" + iSencond;
            //        dr["DateTime"] = sTime;
            //        dr["Param1"] = iParams1;
            //        dr["Param2"] = iParams2;
            //        dr["Param3"] = iParams3;
            //        dr["Param4"] = iParams4;
            //        dt_Oplog.Rows.Add(dr);
            //    }

            //    //lblOutputInfo.Items.Add("Down oplog success.");
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    ret = idwErrorCode;

            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("*Get OPLOG failed,ErrorCode: " + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
              //}
            //}

            //devCon.EnableDevice(iMachineNumber, true);

            return 0;
        }

        public int sta_ClearOplog()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}
            //int ret = 0;

            //devCon.EnableDevice(iMachineNumber, false);

            //if (devCon.ClearSLog(iMachineNumber))
            //{
            //    devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
            //    //lblOutputInfo.Items.Add("All operation logs have been cleared from teiminal!");
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("ClearOplog failed,ErrorCode=" + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
            //    }
            //    ret = idwErrorCode;
            //}

            devCon.EnableDevice(iMachineNumber, true);
            return 0;
        }
        #endregion

        #region ClearData

        public int sta_ClearAllLogs()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}
            //int ret = 0;

            //devCon.EnableDevice(iMachineNumber, false);

            //if (devCon.ClearData(iMachineNumber, 1))
            //{
            //    devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
            //    //lblOutputInfo.Items.Add("All AttLogs have been cleared from teiminal!");
            //    ret = 1;
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    if (idwErrorCode != 0)
            //    {
            //        //lblOutputInfo.Items.Add("*ClearAllLogs failed,ErrorCode=" + idwErrorCode.ToString());
            //    }
            //    else
            //    {
            //        //lblOutputInfo.Items.Add("No data from terminal returns!");
            //    }
            //    ret = idwErrorCode;
            //}

            //devCon.EnableDevice(iMachineNumber, true);
            return 0;
        }

        public int sta_ClearAllFps()
        {
            if (IsConnected() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);

            if (devCon.ClearData(iMachineNumber, 2))
                //1.Attendance record
                //2.Fingerprint template data
                //3.None
                //4.Operation record
                //5.User information
            {
                devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
                
                ret = 1;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    ////lblOutputInfo.Items.Add("*ClearAllFps failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    ////lblOutputInfo.Items.Add("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            devCon.EnableDevice(iMachineNumber, true);
            return ret;
        }

        public int sta_ClearAllUsers()
        {
            if (IsConnected() == false)
            {
                ////lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);

            if (devCon.ClearData(iMachineNumber, 5))
            {
                devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
                ////lblOutputInfo.Items.Add("All users have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    ////lblOutputInfo.Items.Add("*ClearAllUsers failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    ////lblOutputInfo.Items.Add("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            devCon.EnableDevice(iMachineNumber, true);
            return ret;
        }

        public int sta_ClearAllData()
        {
            if (IsConnected() == false)
            {
                ////lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            devCon.EnableDevice(iMachineNumber, false);

            if (devCon.ClearKeeperData(iMachineNumber))
            {
                devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
                ////lblOutputInfo.Items.Add("All Data have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    ////lblOutputInfo.Items.Add("*ClearAllData failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    ////lblOutputInfo.Items.Add("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            devCon.EnableDevice(iMachineNumber, true);
            return ret;
        }
        #endregion


        #endregion

        #region AccessMng

        #region UserGroup

        #endregion

        #region UserIDTimer not the stander interface on SDK.
        //Add the esxited userid to DropDownLists.
        bool bIDTimerAddControl = true;
        public int sta_UserIDTimer(bool bEnable)
        {
            //if (IsConnected() == false)
            //{
            //    return -1024;
            //}

            //if (bIDTimerAddControl == true || bEnable == true)
            //{
            //    string sEnrollNumber = "";
            //    string sName = "";
            //    string sPassword = "";
            //    int iPrivilege = 0;
            //    bool bEnabled = false;

            //    cboUAUserIDGroup.Items.Clear();
            //    cboUAUserIDTZ.Items.Clear();

            //    devCon.EnableDevice(iMachineNumber, false);
            //    devCon.ReadAllUserID(iMachineNumber);//read all the user information to the memory
            //    while (devCon.SSR_GetAllUserInfo(iMachineNumber, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            //    {
            //        cboUAUserIDGroup.Items.Add(sEnrollNumber);
            //        cboUAUserIDTZ.Items.Add(sEnrollNumber);
            //    }

            //    devCon.EnableDevice(iMachineNumber, true);
            //}

            //bIDTimerAddControl = false;
            //bEnable = false;

            return 1;
            
        }
        #endregion

        #region OtherMng

        #region sync time
        //Synchronize the device time as the computer's.
        public int sta_SYNCTime()
        {
            if (IsConnected() == false)
            {
                ////lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            if (devCon.SetDeviceTime(iMachineNumber))
            {
                devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
                ////lblOutputInfo.Items.Add("Successfully SYNC the PC's time to device!");
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                ////lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return 1;
        }

        public int sta_GetDeviceTime()
        {
            if (IsConnected() == false)
            {
                //lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }

            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;

            if (devCon.GetDeviceTime(iMachineNumber, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond))//show the time
            {
                //lbDeviceTime.Text = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
                //lblOutputInfo.Items.Add("Get devie time successfully");
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return 1;
        }

        public int sta_SetDeviceTime()
        {
            //if (IsConnected() == false)
            //{
            //    //lblOutputInfo.Items.Add("*Please connect first!");
            //    return -1024;
            //}

            //DateTime date = DateTime.Parse(dtDeviceTime.Text);
            //int idwYear = Convert.ToInt32(date.Year.ToString());
            //int idwMonth = Convert.ToInt32(date.Month.ToString());
            //int idwDay = Convert.ToInt32(date.Day.ToString());
            //int idwHour = Convert.ToInt32(date.Hour.ToString());
            //int idwMinute = Convert.ToInt32(date.Minute.ToString());
            //int idwSecond = Convert.ToInt32(date.Second.ToString());

            //if (devCon.SetDeviceTime2(iMachineNumber, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond))
            //{
            //    devCon.RefreshData(iMachineNumber);//the data in the device should be refreshed
            //    //lblOutputInfo.Items.Add("Successfully set the time");
            //}
            //else
            //{
            //    devCon.GetLastError(ref idwErrorCode);
            //    //lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            //}

            return 1;
        }
        #endregion

        

        #region control

        public int sta_btnRestartDevice()
        {
            if (IsConnected() == false)
            {
                ////lblOutputInfo.Items.Add("*Please connect first!");
                return -1024;
            }



            if (devCon.RestartDevice(iMachineNumber))
            {
                DisConnect();
                ////lblOutputInfo.Items.Add("The device will restart");
            }
            else
            {
                devCon.GetLastError(ref idwErrorCode);
                ////lblOutputInfo.Items.Add("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return 1;
        }

        #endregion

        #endregion

        #endregion
    }
}