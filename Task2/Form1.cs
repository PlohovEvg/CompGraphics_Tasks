using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CompGraphics_Task1;

namespace Task2
{
    public partial class Form1 : Form
    {
        Bitmap isoImage;
        Graphics isoImageGraphics;

        Matrix projectionZMatrix;
        Matrix rotationXMatrix;
        Matrix rotationYMatrix;

        List<Point3D_ok> modelPoints;

        int[] bottomLeftColonIndexes = new int[2];
        int[] topLeftColonIndexes = new int[2];
        int[] bottomRightColonIndexes = new int[2];
        int[] topRightColonIndexes = new int[2];

        int arcFirstIndex;

        public Form1()
        {
            InitializeComponent();

            projectionZMatrix = new Matrix(4,4,1.0f);
            projectionZMatrix.SetValueOnPosition(3, 3, 0.0f);
            InitRotationMatrix(Axis.X, Math.Asin(1 / Math.Sqrt(3)).ToDegrees());
            InitRotationMatrix(Axis.Y, 360 - 45);

            InitPoints();

            isoImage = new Bitmap(IsoImagePicBox.Width, IsoImagePicBox.Height);

            isoImageGraphics = Graphics.FromImage(isoImage);
            isoImageGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            isoImageGraphics.FillRectangle(Brushes.White, 0, 0, isoImage.Width, isoImage.Height);

            IsoImagePicBox.Image= isoImage;
        }

