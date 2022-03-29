using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphics_Task1
{
    static class DoubleExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
