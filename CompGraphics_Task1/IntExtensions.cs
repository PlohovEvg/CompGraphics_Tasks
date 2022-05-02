using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphics_Task1
{
    public static class IntExtensions
    {
        public static double ToRadians(this int degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static bool IsInRange(this int val, int min, int max)
        {
            return val >= min && val <= max;
        }
    }
}
