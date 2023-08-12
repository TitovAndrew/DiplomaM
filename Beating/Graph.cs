using System;
using System.Drawing;

namespace Beating
{
    public abstract class Graph
    {
        public bool DrawLine { set; get; }  // Рисовать ли линию
        public bool Resizing { set; get; }  // Для быстрой отрисовки при изменении размера

        public Graph()
        {
            DrawLine = false;
            Resizing = false;
        }

        protected abstract float F(float t);

        protected void DrawGrid(Graphics graphics, RectangleF drawRectangle, PointF zero, float minT, float minFt, float maxT, float maxFt)
        {
            if (!DrawLine)
            {
                maxT = 100;
                minFt = -2;
                maxFt = 2;
                minT = 0;
            }

            var chartX = drawRectangle.X;
            var chartY = drawRectangle.Y;
            var width = drawRectangle.Width;
            var height = drawRectangle.Height;

            var boldPen = new Pen(Color.Black, 2.0f);
            var pen = new Pen(Color.Gray, 1.0f);

            var unitT = width / (maxT - minT);
            var unitFt = height / (maxFt - minFt);

            var font = new Font("SegoeUI", 12.0f);
         
            var numberWidth = graphics.MeasureString("0.00", font).Width;
            var numberHeight = graphics.MeasureString("0.00", font).Height;

            var ftPartNumber = (int)(drawRectangle.Height / numberHeight / 1.5f);
            var tPartNumber = (int)(drawRectangle.Width / numberWidth / 1.5f);

            if (ftPartNumber % 2 != 0)
                ftPartNumber--;

            var valuePerNumberT = (maxT - minT) / tPartNumber;
            var valuePerNumberFt = (maxFt - minFt) / ftPartNumber;

            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };

            for (float tPart = 0; tPart <= tPartNumber; tPart++)
            {
                var coordinate = tPart * valuePerNumberT;
                var x = chartX + zero.X + coordinate * unitT;

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                graphics.DrawLine(coordinate == 0 || tPart == 0 || tPart == tPartNumber ? boldPen : pen, x, chartY, x, chartY + height);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawString(coordinate.ToString(coordinate / 1000 > 0 ? "0" : "0.##").Replace(",", "."), font, Brushes.Black, 
                    new RectangleF(x - numberWidth / 2.0f, chartY + height + 5, 
                    numberWidth, numberHeight), stringFormat);
            }

            for (float ftPart = -ftPartNumber / 2.0f; ftPart <= ftPartNumber / 2.0f; ftPart++)
            {
                var coordinate = ftPart * valuePerNumberFt;
                var coordinateString = (-coordinate).ToString(coordinate / 1000 > 0 ? "0" : "0.##").Replace(",", ".");
                var coordinateBounds = graphics.MeasureString(coordinateString, font);
                var y = chartY + zero.Y + coordinate * unitFt;

                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                graphics.DrawLine(coordinate == 0 || ftPart == -ftPartNumber / 2.0f 
                    || ftPart == ftPartNumber / 2.0f ? boldPen : pen, chartX, y, chartX + width, y);
               
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawString(coordinateString, font, Brushes.Black,
                   new RectangleF(chartX - coordinateBounds.Width - 5, y - coordinateBounds.Height / 2.0f,
                   coordinateBounds.Width, coordinateBounds.Height), stringFormat);
            }
        }

        public void Draw(Graphics graphics, RectangleF drawRectangle, PointF zero, float minT, float minFt, float maxT, float maxFt, Color lineColor)
        {
            var chartX = drawRectangle.X;
            var chartY = drawRectangle.Y;
            var width = drawRectangle.Width;
            var height = drawRectangle.Height;
            var lineTickness = (float)Math.Min(width / (maxT - minT), 3.0);
            var linePen = new Pen(lineColor, lineTickness * 0.75f);
           
            if (maxT - minT != 0 && maxFt - minFt != 0)
            {
                var unitT = width / (maxT - minT);
                var unitFt = height / (maxFt - minFt);
                var tStep = (Resizing ? 5.0f : 1.0f) / unitT;

                DrawGrid(graphics, drawRectangle, zero, minT, minFt, maxT, maxFt);

                if (DrawLine)
                {
                    var previousPoint = new PointF(chartX + zero.X + minT * unitT, chartY + zero.Y - F(minT) * unitFt);
                    for (float t = minT + tStep; t <= maxT; t += tStep)
                    {
                        var ft = F(t);
                        var point = new PointF(chartX + zero.X + t * unitT, chartY + zero.Y - ft * unitFt);
                        if (Math.Sqrt(Math.Pow(point.X - previousPoint.X, 2.0f) + Math.Pow(point.Y - previousPoint.Y, 2.0f))
                            >= 0.5f)
                        {
                            graphics.DrawLine(linePen, previousPoint, point);
                            previousPoint = point;
                        }
                    }
                }
            }
        }
    }
}
