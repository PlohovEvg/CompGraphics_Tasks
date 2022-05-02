using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphics_Task1
{
    public static class DoubleExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static double ToDegrees(this double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}
