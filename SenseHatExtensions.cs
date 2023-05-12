using System.Drawing;
using Iot.Device.SenseHat;

namespace Iot.Device.SenseHatText
{
    /// <summary>
    /// <para>Extension methods for SenseHat.</para>
    /// <para>Credit: sanme98 on Github.</para>
    /// <para>https://github.com/sanme98/dotnet-sense-hat-text</para>
    /// </summary>
    public static class SenseHatTextExtensions
    {
        public static void ShowMessage(this SenseHat.SenseHat sh, string message, int scroll_speed = 30, Color? text_colour = null, Color? back_colour = null, bool isVertical = false)
        {
            SenseHatText.Instance.ShowMessage(sh.LedMatrix, message, scroll_speed, text_colour, back_colour, isVertical);
        }

        public static void ShowLetter(this SenseHat.SenseHat sh, string letter, Color? text_colour = null, Color? back_colour = null)
        {
            SenseHatText.Instance.ShowLetter(sh.LedMatrix, letter, text_colour, back_colour);
        }

        public static void Clear(this SenseHat.SenseHat sh)
        {
            SenseHatText.Instance.Clear(sh.LedMatrix);
        }
    }
}