        private void InitPoints()
        {
            modelPoints = new List<Point3D_ok>();

            //Основная часть
            modelPoints.Add(new Point3D_ok(-162, 0, 61));
            modelPoints.Add(new Point3D_ok(-162, 377, 61));
            modelPoints.Add(new Point3D_ok(-162, 0, 0));
            modelPoints.Add(new Point3D_ok(-162, 377, 0));
            modelPoints.Add(new Point3D_ok(162, 0, 61));
            modelPoints.Add(new Point3D_ok(162, 377, 61));
            modelPoints.Add(new Point3D_ok(162, 0, 0));
            modelPoints.Add(new Point3D_ok(162, 377, 0));

            //Крыша
            modelPoints.Add(new Point3D_ok(-182, 377, 90));
            modelPoints.Add(new Point3D_ok(-182, 402, 90));
            modelPoints.Add(new Point3D_ok(-182, 377, 0));
            modelPoints.Add(new Point3D_ok(-182, 402, 0));
            modelPoints.Add(new Point3D_ok(182, 377, 90));
            modelPoints.Add(new Point3D_ok(182, 402, 90));
            modelPoints.Add(new Point3D_ok(182, 377, 0));
            modelPoints.Add(new Point3D_ok(182, 402, 0));

            //Постамент для левой колонны
            modelPoints.Add(new Point3D_ok(-122, 0, 287));
            modelPoints.Add(new Point3D_ok(-122, 118, 287));
            modelPoints.Add(new Point3D_ok(-122, 0, 61));
            modelPoints.Add(new Point3D_ok(-122, 118, 61));
            modelPoints.Add(new Point3D_ok(-72, 0, 287));
            modelPoints.Add(new Point3D_ok(-72, 118, 287));
            modelPoints.Add(new Point3D_ok(-72, 0, 61));
            modelPoints.Add(new Point3D_ok(-72, 118, 61));

            //Ступеньки (от нижней к верхней)
            modelPoints.Add(new Point3D_ok(-72, 0, 265));
            modelPoints.Add(new Point3D_ok(-72, 21, 265));
            modelPoints.Add(new Point3D_ok(-72, 0, 221));
            modelPoints.Add(new Point3D_ok(-72, 21, 221));
            modelPoints.Add(new Point3D_ok(76, 0, 265));
            modelPoints.Add(new Point3D_ok(76, 21, 265));
            modelPoints.Add(new Point3D_ok(76, 0, 221));
            modelPoints.Add(new Point3D_ok(76, 21, 221));

            modelPoints.Add(new Point3D_ok(-72, 21, 221));
            modelPoints.Add(new Point3D_ok(-72, 39, 221));
            modelPoints.Add(new Point3D_ok(-72, 21, 182));
            modelPoints.Add(new Point3D_ok(-72, 39, 182));
            modelPoints.Add(new Point3D_ok(76, 21, 221));
            modelPoints.Add(new Point3D_ok(76, 39, 221));
            modelPoints.Add(new Point3D_ok(76, 21, 182));
            modelPoints.Add(new Point3D_ok(76, 39, 182));

            modelPoints.Add(new Point3D_ok(-72, 39, 182));
            modelPoints.Add(new Point3D_ok(-72, 59, 182));
            modelPoints.Add(new Point3D_ok(-72, 39, 131));
            modelPoints.Add(new Point3D_ok(-72, 59, 131));
            modelPoints.Add(new Point3D_ok(76, 39, 182));
            modelPoints.Add(new Point3D_ok(76, 59, 182));
            modelPoints.Add(new Point3D_ok(76, 39, 131));
            modelPoints.Add(new Point3D_ok(76, 59, 131));

            modelPoints.Add(new Point3D_ok(-72, 59, 131));
            modelPoints.Add(new Point3D_ok(-72, 77, 131));
            modelPoints.Add(new Point3D_ok(-72, 59, 61));
            modelPoints.Add(new Point3D_ok(-72, 77, 61));
            modelPoints.Add(new Point3D_ok(76, 59, 131));
            modelPoints.Add(new Point3D_ok(76, 77, 131));
            modelPoints.Add(new Point3D_ok(76, 59, 61));
            modelPoints.Add(new Point3D_ok(76, 77, 61));

            //Арка
            //Нижняя часть
            modelPoints.Add(new Point3D_ok(-57, 77, 61));
            modelPoints.Add(new Point3D_ok(-57, 203, 61));
            modelPoints.Add(new Point3D_ok(-57, 77, 44));
            modelPoints.Add(new Point3D_ok(-57, 203, 44));
            modelPoints.Add(new Point3D_ok(57, 77, 61));
            modelPoints.Add(new Point3D_ok(57, 203, 61));
            modelPoints.Add(new Point3D_ok(57, 77, 44));
            modelPoints.Add(new Point3D_ok(57, 203, 44));

            //Постамент для правой колонны
            modelPoints.Add(new Point3D_ok(76, 0, 287));
            modelPoints.Add(new Point3D_ok(76, 118, 287));
            modelPoints.Add(new Point3D_ok(76, 0, 61));
            modelPoints.Add(new Point3D_ok(76, 118, 61));
            modelPoints.Add(new Point3D_ok(126, 0, 287));
            modelPoints.Add(new Point3D_ok(126, 118, 287));
            modelPoints.Add(new Point3D_ok(126, 0, 61));
            modelPoints.Add(new Point3D_ok(126, 118, 61));

            //Колонна левая
            //Нижнее основание
            AddCirclePoints(new Point3D_ok(-99, 118, 152), 12, 360, 10, ref bottomLeftColonIndexes[0], ref bottomLeftColonIndexes[1]);
            //Верхнее основание
            AddCirclePoints(new Point3D_ok(-99, 311, 152), 12, 360, 10, ref topLeftColonIndexes[0], ref topLeftColonIndexes[1]);

            //Колонна правая
            //Нижнее основание
            AddCirclePoints(new Point3D_ok(99, 118, 152), 12, 360, 10, ref bottomRightColonIndexes[0], ref bottomRightColonIndexes[1]);
            //Верхнее основание
            AddCirclePoints(new Point3D_ok(99, 311, 152), 12, 360, 10, ref topRightColonIndexes[0], ref topRightColonIndexes[1]);

            //Дуга
            AddArcPoints(new Point3D_ok(0, 203, 61), 57, 180, 10, ref arcFirstIndex);
        }

