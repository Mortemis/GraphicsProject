using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public abstract class Polygon : Figure
    {
        protected Polygon(Point centerPoint)
        {
        }

        protected Polygon(IList<PointF> points) : base(points)
        {
        }

        protected Polygon()
        {
        }

        public override void Draw()
        {
            var newPoints = GetNewPoints();
            int n = newPoints.Count - 1;

            var upperAndLowerBorder = BordersUtils.GetUpperAndLowerBorderTuple(newPoints);

            //ищем максимальные и минимальные значения по У
            int ymin = upperAndLowerBorder.Item1;
            int ymax = upperAndLowerBorder.Item2;

            var xb = new List<double>();

            for (var y = ymin; y <= ymax; y++)
            {
                xb.Clear();
                for (int i = 0; i < n; i++)
                {
                    if ((newPoints[i].Y < y) & (newPoints[i + 1].Y >= y) ||
                        (newPoints[i].Y >= y) & (newPoints[i + 1].Y < y))
                    {
                        double x = (y - newPoints[i].Y) * (newPoints[i + 1].X - newPoints[i].X) /
                                   (newPoints[i + 1].Y - newPoints[i].Y) +
                                   newPoints[i].X;
                        xb.Add(x);
                    }
                }

                xb.Sort();
                for (int i = 0; i < xb.Count; i = i + 2)
                {
                    G.DrawLine(DrawPen, (int) (xb[i] + 1), y, (int) (xb[i + 1]), y);
                }
            }
        }
    }
}