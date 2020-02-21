using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AlogWorkerService
{
    public class WorkerService
    {
        #region Variable Initialization
        //There will be 2 distinct function
        // 1 send smsm
        // 2 Manager Sheduled Task
        //===============================
        //Send Message will check every minute for scheduled message in tables and if present pick 10 to execute
        //
        //

        Log logger = Log.Instance; // Logging
        System.Timers.Timer smsTimer;
        System.Timers.Timer BackUPtimer;
        DbAccess dbAccess = new DbAccess(ConfigurationManager.ConnectionStrings["default"], Log.Instance);
        #endregion

        public void Start()
        {
            TwilioClient.Init(Properties.Settings.Default.accountSid, Properties.Settings.Default.authToken);
            logger.Write("Starting Worker Service");
            dbAccess.checkSqlConnection();
            Task.Run(() => startSendSmsTask()).ConfigureAwait(false);
            Task.Run(() => startBackupTask());
        }

        private void startBackupTask()
        {
            logger.Write("Starting Backup Task");
            BackUPtimer = new System.Timers.Timer(2700000); //Timer for 45 Min (2700000)MS
            BackUPtimer.AutoReset = true;
            BackUPtimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
                logger.Write("Starting Elepsed Function");
                BackUPtimer.Stop();
                DateTime Now = DateTime.Now;
                if (Now.Hour == 1 & Properties.Settings.Default.lastBackup.Date < Now.Date) //
                {
                    int failCount = 0;
                    bool checkoutall = false;
                    while (true)
                    {
                        if (dbAccess.checkoutAll() & !checkoutall)
                        {
                            logger.Write($"Check Out All Successfully done after {failCount} retries ");
                            checkoutall = true;
                            failCount = 0;                            
                            break;
                        }
                        else
                        {
                            failCount++;
                            logger.Write($"Error Whle Checking All Out Fail Count {failCount}");
                            if(failCount >= 5)
                            {
                                break;
                            }
                        }

                    } //Try 5 Times to Checkout All
                    while (checkoutall)
                    {
                        if (dbAccess.createBackup())
                        {
                            logger.Write($"Backup Successfully done after {failCount} retries ");
                            Properties.Settings.Default.lastBackup = DateTime.Now;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                            break;
                        }
                        else
                        {
                            failCount++;
                            logger.Write($"Error Creating backup Fail Count {failCount}");
                            if (failCount >= 5)
                            {
                                break;
                            }
                        }

                    } //Try 5 Times to Create Backup
                }
                BackUPtimer.Start();
            };
            BackUPtimer.Start();
            
        }

        private async Task<string> getLastSms()
        {
            using (HttpClient Client = new HttpClient())
            {
                Client.BaseAddress = new Uri("https://api.sms.to/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer KxA8qxTk9MNkfC1oXEKTC389QniaXRAW");
                HttpResponseMessage hrs = await Client.GetAsync("last/message");

                return await hrs.Content.ReadAsStringAsync();
            }


        }

        private void startSendSmsTask()
        {
            smsTimer = new System.Timers.Timer(2000);
            smsTimer.AutoReset = true;
            smsTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e)=>
            {
                
                smsTimer.Stop();
                DataTable dt = dbAccess.getSmsList();
                string sid = string.Empty;
                logger.Write($"{dt.Rows.Count} SMS Fatched to send");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow Row in dt.Rows)
                    {
                        sms smsLoc = new sms() { to = (string)Row.ItemArray[1], message = (string)Row.ItemArray[2] };
                        sid = sendSms(smsLoc);
                        if(!(sid == "Error"))
                        {
                            Row[3] = 1;
                            Row[4] = DateTime.Now;
                            Row[5] = sid;
                        }
                        else
                        {
                            logger.Write($"Error Sending Message to {(string)Row.ItemArray[1]}");
                        }
                    }
                    dbAccess.setSmsList(dt);
                }
                smsTimer.Start();
            };
            smsTimer.Start();
        }

        public void Stop()
        {
            smsTimer.Stop();
            BackUPtimer.Stop();
        }

        internal string sendSms(sms message)
        {
            string sid = "Error";
            if (message != null)
            {
                
                var messageOptions = new CreateMessageOptions(
                new PhoneNumber(message.to));
                messageOptions.From = new PhoneNumber(Properties.Settings.Default.fromPhone);
                messageOptions.Body = message.message;
                try
                {
                    var result = MessageResource.Create(messageOptions);
                    Console.WriteLine(result.Sid);
                    sid = result.Sid;                    
                    logger.Write("SMS Sent " + message.message + " " + sid );                    
                }
                catch (Exception ex)
                {
                    logger.Write("Error Sending SMS" + ex.Message);
                    sid = "Error";
                }
            }
            return sid;
        }

        private void ResetTimer(System.Timers.Timer timer)
        {
            timer.Stop();
            timer.Start();
        }

    }

    public sealed class Log
    {
        StreamWriter writer;

        private static Log instance;

        private static object syncRoot = new Object();

        private Log() { }

        public static Log Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Log()
                            {
                                writer = File.AppendText("AlogWorkerServiceLog-" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")
                            };
                        }
                    }
                }
                return instance;
            }

        }

        public void Write(string message)
        {
            {
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff") + "    " + message);
                writer.AutoFlush = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff") + "    " + message);
            }
        }
    }

    public class DbAccess
    {
        ConnectionStringSettings CS;
        Log logger;
        public DbAccess(ConnectionStringSettings ConnectionString, Log log)
        {
            CS = ConnectionString;
            logger = log;
        }
        internal bool checkSqlConnection()
        {
            try
            {
                using (SqlConnection myConn = new SqlConnection(CS.ConnectionString))
                    myConn.Open();
                logger.Write("DB Connection Successfull");
                return true;
            }
            catch (SqlException ex)
            {
                logger.Write($"SQL Error {ex.Message}");
                return false;
            }
        }

        internal DataTable getSmsList()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection myConn = new SqlConnection(CS.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_get_smstosend", myConn) { CommandType = System.Data.CommandType.StoredProcedure })
                    {
                        try
                        {
                            myConn.Open();
                            dt.Load(command.ExecuteReader());
                        }
                        catch (SqlException ex)
                        {
                            logger.Write($"SQL Error While Getting SMS to send {ex.Message}");
                        }
                        return dt;
                    }
                }
            }
        }

        internal bool setSmsList(DataTable dt)
        {
            bool flag = false;
            dt.Columns.Remove("sms_mobile");
            dt.Columns.Remove("sms_content");

            using (SqlConnection myConn = new SqlConnection(CS.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_update_message_sent", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@smstable", dt).TypeName = "message_sent_update";
                    try
                    {
                        myConn.Open();
                        command.ExecuteNonQuery();
                        flag = true;
                    }
                    catch (SqlException ex)
                    {
                        logger.Write("SQL Error " + ex.Message);
                        flag = false;
                    }
                }
            }
            return flag;
        }

        internal bool checkoutAll()
        {
            bool flag = false;
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.conString))
            using (SqlCommand command = new SqlCommand("sp_update_checkoutall", myConn))
            {
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    myConn.Open();
                    command.ExecuteNonQuery();
                    flag = true;
                }
                catch (SqlException ex)
                {
                    logger.Write("SQL ERROR Checking out all student" + ex.Message);
                    flag = false;
                }
            }

                return flag;
        }

        internal bool createBackup() // Create Attandence Back From currunt day table to archive table
        {
            bool flag = false;
            using (SqlConnection myConn = new SqlConnection(Properties.Settings.Default.conString))
            {
                using (SqlCommand command = new SqlCommand("sp_create_attendence_backup", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.ExecuteNonQuery();
                        flag = true;
                    }
                    catch (SqlException ex)
                    {
                        flag = false;
                        logger.Write("SQL ERROR creating attandence backup" + ex.Message);
                    }                   

                }
            }                return flag;


        }
    }

    public class sms
    {
        public string to { get; set; }
        public string message { get; set; }
    }

    public class returnMesssage
    {
        public int sms_count { get; set; }
        public float estimated_cost { get; set; }
        public int contact_count { get; set;}
        public int invalid_count { get; set; }
    }
}

