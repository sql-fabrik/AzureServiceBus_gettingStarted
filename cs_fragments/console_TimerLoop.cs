using System;
using System.Timers;

//--  original "Timer-App" from
//--  https://learn.microsoft.com/de-de/dotnet/api/system.timers.timer?view=net-8.0
//--  -----------------------------------------------------------------------------

namespace cons_ReadFromSqlDB
{
    class Program
    {
        private static System.Timers.Timer aTimer;

        static void Main()
        {
            SetTimer();

            Console.WriteLine("Press the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}   \n", DateTime.Now);
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
            aTimer.Enabled   = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        }
    }
}
//----  end  ----
