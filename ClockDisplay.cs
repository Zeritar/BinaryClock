using System;
using System.Drawing;
using System.Threading;
using Iot.Device.Common;
using Iot.Device.SenseHat;
using UnitsNet;

namespace BinaryClock
{
    /// <summary>
    /// Class implementing methods for handling clock and printing to LED Matrix. Also has method for reading joystick.
    /// </summary>
    public class ClockDisplay
    {
        SenseHat sh;
        Color hour24 = Color.FromArgb(50, 100, 200);
        Color am = Color.FromArgb(50, 150, 50);
        Color pm = Color.FromArgb(200, 100, 0);
        Color off = Color.FromArgb(0, 0, 0);

        public ClockDisplay(SenseHat sh)
        {
            this.sh = sh;
            Program.OnPressedUp += OnPressedUp;
            Program.OnPressedDown += OnPressedDown;
            Program.OnPressedLeft += OnPressedLeft;
            Program.OnPressedRight += OnPressedRight;
        }

        public ClockDisplay(SenseHat sh, bool twentyfour, bool tall) : this(sh)
        {
            this.twentyfour = twentyfour;
            this.tall = tall;
        }

        public bool twentyfour = true;
        public bool tall = false;

        /// <summary>
        /// Method for getting current time, converting to binary and writing it to LED Matrix using current settings.
        /// </summary>
        public void UpdateDisplay()
        {
            DateTime time = DateTime.Now;

            Color on = new Color();

            if (twentyfour)
            {
                on = hour24;
            }
            else
            {
                if (time.Hour == 0)
                {
                    time = time.AddHours(12);
                }

                if (time.Hour > 12)
                {
                    time = time.AddHours(-12);
                    on = pm;
                }
                else if (time.Hour == 12)
                {
                    on = pm;
                }
                else
                {
                    on = am;
                }
            }
            
            if (tall)
            {
                for (int i = 0; i < 8; i++)
                {
                    setPixel(4, 7-i, (time.Hour & (int)Math.Pow(2, i)) > 0 ? on : off);
                }

                for (int i = 0; i < 8; i++)
                {
                    setPixel(2, 7-i, (time.Minute & (int)Math.Pow(2, i)) > 0 ? on : off);
                }

                for (int i = 0; i < 8; i++)
                {
                    setPixel(0, 7-i, (time.Second & (int)Math.Pow(2, i)) > 0 ? on : off);
                }
                
                for (int i = 1; i < 4; i+=2)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        setPixel(i, j, off);
                    }
                    
                }

                for (int i = 5; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        setPixel(i, j, off);
                    }
                    
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    setPixel(i, 0, (time.Hour & (int)Math.Pow(2, i)) > 0 ? on : off);
                }

                for (int i = 0; i < 8; i++)
                {
                    setPixel(i, 1, (time.Minute & (int)Math.Pow(2, i)) > 0 ? on : off);
                }

                for (int i = 0; i < 8; i++)
                {
                    setPixel(i, 2, (time.Second & (int)Math.Pow(2, i)) > 0 ? on : off);
                }

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 3; j < 8; j++)
                    {
                        setPixel(i, j, off);
                    }
                    
                }
            }
        }

        public void TurnOff()
        {
            sh.Fill(off);
        }

        void setPixel(int x, int y, Color color)
        {
            sh.SetPixel(7 - x, y, color);
        }

        void OnPressedUp(object? sender, EventArgs e)
        {
            tall = false;
        }

        void OnPressedDown(object? sender, EventArgs e)
        {
            tall = true;
        }

        void OnPressedLeft(object? sender, EventArgs e)
        {
            twentyfour = false;
        }

        void OnPressedRight(object? sender, EventArgs e)
        {
            twentyfour = true;
        }

        /// <summary>
        /// Gets current state of the joystick.
        /// </summary>
        public HatState JoystickState()
        {
            sh.ReadJoystickState();

            int dx = 0;
            int dy = 0;

            if (sh.HoldingUp)
            {
                dy--;
            }

            if (sh.HoldingDown)
            {
                dy++;
            }

            if (sh.HoldingLeft)
            {
                dx--;
            }

            if (sh.HoldingRight)
            {
                dx++;
            }

            return new HatState(dx, dy, sh.HoldingButton);
        }

    }
}
