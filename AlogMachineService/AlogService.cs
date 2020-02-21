using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net.NetworkInformation;
using System.Data;

namespace AlogService
{
    public class AlogSvc
    {
        #region Variables
        private string deviceip = ConfigurationManager.AppSettings.Get("machine_ip");
        private string deviceport = ConfigurationManager.AppSettings.Get("port");
        const string timeFormat = "dd-MM-yyyy hh:mm:ss.fff";
        Log log = Log.Instance;
        DbAccess dbAccess = new DbAccess(ConfigurationManager.ConnectionStrings["default"], Log.Instance);
        public SDKHelper TDecvice = new SDKHelper(Log.Instance); // TimeDox Device
        bool sqlSuccess = false;
        private bool isConnected = false;
        System.Timers.Timer pingTimer;
        System.Timers.Timer TerminalUpdateTimer;
        System.Timers.Timer CheckMachineConnectedTimer;

        #endregion

        public void Start()
        {            
            log.Write("Alog Service Started");
            sqlSuccess = dbAccess.checkSqlConnection();
            CheckMachineConnected();
            connect();
            Task.Run(()=> TerminalUpdate());            
        }

        private void CheckMachineConnected()
        {
            CheckMachineConnectedTimer = new System.Timers.Timer(500);
            CheckMachineConnectedTimer.AutoReset = true;
            CheckMachineConnectedTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) =>{
                if (isConnected)
                {
                    CheckMachineConnectedTimer.Stop();
                    if (!TDecvice.devCon.ReadRTLog(1))
                    {
                        isConnected = false;                        
                        log.Write("Device Connection Lost. Trying to reconnect device");                        
                        connect();
                    }
                    else
                    {
                        CheckMachineConnectedTimer.Start();

                    }
                }

            };
        }

