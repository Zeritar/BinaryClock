using System;
using System.Drawing;
using Iot.Device.SenseHat;
using Iot.Device.SenseHatText;

namespace BinaryClock
{
    /// <summary>
    /// Contains static methods for logging to console and to SenseHat LED Matrix.
    /// </summary>
    public class Logger
    {
        public static bool logging = false;
        public static void Log(string message)
        {
            logging = true;
            DateTime time = DateTime.Now;
            Console.WriteLine(time.ToShortTimeString() + " - " + message);
            logging = false;
        }

        public static void Log(SenseHat sh, string message)
        {
            logging = true;
            sh.ShowMessage(message, 30, Color.FromArgb(50, 100, 200));
            DateTime time = DateTime.Now;
            Console.WriteLine(time.ToShortTimeString() + " - " + message);
            logging = false;
        }
    }
}