        private void InitRotationMatrix(Axis axis, double angle)
        {
            double sin = Math.Sin(angle.ToRadians());
            double cos = Math.Cos(angle.ToRadians());

            switch (axis)
            {
                case Axis.X:
                    rotationXMatrix = new Matrix(4, 4, 1.0f);
                    rotationXMatrix.SetValueOnPosition(2, 2, (float)cos);
                    rotationXMatrix.SetValueOnPosition(2, 3, (float)sin);
                    rotationXMatrix.SetValueOnPosition(3, 2, (float)-sin);
                    rotationXMatrix.SetValueOnPosition(3, 3, (float)cos);
                    break;
                case Axis.Y:
                    rotationYMatrix = new Matrix(4, 4, 1.0f);
                    rotationYMatrix.SetValueOnPosition(1, 1, (float)cos);
                    rotationYMatrix.SetValueOnPosition(1, 3, (float)-sin);
                    rotationYMatrix.SetValueOnPosition(3, 1, (float)sin);
                    rotationYMatrix.SetValueOnPosition(3, 3, (float)cos);
                    break;
                case Axis.Z:
                    break;
            }
        }

        private void CreateISOBtn_Click(object sender, EventArgs e)
        {
            TransformPoints();
            DrawObjectToPicture();
            ClearCanvasBtn.Enabled = true;
        }

        private void TransformPoints()
        {
            Matrix TransformMatrix = rotationYMatrix * rotationXMatrix * projectionZMatrix;

            for(int i = 0; i < modelPoints.Count; i++)
            {
                Matrix resultPointMatrix = modelPoints[i].ToMatrix().Transpond() * TransformMatrix;
                Point3D_ok transformedPoint = resultPointMatrix.ToPoint();
                modelPoints[i] = transformedPoint;
            }
        }

        private void DrawObjectToPicture()
        {
            PointF zeroPoint = new PointF(100f, 100f);
            List<PointF> drawPoints = new List<PointF>(modelPoints.Count);

            float minX = modelPoints[0].x;
            float maxY=modelPoints[0].y;

            foreach (Point3D_ok transformedPoint in modelPoints)
            {
                if(transformedPoint.x < minX)
                {
                    minX = transformedPoint.x;
                }
                if (transformedPoint.y > maxY)
                {
                    maxY = transformedPoint.y;
                }
            }

            foreach (Point3D_ok transformedPoint in modelPoints)
            {
                PointF drawPoint = transformedPoint.ConvertToPoint2D();
                drawPoints.Add(new PointF(zeroPoint.X + (drawPoint.X - minX), zeroPoint.Y - (drawPoint.Y - maxY)));
            }

            for(int i = 0; i < 9; i++)
            {
                if (i != 7)
                {
                    DrawAndFillPolygon(drawPoints, 1 + i * 8, 3 + i * 8, 4 + i * 8, 2 + i * 8);
                    DrawAndFillPolygon(drawPoints, 3 + i * 8, 7 + i * 8, 8 + i * 8, 4 + i * 8);
                    DrawAndFillPolygon(drawPoints, 5 + i * 8, 7 + i * 8, 8 + i * 8, 6 + i * 8);
                    DrawAndFillPolygon(drawPoints, 1 + i * 8, 5 + i * 8, 6 + i * 8, 2 + i * 8);
                    DrawAndFillPolygon(drawPoints, 2 + i * 8, 6 + i * 8, 8 + i * 8, 4 + i * 8);
                }
                else
                {
                    DrawAndFillPolygon(drawPoints, 1 + i * 8, 5 + i * 8, 6 + i * 8, 2 + i * 8);
                    RemoveLine(drawPoints, 2 + i * 8, 6 + i * 8);
                    DrawAndFillPolygon(drawPoints, 1 + i * 8, 3 + i * 8, 4 + i * 8, 2 + i * 8);
                    RemoveLine(drawPoints, 2 + i * 8, 4 + i * 8);
                    DrawAndFillPolygon(drawPoints, 1 + i * 8, 3 + i * 8, 7 + i * 8, 5 + i * 8);
                }
            }

            //Рисование арки
            Pen p = new Pen(Color.Black);
            p.Width = 2;

            List<PointF> arcPoints = drawPoints.GetRange(arcFirstIndex, drawPoints.Count - arcFirstIndex);
            isoImageGraphics.DrawLines(p, arcPoints.ToArray());
            PointF intersection = FindIntersectionPointWithAnyOfTheLines(arcPoints, drawPoints[59]);

            if (intersection.X != -1 && intersection.Y != -1)
            {
                isoImageGraphics.DrawLine(p, new PointF(drawPoints[59].X, drawPoints[59].Y + p.Width), intersection);
            }

            //Рисование колонн
            DrawColumn(drawPoints, "LEFT");
            DrawColumn(drawPoints, "RIGHT");

            IsoImagePicBox.Invalidate();
        }