        private void TerminalUpdate()
        {
            TerminalUpdateTimer = new System.Timers.Timer(10000);
            TerminalUpdateTimer.AutoReset = true;
            TerminalUpdateTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
                
                if (isConnected)
                {
                    
                    DataTable dt = new DataTable();
                    dt = dbAccess.GetTerminalUpdate();
                    log.Write($"Processing  {dt.Rows.Count} Terminal Updates");
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            TerminalUpdateTimer.Stop();
                            // u_type 1 add,2 delete,3 update
                            foreach (DataRow Row in dt.Rows)
                            {
                                if ((byte)Row[1] == 1 || (byte)Row[1] == 3) //Add / Modily Student
                                {
                                    if (TDecvice.AddUser(((int)Row[2]).ToString(), (string)Row[3]))
                                    {
                                        Row[4] = DateTime.Now;
                                        log.Write($"Student with Sid { ((int)Row[2]).ToString()}  Successfully added to Clock");
                                    }

                                }
                                else if ((byte)Row[1] == 2)// Delete Student
                                {
                                    if (TDecvice.DeleteUser(((int)Row[2]).ToString()))
                                    {
                                        Row[4] = DateTime.Now;
                                        log.Write($"User with id {(string)Row[2]} Successfully Deleted From Clock");
                                    }
                                    else
                                    {
                                        if (!TDecvice.isUserExist(((int)Row[2]).ToString()))
                                        {
                                            Row[4] = DateTime.Now;
                                        }
                                    }
                                }
                                else
                                {
                                    log.Write($"Wrong Value called in terminal update as update type for update id  {(int)Row[0]} student {(string)Row[3]} ");
                                }

                            }
                            dbAccess.SetTerminalUpdate(dt); //Update the result to db.

                        }

                    }
                    catch (Exception ex)
                    {
                        log.Write("Terminal update block Error" + ex.Message);
                    }
                    finally
                    {
                        TerminalUpdateTimer.Start();
                    }
                    
                }
                else
                {
                    log.Write("Terminal update Failed - Device Not connected");
                } 
                
            };
            TerminalUpdateTimer.Start();
        }

        private void connect() // Connect Device
        {
            log.Write("Trying to Connect to device ....");
            if (TDecvice.Connect(deviceip, deviceport))
            {

                this.TDecvice.devCon.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(devCon_OnAttTransactionEx);
                this.TDecvice.devCon.OnDisConnected += new zkemkeeper._IZKEMEvents_OnDisConnectedEventHandler(devCon_OnDisconnected);
                isConnected = true;
                CheckMachineConnectedTimer.Start();
            }
            else
            {
                log.Write("Device Connection failed switching to retry mode....");
                pingTimer = new System.Timers.Timer(30000);
                pingTimer.AutoReset = true;
                pingTimer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => {
                    {
                        using (Ping pinger = new Ping())
                        {
                            PingReply pr = pinger.Send(deviceip);
                            if (pr.Status == IPStatus.Success)
                            {
                                pingTimer.Stop();
                                pingTimer.Dispose();
                                connect();
                            }
                            else
                            {
                                log.Write($"{deviceip} Not Rechable {DateTime.Now.ToString("dd/MM/yyyy hh:MM:ss.fff")}");
                            }
                        }

                    }

                };
                pingTimer.Start();
            }
        }

        private void devCon_OnDisconnected()
        {
            log.Write("Device Disconnected. Trying to reconnect");            
        }

        private void devCon_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            DateTime date = new DateTime(Year, Month, Day, Hour, Minute, Second);
            int enroll = Convert.ToInt32(EnrollNumber);
            Task.Run(() => dbAccess.WriteAttRecord(enroll, date));
        }

        public void Stop()
        {
            try
            {
                pingTimer.Stop();
                TerminalUpdateTimer.Stop();
                CheckMachineConnectedTimer.Stop();
            }
            catch (Exception ex)
            {
                log.Write("Error Stopping service");
            }           

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
                                writer = File.AppendText("AlogServiceLog-" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt")
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
        public bool checkSqlConnection()
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

        public void WriteAttRecord(int EnrollNumber, DateTime Atttime)
        {
            using (SqlConnection myConn = new SqlConnection(CS.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_write_attrecord", myConn) { CommandType = System.Data.CommandType.StoredProcedure })
                {

                    command.Parameters.AddWithValue("@stuid", EnrollNumber);
                    try
                    {
                        myConn.Open();
                        command.ExecuteNonQuery();
                        logger.Write($"Written Attandence record for {EnrollNumber} at {Atttime.ToLongTimeString()} ");
                    }
                    catch (SqlException ex)
                    {
                        logger.Write($"SQL Error While Writing {EnrollNumber} at {Atttime.ToLongTimeString()} {ex.Message}");
                    }
                }
            }

        }

        public DataTable GetTerminalUpdate()
        {
            DataTable dt = new DataTable();
            using (SqlConnection myConn = new SqlConnection(CS.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_get_terminal_updates", myConn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        myConn.Open();
                        dt.Load(command.ExecuteReader());
                        logger.Write("Terminal Update sent from db");

                    }
                    catch (SqlException ex)
                    {
                        logger.Write("SQL Error " + ex.Message);                                               
                    }                    
                }
            }
                return dt;
        }

        public void SetTerminalUpdate(DataTable dt)
        {
            if (!(dt == null))
            {
                dt.Columns.Remove("u_type");
                dt.Columns.Remove("u_studentid");
                dt.Columns.Remove("u_name");
                using (SqlConnection myConn = new SqlConnection(CS.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_set_terminalUpdate", myConn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@updateTable", dt).TypeName = "terminalUpdate";
                        try
                        {
                            myConn.Open();
                            command.ExecuteNonQuery();
                            logger.Write("Terminal update successfully updatet to DB");
                        }
                        catch (SqlException ex)
                        {
                            logger.Write($"DB Error Set Terminal Update Error {ex.Message}");
                            string message = "Update Ids: ";
                            foreach (DataRow Row in dt.Rows)
                            {
                                message = message + ", " + ((int)Row[0]).ToString();
                            }
                            logger.Write(message);
                        }
                    }
                }

            }

        }
    }
}

