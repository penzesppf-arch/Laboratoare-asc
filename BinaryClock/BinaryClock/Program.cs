using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryClock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                int hours = now.Hour;
                int minutes = now.Minute;
                int seconds = now.Second;
                string binaryHours = Convert.ToString(hours, 2).PadLeft(6, '0');
                string binaryMinutes = Convert.ToString(minutes, 2).PadLeft(6, '0');
                string binarySeconds = Convert.ToString(seconds, 2).PadLeft(6, '0');
                Console.Clear();
                Console.WriteLine("Binary Clock");
                Console.WriteLine("============");
                Console.WriteLine($"Hours  : {binaryHours}");
                Console.WriteLine($"Minutes: {binaryMinutes}");
                Console.WriteLine($"Seconds: {binarySeconds}");
                Thread.Sleep(1000);

            }
        }
    }
}
