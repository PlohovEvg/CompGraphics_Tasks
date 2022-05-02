using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Point3D_ok
    {
        public float x { get; set; }
        public float y {get;set;}
        public float z { get; set; }

        public Point3D_ok()
        {
            x = y = z = 0.0f;
        }

        public Point3D_ok(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public PointF ConvertToPoint2D()
        {
            return new PointF(x, y);
        }

        public Matrix ToMatrix()
        {
            return new Matrix(4, 1, new float[] { x, y, z, 1.0f });
        }

        public override string ToString()
        {
            return String.Format("({0}; {1}; {2}; 1)", x, y, z);
        }
    }
}
