using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphicsProject.Figures
{
    public class Pgn : Polygon
    {
        public Pgn(IList<PointF> points,int n)
        {
            Points = CalculVertecies(points[1], points[0], n);
            Points.Add(Points.First());
            Draw();
        }


        private IList<PointF> CalculVertecies(PointF firstVertex, PointF center, int n)
        {
            var pts = new PointF[0];
            double R = (int) Math.Sqrt(Math.Pow(firstVertex.X - center.X, 2) + Math.Pow(firstVertex.Y - center.Y, 2));
            var phi = Math.Acos(Math.Abs(firstVertex.X - center.X) / R);
            var PI2 = Math.PI * 2;
            for (var i = 0; i < n; i++)
            {
                Array.Resize(ref pts, pts.Length + 1);
                var x = (int) (center.X + R * Math.Cos(phi + PI2 * i / n));
                var y = (int) (center.Y + R * Math.Sin(phi + PI2 * i / n));
                pts[pts.Length - 1] = new Point(x, y);
            }

            return pts.ToList();
        }
    }
}