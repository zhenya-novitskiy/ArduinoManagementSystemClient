using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Threading;
using Timer = System.Timers.Timer;

namespace ArduinoManagementSystem.Components.SystemController.Core
{


    public static class SystemViewerCore
    {
        static PerformanceCounter cpuCounter;
        static PerformanceCounter ramAvailableCounter;
        static PerformanceCounter ramUsedCounter;
        private static readonly Timer Clock;
        private static int TimerInterval = 200;

        public static event EventHandler<SystemDataArgs> DataUpdated;

        static SystemViewerCore()
        {

            cpuCounter = new PerformanceCounter
                             {CategoryName = "Processor", CounterName = "% Processor Time", InstanceName = "_Total"};
            ramAvailableCounter = new PerformanceCounter("Memory", "Available MBytes");
            ramUsedCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            Clock = new Timer {Interval = TimerInterval};

            Clock.Elapsed += new ElapsedEventHandler(Clock_Elapsed);

            Clock.Start();
        }

        static void Clock_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DataUpdated != null)
            {
                DataUpdated(new Int32(), new SystemDataArgs() { Value1 = GetCpuUsage(), Value2 = GetRAMUsed()});
            }
        }

        public static string GetCurrentCpuUsage()
        {
            return cpuCounter.NextValue() + "%";
        }

        public static double GetCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        public static double GetRAMAvailable()
        {
            var bbb = ramAvailableCounter.NextValue();

            return ramAvailableCounter.NextValue();
        }
        public static double GetRAMTotal()
        {
            var total = 8096;//GetRAMUsed() + GetRAMAvailable();

            if (total > 8000 && total < 8500)
                return 8192;
            if (total > 6000 && total < 6500)
                return 6144;
            if (total > 3900 && total < 4500)
                return 4096;
            if (total > 2900 && total < 3500)
                return 3072;
            if (total > 1900 && total < 2500)
                return 2048;
            if (total > 900 && total < 1500)
                return 1024;
            return total;
        }
        public static double GetRAMUsed()
        {
            var aaa = ramUsedCounter.NextValue();

            return (ramUsedCounter.NextValue() * 100) ;
        } 
    }

    public class SystemDataArgs : EventArgs
    {
        public double Value1;
        public double Value2;
    }
}
