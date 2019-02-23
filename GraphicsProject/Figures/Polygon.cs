using System;
using System.Collections.Generic;
using System.Drawing;

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
            var Points = GetNewPoints();
            int n = Points.Count - 1;
            //ищем максимальные и минимальные значения по У
            int Ymin = (int) Math.Round(Points[0].Y);
            int Ymax = Ymin, Y = 0;
            for (int i = 0; i < n; i++)
            {
                var y = (int) Math.Round(Points[i].Y);
                if (y < Ymin) Ymin = y;
                if (y > Ymax) Ymax = y;
            }

            if (Ymin < 0)
                Ymin = 0;
            if (Ymax > MainForm.CanvasHeight)
                Ymax = MainForm.CanvasHeight;
            List<double> Xb = new List<double>();
            double x;

            for (Y = Ymin; Y <= Ymax; Y++)
            {
                Xb.Clear();
                for (int i = 0; i < n; i++)
                {
                    if ((Points[i].Y < Y) & (Points[i + 1].Y >= Y) | (Points[i].Y >= Y) & (Points[i + 1].Y < Y))
                    {
                        x = (Y - Points[i].Y) * (Points[i + 1].X - Points[i].X) / (Points[i + 1].Y - Points[i].Y) +
                            Points[i].X;
                        Xb.Add(x);
                    }
                }

                Xb.Sort();
                for (int i = 0; i < Xb.Count; i = i + 2)
                {
                    G.DrawLine(DrawPen, (int) (Xb[i] + 1), Y, (int) (Xb[i + 1]), Y);
                }
            }
            
        }
    }
}