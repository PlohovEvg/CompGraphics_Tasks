using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CompGraphics_Task1
{
    public class Spiral
    {
        private List<PointF> points; 

        public Spiral()
        {
            points = new List<PointF>();
        }

        public void AddPoint(PointF point)
        {
            points.Add(point);
        }

        public List<PointF> GetPoints()
        {
            return points;
        }

        public void SetPointList(IEnumerable<PointF> newList)
        {
            points.Clear();
            points = new List<PointF>(newList);
        }

        public void ClearPointsList()
        {
            points.Clear();
        }
    }
}
