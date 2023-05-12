using System;
using System.Text;
using System.Drawing;
using System.Threading;
using Iot.Device.Common;
using Iot.Device.SenseHat;
using Iot.Device.SenseHatText;
using UnitsNet;

namespace BinaryClock
{
    public class Program
    {
        static ClockDisplay clockDisplay;

        static SenseHat sh;

        public static event EventHandler OnPressedUp;
        public static event EventHandler OnPressedDown;
        public static event EventHandler OnPressedLeft;
        public static event EventHandler OnPressedRight;

        static HatState prevState = new HatState();
        static HatState currentState = new HatState();

        static bool exiting = false;


        /// <summary>
        /// Main program method. Gets command line arguments and initiates ClockDisplay.
        /// </summary>
        public static void Main(string[] args)
        {

        bool twentyfour = true;
        bool tall = false;
        bool exitloop = false;

            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    switch (arg)
                    {
                        case "-V":
                        case "--vertical":
                            tall = true;
                            break;
                        case "-A":
                        case "--ampm":
                            twentyfour = false;
                            break;
                        case ">":
                            exitloop = true;
                            break;
                        default:
                            ShowHelp();
                            break;

                    }

                    if (exitloop)
                        break;
                }
            }

            sh = new SenseHat();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            Console.CancelKeyPress += delegate {
                    exit();
                };

            Logger.Log(sh, "Programmet starter");

            clockDisplay = new ClockDisplay(sh, twentyfour, tall);

            while (!exiting)
            {
                if (!Logger.logging)
                {
                    currentState = clockDisplay.JoystickState();

                    if (currentState.holding)
                    {
                        Environment.Exit(0);
                    }

                    if (currentState.dx > 0 && prevState.dx <= 0)
                    {
                        OnPressedRight.Invoke(null, null);
                    }
                    else if (currentState.dx < 0 && prevState.dx >= 0)
                    {
                        OnPressedLeft.Invoke(null, null);
                    }

                    if (currentState.dy > 0 && prevState.dy <= 0)
                    {
                        OnPressedDown.Invoke(null, null);
                    }
                    else if (currentState.dy < 0 && prevState.dy >= 0)
                    {
                        OnPressedUp.Invoke(null, null);
                    }

                    clockDisplay.UpdateDisplay();
                }

                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Print help information to console, then exit program.
        /// </summary>
        static void ShowHelp()
        {
            StringBuilder helpText = new StringBuilder();
            helpText.AppendLine("Usage: dotnet yourapp.dll [OPTIONS]");
            helpText.AppendLine("Displays a binary clock on the SenseHat LED Matrix.");
            helpText.AppendLine();
            helpText.AppendLine("Options:");
            helpText.AppendLine("-V, --vertical\t\tDisplay the clock in vertical format.");
            helpText.AppendLine("-A, --ampm\t\tDisplay the clock in 12 hour mode with AM/PM indication.");
            helpText.AppendLine("-?, --help\t\tDisplay this help message.");

        Console.WriteLine(helpText.ToString());
            Environment.Exit(0);
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            exit();
        }

        static void exit()
        {
            exiting = true;
            if (clockDisplay != null)
                clockDisplay.TurnOff();
            if (sh != null)
                Logger.Log(sh, "Programmet slutter");
            else
                Logger.Log("Programmet slutter");
        }

    }
}

