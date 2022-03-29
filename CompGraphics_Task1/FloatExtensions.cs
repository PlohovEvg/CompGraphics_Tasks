using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphics_Task1
{
    static class FloatExtensions
    {
        public static float ToRadians(this float degrees)
        {
            return (float)(degrees * Math.PI / 180);
        }
    }
}
