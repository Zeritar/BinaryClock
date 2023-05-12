using System;
using System.Drawing;
using System.Threading;
using Iot.Device.Common;
using Iot.Device.SenseHat;
using UnitsNet;

using SenseHat sh = new SenseHat();

Color on = Color.FromArgb(150, 150, 150);
Color off = Color.FromArgb(0, 0, 0);

Console.Clear();

Console.WriteLine("Programmet starter");

Console.CancelKeyPress += delegate {
        sh.Fill(Color.FromArgb(0, 0, 0));
        Console.WriteLine("\r\nProgrammet slutter");
    };

while (true)
{

    (int dx, int dy, bool holding) = JoystickState(sh);

    // if (holding)
    // {
    //     n++;
    // }

    // x = (x + 8 + dx) % 8;
    // y = (y + 8 + dy) % 8;

    DateTime time = DateTime.Now;




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

    Thread.Sleep(1000);
}

void setPixel(int x, int y, Color color)
{
    sh.SetPixel(7 - x, y, color);
}

(int, int, bool) JoystickState(SenseHat sh)
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

    return (dx, dy, sh.HoldingButton);
}
