using System;
using System.Collections.Generic;
using System.Text;

namespace Manipulations
{
    class Color
    {
        public static void GreenColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void RedColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void YellowColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void DefaultColor()
        {
            Console.ResetColor();
        }

    }
}
