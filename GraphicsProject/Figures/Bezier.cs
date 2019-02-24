using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public class Bezier : Figure
    {
        const int np = 20; // Максимальное количество точек для кривой Безье.
        //Point[] Lp = new Point[np]; // TODO Remove
        public List<Point> Lp = new List<Point>();
        public bool finished = false; // Кривая дорисована.

        public Bezier()
        {
            Lp = new List<Point>();
            finished = false;
        }



        public void Finish()
        {
            finished = true;
        }

        public void AddPoint(Point point)
        {
            Lp.Add(point);
        }

        public override void Draw()
        {
            if (finished)
            {
                int n = Lp.Count - 1;
                double nFact = Utils.MathUtils.Factorials[n];

                //Шаг
                double dt = 0.001;
                double t = dt;

                double xPred = Lp[0].X;
                double yPred = Lp[0].Y;


                while (t < 1 + dt / 2)
                {
                    int i = 0;
                    double xt = 0, yt = 0;
                    while (i <= n) // Было <=
                    {
                        //Интерполяционный полином Бернштейна
                        double J = Math.Pow(t, i) * Math.Pow(1 - t, n - i) * nFact / (Utils.MathUtils.Factorials[i] * Utils.MathUtils.Factorials[n - i]);
                        xt = xt + Lp[i].X * J;
                        yt = yt + Lp[i].Y * J;
                        i++;
                    }

                    Point Begin = new Point((int)xPred, (int)yPred);
                    Point End = new Point((int)xt, (int)yt);
                    Line.Draw(Begin, End);
                    t += dt;
                    xPred = xt; yPred = yt;
                }
            }

            if (Rotation != 0)
            {
                Rotate(RotationCenter, Rotation);
            }
        }

        public override string ToString()
        {
            return "Bezier";
        }

    }
}
