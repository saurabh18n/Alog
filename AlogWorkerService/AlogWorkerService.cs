using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
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
            if (dbAccess.checkSqlConnection())
            {
                Task.Run(() => startSendSmsTask()).ConfigureAwait(false);
                Task.Run(() => startBackupTask()).ConfigureAwait(false);
            }

        }

        private void startBackupTask()
        {
            logger.Write("Registering  Backup Task");
            BackUPtimer = new System.Timers.Timer(27000); //Timer for 45 Min (2700000)MS
            BackUPtimer.AutoReset = true;
            BackUPtimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    logger.Write("Starting Backup Task");
                    BackUPtimer.Stop();
                    DateTime Now = DateTime.Now;
                    if (Now.Hour == 16 & Properties.Settings.Default.lastBackup.Date < Now.Date) //
                    {
                        logger.Write("Time to Backup... Startign to backup");
                        int failCount = 0;
                        bool checkoutall = false;
                        while (true)
                        {
                            if (dbAccess.checkoutAll() & !checkoutall)
                            {
                                logger.Write($"Check Out All Successfully done after {failCount} retries at {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
                                checkoutall = true;
                                failCount = 0;
                                break;
                            }
                            else
                            {
                                failCount++;
                                logger.Write($"Error Whle Checking All Out Fail Count {failCount}");
                                if (failCount >= 5)
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
                }
                catch (Exception ex)
                {
                    logger.Write("Error " + ex.Message);
                }
                finally
                {
                    BackUPtimer.Start();
                }
                
            };
            BackUPtimer.Start();

        }

        private void startSendSmsTask()
        {
            smsTimer = new System.Timers.Timer(2000);
            smsTimer.AutoReset = true;
            smsTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>
            {
                try
                {
                    smsTimer.Stop();
                    DataTable dt = dbAccess.getSmsList();
                    string sid = string.Empty;
                    logger.Write($"{dt.Rows.Count} SMS Fatched to send");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow Row in dt.Rows)
                        {
                            sms sms = new sms() { to = (string)Row[1], message = (string)Row[2] };
                            sid = sendSms(sms);
                            if (!(sid == "Error"))
                            {
                                Row[3] = 1;
                                Row[4] = DateTime.Now;
                                Row[5] = sid;
                                logger.Write("SMS Sent " + sms.message + " " + sid);
                            }
                            else
                            {
                                logger.Write($"Error Sending Message to {(string)Row.ItemArray[1]}");
                            }
                        }
                        dbAccess.setSmsList(dt);
                    }

                }
                catch (Exception ex)
                {
                    logger.Write("Error Sending SMS " + ex.ToString());
                }
                finally
                {
                    smsTimer.Start();
                }

            };
            smsTimer.Start();
        }

        public void Stop()
        {
            try
            {
                smsTimer.Stop();
                BackUPtimer.Stop();
            }
            catch (Exception ex)
            {
                logger.Write("Error Stopping Service " + ex.Message);
            };
        }

        internal string sendSms(sms message)
        {
            string sid = "Error";
            if (Properties.Settings.Default.sendMessage)
            {
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
                    }
                    catch (Exception ex)
                    {
                        logger.Write("Error Sending SMS" + ex.Message);
                        sid = "Error";
                    }
                }
            }
            else
            {
                sid = "Debug Mode - Not Sending Message";
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
                using (SqlCommand command = new SqlCommand("sp_attendence_backup", myConn))
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
            }
            return flag;
        }
    }

    public class sms
    {
        public string to { get; set; }
        public string message { get; set; }
    }
}