        private void DrawColumn(List<PointF> points, string column)
        {
            Pen p = new Pen(Color.Black);
            p.Width = 2;

            List<PointF> columnPoints;
            List<PointF> ColumnSurfacePoints = new List<PointF>();
            PointF maxXPoint;
            PointF minXPoint;
            int maxXPointIndex = 0;
            int minXPointIndex = 0;
            int[] bottomIndexesArr = new int[2];
            int[] topIndexesArr = new int[2];

            switch (column.ToLower())
            {
                case "left":
                    bottomIndexesArr[0] = bottomLeftColonIndexes[0];
                    bottomIndexesArr[1] = bottomLeftColonIndexes[1];
                    topIndexesArr[0] = topLeftColonIndexes[0];
                    topIndexesArr[1] = topLeftColonIndexes[1];
                    break;
                case "right":
                    bottomIndexesArr[0] = bottomRightColonIndexes[0];
                    bottomIndexesArr[1] = bottomRightColonIndexes[1];
                    topIndexesArr[0] = topRightColonIndexes[0];
                    topIndexesArr[1] = topRightColonIndexes[1];
                    break;
                default:
                    throw new Exception("Неверно задан параметр column: " + column);
            }

            columnPoints = points.GetRange(bottomIndexesArr[0], (bottomIndexesArr[1] + 1) - bottomIndexesArr[0]);
            isoImageGraphics.DrawLines(p, columnPoints.ToArray());

            maxXPoint = columnPoints[0];
            minXPoint = columnPoints[0];

            foreach (PointF leftColumnPoint in columnPoints)
            {
                if (leftColumnPoint.X < minXPoint.X)
                {
                    minXPoint = leftColumnPoint;
                    minXPointIndex = columnPoints.IndexOf(leftColumnPoint);
                }

                if (leftColumnPoint.X > maxXPoint.X)
                {
                    maxXPoint = leftColumnPoint;
                    maxXPointIndex = columnPoints.IndexOf(leftColumnPoint);
                }
            }

            int index = maxXPointIndex;
            int indexBarrier = minXPointIndex + 1;

            if (indexBarrier >= columnPoints.Count)
            {
                indexBarrier = columnPoints.Count - 1;
            }

            while (index != indexBarrier)
            {
                ColumnSurfacePoints.Add(columnPoints[index]);
                index++;
                if (index == columnPoints.Count)
                {
                    index = 0;
                }
            }

            List<PointF> bottomVisiblePoints = new List<PointF>(ColumnSurfacePoints);

            columnPoints = points.GetRange(topIndexesArr[0], topIndexesArr[1] + 1 - topIndexesArr[0]);

            index = minXPointIndex;
            indexBarrier = maxXPointIndex - 1;

            if (indexBarrier < 0)
            {
                indexBarrier = 0;
            }

            while (index != indexBarrier)
            {
                ColumnSurfacePoints.Add(columnPoints[index]);
                index--;
                if (index < 0)
                {
                    index = columnPoints.Count - 1;
                }
            }

            isoImageGraphics.FillPolygon(Brushes.White, ColumnSurfacePoints.ToArray());
            isoImageGraphics.DrawLines(p, bottomVisiblePoints.ToArray());
            isoImageGraphics.FillPolygon(Brushes.White, columnPoints.ToArray());
            isoImageGraphics.DrawPolygon(p, columnPoints.ToArray());
            isoImageGraphics.DrawLine(p, minXPoint, columnPoints[minXPointIndex]);
            isoImageGraphics.DrawLine(p, maxXPoint, columnPoints[maxXPointIndex]);
        }

