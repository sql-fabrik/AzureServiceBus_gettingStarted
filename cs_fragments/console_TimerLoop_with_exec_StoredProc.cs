using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Timers;

//--  original "Timer-App" from
//--  https://learn.microsoft.com/de-de/dotnet/api/system.timers.timer?view=net-8.0
//--  -----------------------------------------------------------------------------

namespace cons_ReadFromSqlDB
{
    class Program
    {
        private static System.Timers.Timer aTimer;

        string connectionString = "Server=localhost\\s2019;DataBase=bwtBI;Integrated Security=SSPI";
        string storedProcName   = "dbo.usp_get_sampleJSON";

        static void Main()
        {
            SetTimer();

            Console.WriteLine("Press the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff} \n", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);

            Program p = new Program();
            p.RunStoredProc();
        }

        public void RunStoredProc()
        {
            Console.WriteLine("SQL start connection ...");
            //************************************************************************
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(storedProcName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if( String.IsNullOrEmpty( reader[0].ToString() ) )
                        {
                            Console.WriteLine("derzeit alle Daten verarbeitet");
                        }
                        else
                        {
                            Console.WriteLine("zelle1 ist " + reader[0] + " => (IsJSON_returnValue) " + reader[1] );
                        }
                        //-- end if
                    }
                }
            }
            //************************************************************************
            Console.WriteLine("SQL connection finished.");
        }
    }
}
//----  end  ----

