using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ClockApp
{
    public partial class Form1 : Form
    {
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate(); // Оновлення годинника

            // Оновлення часу та дати
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("d MMMM yyyy г.");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            int clockRadius = Math.Min(w - calendar.Width - 40, h) / 2 - 20;

            Point center = new Point(w / 2 + 100, h / 2);
            DateTime now = DateTime.Now;

            DrawClockFace(g, center, clockRadius);

            float secondAngle = now.Second * 6;
            float minuteAngle = now.Minute * 6 + now.Second * 0.1f;
            float hourAngle = (now.Hour % 12) * 30 + now.Minute * 0.5f;

            using (Pen secondPen = new Pen(Color.Red, 1))
            using (Pen minutePen = new Pen(Color.Black, 3))
            using (Pen hourPen = new Pen(Color.Black, 5))
            {
                DrawHand(g, center, clockRadius * 0.9f, secondAngle, secondPen);
                DrawHand(g, center, clockRadius * 0.7f, minuteAngle, minutePen);
                DrawHand(g, center, clockRadius * 0.5f, hourAngle, hourPen);
            }

            g.FillEllipse(Brushes.Black, center.X - 4, center.Y - 4, 8, 8);
        }

        private void DrawHand(Graphics g, Point center, double length, float angle, Pen pen)
        {
            double rad = Math.PI * angle / 180.0;
            Point end = new Point(
                center.X + (int)(length * Math.Sin(rad)),
                center.Y - (int)(length * Math.Cos(rad))
            );
            g.DrawLine(pen, center, end);
        }

        private void DrawClockFace(Graphics g, Point center, int radius)
        {
            // Коло циферблату
            g.DrawEllipse(Pens.Black, center.X - radius, center.Y - radius, radius * 2, radius * 2);

            // ділення та цифри
            for (int i = 1; i <= 60; i++)
            {
                double angle = i * 6 * Math.PI / 180;
                int len = (i % 5 == 0) ? 10 : 5;

                Point p1 = new Point(
                    center.X + (int)((radius - len) * Math.Sin(angle)),
                    center.Y - (int)((radius - len) * Math.Cos(angle))
                );

                Point p2 = new Point(
                    center.X + (int)(radius * Math.Sin(angle)),
                    center.Y - (int)(radius * Math.Cos(angle))
                );

                g.DrawLine(Pens.Black, p1, p2);

                // додання цифр 1–12
                if (i % 5 == 0)
                {
                    int hour = i / 5;
                    string text = hour.ToString();
                    Font font = new Font("Segoe UI", 12, FontStyle.Bold);
                    SizeF textSize = g.MeasureString(text, font);

                    double textAngle = (hour * 30 - 90) * Math.PI / 180;

                    int textRadius = radius - 25;
                    PointF textPos = new PointF(
                        center.X + (float)(textRadius * Math.Cos(textAngle)) - textSize.Width / 2,
                        center.Y + (float)(textRadius * Math.Sin(textAngle)) - textSize.Height / 2
                    );

                    g.DrawString(text, font, Brushes.Black, textPos);
                }
            }
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}