        private PointF FindIntersectionPointWithAnyOfTheLines(List<PointF> points, PointF startingPoint)
        {
            float xCoord = startingPoint.X;

            for (int i = 0; i < points.Count - 1; i++)
            {
                PointF first = points[i];
                PointF second = points[i + 1];

                float k = (first.Y - second.Y) / (first.X - second.X);
                float b = second.Y - k * second.X;

                float yCoord = k * xCoord + b;

                if (yCoord >= Math.Min(first.Y, second.Y) && yCoord <= Math.Max(first.Y, second.Y))
                {
                    return new PointF(xCoord, yCoord);
                }
            }

            return new PointF(-1, -1);
        }

        private void RemoveLine(List<PointF> points, int startPointIndex, int endPointIndex)
        {
            Pen p = new Pen(Color.White);
            p.Width = 3;

            isoImageGraphics.DrawLine(p, points[startPointIndex - 1], points[endPointIndex - 1]);
        }

        private void DrawAndFillPolygon(List<PointF> points, int index1, int index2, int index3, int index4)
        {
            Pen p = new Pen(Color.Black);
            p.Width = 2;

            PointF[] Dpoints = new PointF[]
            {
                points[index1 - 1],
                points[index2 - 1],
                points[index3 - 1],
                points[index4 - 1],
            };

            isoImageGraphics.FillPolygon(Brushes.White, Dpoints);
            isoImageGraphics.DrawPolygon(p, Dpoints);
        }

        private void AddCirclePoints(Point3D_ok centerPoint, float radius, int maxAngle, int angleStep, ref int firstIndex, ref int lastIndex)
        {
            int angle = 0;

            firstIndex = modelPoints.Count;

            while (angle <= maxAngle)
            {
                float newPointX = centerPoint.x + (float)(radius * Math.Cos(angle.ToRadians()));
                float newPointZ = centerPoint.z + (float)(radius * Math.Sin(angle.ToRadians()));

                Point3D_ok point = new Point3D_ok(newPointX, centerPoint.y, newPointZ);
                modelPoints.Add(point);

                angle += angleStep;
            }

            lastIndex = modelPoints.Count - 1;
        }

        private void AddArcPoints(Point3D_ok centerPoint, float radius, int maxAngle, int angleStep, ref int firstIndex)
        {
            int angle = 0;

            firstIndex = modelPoints.Count;

            while (angle <= maxAngle)
            {
                float newPointX = centerPoint.x + (float)(radius * Math.Cos(angle.ToRadians()));
                float newPointY = centerPoint.y + (float)(radius * Math.Sin(angle.ToRadians()));

                Point3D_ok point = new Point3D_ok(newPointX, newPointY, centerPoint.z);
                modelPoints.Add(point);

                angle += angleStep;
            }
        }

        private void ClearCanvasBtn_Click(object sender, EventArgs e)
        {
            InitPoints();

            isoImage = new Bitmap(IsoImagePicBox.Width, IsoImagePicBox.Height);
            isoImageGraphics = Graphics.FromImage(isoImage);
            isoImageGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            isoImageGraphics.FillRectangle(Brushes.White, 0, 0, isoImage.Width, isoImage.Height);
            IsoImagePicBox.Image = isoImage;

            IsoImagePicBox.Invalidate();

            ClearCanvasBtn.Enabled = false;
        }
    }
}
