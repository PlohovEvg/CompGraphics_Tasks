using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraphics_Task1
{
    public partial class Form1 : Form
    {
        private Bitmap myImage;
        private Bitmap blank;
        private Graphics g;
        private PointF center, x0, x1;
        private Spiral spiral;
        private int alpha, two_PI_N_degrees;
        private bool LastPoint;

        public Form1()
        {
            InitializeComponent();

            spiral = new Spiral();
            ChangeImageAndUpateBlank();

        }

        private void ChangeImageAndUpateBlank()
        {
            InitBlankImage();
            myImage = new Bitmap(blank);
            PointF oldC = new PointF(center.X, center.Y);
            center = new PointF(myImage.Width / 2, myImage.Height / 2);
            g = Graphics.FromImage(myImage);

            if (spiral.GetPoints().Count != 0)
            {
                RedrawSpiral(oldC);
            }

            pictureBox1.Image = myImage;
        }

        private void RedrawSpiral(PointF oldCenter)
        {
            List<PointF> newPointList = new List<PointF>();
            List<PointF> spiralPoints = spiral.GetPoints();

            float maxX, minX, maxY, minY;

            maxX = minX = spiralPoints[0].X - oldCenter.X;
            maxY = minY = oldCenter.Y - spiralPoints[0].Y;

            float coefX, coefY;

            foreach(PointF p in spiralPoints)
            {
                float xRel = p.X - oldCenter.X;
                float yRel = oldCenter.Y - p.Y;

                if (xRel > maxX)
                    maxX = xRel;
                if (xRel < minX)
                    minX = xRel;
                if (yRel > maxY)
                    maxY = yRel;
                if (yRel < minY)
                    minY = yRel;
            }

            if(Math.Max(Math.Abs(maxX), Math.Abs(minX)) == Math.Abs(maxX))
            {
                coefX = (0.5f * myImage.Width - 5) / Math.Abs(maxX);
            }
            else
            {
                coefX = (0.5f * myImage.Width - 5) / Math.Abs(minX);
            }

            if (Math.Max(Math.Abs(maxY), Math.Abs(minY)) == Math.Abs(maxY))
            {
                coefY = (0.5f * myImage.Height - 5) / Math.Abs(maxY);
            }
            else
            {
                coefY = (0.5f * myImage.Height - 5) / Math.Abs(minY);
            }

            if (coefX < coefY)
                coefY = coefX;
            else
                coefX = coefY;

            foreach (PointF p in spiralPoints)
            {
                PointF newP = new PointF();
                newP.X = (p.X - oldCenter.X) * coefX + center.X;
                newP.Y = -(oldCenter.Y - p.Y) * coefY + center.Y;

                newPointList.Add(newP);
            }

            spiral.SetPointList(newPointList);
            g.DrawCurve(Pens.Red, newPointList.ToArray());
        }

        private void ClearCanvas()
        {
            myImage = new Bitmap(blank);
            g = Graphics.FromImage(myImage);
            pictureBox1.Image = myImage;
        }

        private void InitBlankImage()
        {
            blank = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(blank);            

            gr.FillRectangle(Brushes.White, 0, 0, blank.Width, blank.Height);

            // int lineC = 10;
            // Color penColor = Color.FromArgb(120, Color.Gray);
            // Pen linePen = new Pen(penColor);
            // linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            // 
            // while (lineC < blank.Width)
            // {
            //     gr.DrawLine(linePen, new Point(lineC, 0), new Point(lineC, blank.Height));
            //     lineC += 10;
            // }
            // 
            // lineC = 10;
            // 
            // while (lineC < blank.Height)
            // {
            //     gr.DrawLine(linePen, 0, lineC, blank.Width, lineC);
            //     lineC += 10;
            // }

            //Рисуем оси
            gr.DrawLine(Pens.Black, 0, blank.Height / 2, blank.Width, blank.Height / 2);
            gr.DrawLine(Pens.Black, blank.Width / 2, 0, blank.Width / 2, blank.Height);
            //**
            int Angle = 30;
            int Height = 20;
            DrawAxisArrows(Angle, Height, gr);

            Font axisLabelsFont = new Font("Arial", 14, FontStyle.Regular);
            RectangleF axisLabelRect = new RectangleF();
            StringFormat Format = new StringFormat();
            Format.Alignment = StringAlignment.Near;
            Format.LineAlignment = StringAlignment.Near;

            SizeF s = gr.MeasureString("x", axisLabelsFont);
            axisLabelRect.Size = s;
            axisLabelRect.X = blank.Width - Height;
            axisLabelRect.Y = (float)(blank.Height / 2 - Height * Math.Tan((Angle * 0.5).ToRadians()) - 20);
            gr.DrawString("x", axisLabelsFont, Brushes.Black, axisLabelRect, Format);

            s = gr.MeasureString("y", axisLabelsFont);
            axisLabelRect.Size = s;
            axisLabelRect.X = (float)(blank.Width / 2 + Height * Math.Tan((Angle * 0.5).ToRadians()));
            axisLabelRect.Y = -5;
            gr.DrawString("y", axisLabelsFont, Brushes.Black, axisLabelRect, Format);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;
            ChangeImageAndUpateBlank();                                      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                return;

            ClearCanvas();
            spiral.ClearPointsList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button3.Enabled = false;
            ChangeResizing(false);
        }

        private void DrawAxisArrows(int angle,int height, Graphics Gr)
        {
            if (angle <= 0 || angle >= 180 || height <= 0 || height >= blank.Height)
                return;

            Point p1 = new Point(blank.Width / 2, 0);

            Point p2 = new Point();
            p2.X = (int)(p1.X - height * Math.Tan((angle * 0.5).ToRadians()));
            p2.Y = height;

            Point p3 = new Point();
            p3.X = (int)(p1.X + height * Math.Tan((angle * 0.5).ToRadians()));
            p3.Y = height;
            Gr.FillPolygon(Brushes.Black, new Point[] { p1, p2, p3 });

            p1 = new Point(blank.Width, blank.Height / 2);

            p2 = new Point();
            p2.X = p1.X - height;
            p2.Y = (int)(p1.Y - height * Math.Tan((angle * 0.5).ToRadians()));

            p3 = new Point();
            p3.X = p1.X - height;
            p3.Y = (int)(p1.Y + height * Math.Tan((angle * 0.5).ToRadians()));
            Gr.FillPolygon(Brushes.Black, new Point[] { p1, p2, p3 });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double r = alpha * 0.5;
            x1 = new PointF((float)(r * Math.Cos(alpha.ToRadians())) + center.X, (float)(-r * Math.Sin(alpha.ToRadians())) + center.Y);

            spiral.AddPoint(x1);
            g.DrawLine(Pens.Red, x0, x1);

            x0 = x1;
            alpha += 3;

            label4.Text = alpha.ToString();
            label5.Text = r.ToString();

            if (alpha >= two_PI_N_degrees && !LastPoint)
            {
                alpha = two_PI_N_degrees;
                LastPoint = true;
            }
            else
            {
                if (LastPoint)
                {
                    ClearCanvas();
                    RedrawSpiral(center);
                    button3.Enabled = false;
                    ChangeResizing(false);
                    timer1.Stop();
                }
            }

            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                return;

            if (!int.TryParse(textBox2.Text, out alpha))
            {
                MessageBox.Show("Введите число в поле угла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!alpha.IsInRange(0, 360))
            {
                MessageBox.Show("Неверно задан угол", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClearCanvas();
            spiral.ClearPointsList();
            x0 = center;
            two_PI_N_degrees = 360 * (int)numericUpDown1.Value;
            LastPoint = false;

            spiral.AddPoint(x0);

            button3.Enabled = true;
            ChangeResizing(true);

            timer1.Start();
        }

        private void ChangeResizing(bool disable)
        {
            if (disable)
            {
                MaximizeBox = false;
                MinimizeBox = false;
                FormBorderStyle = FormBorderStyle.FixedDialog;
            }
            else
            {
                MaximizeBox = true;
                MinimizeBox = true;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
    }
}
