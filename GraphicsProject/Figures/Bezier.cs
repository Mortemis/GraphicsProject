using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public class Bezier : Figure
    {
        const int Np = 20; // Максимальное количество точек для кривой Безье.
        //Point[] Lp = new Point[np]; // TODO Remove
        public List<Point> Lp = new List<Point>();
        public bool Finished = false; // Кривая дорисована.

        public Bezier()
        {
            Lp = new List<Point>();
            Finished = false;
        }



        public void Finish()
        {
            Finished = true;
        }

        public void AddPoint(Point point)
        {
            Lp.Add(point);
        }

        public override void Draw()
        {
            if (Finished)
            {
                int n = Lp.Count - 1;
                double nFact = FactorialUtils.Factorials[n];

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
                        double j = Math.Pow(t, i) * Math.Pow(1 - t, n - i) * nFact / (FactorialUtils.Factorials[i] * FactorialUtils.Factorials[n - i]);
                        xt = xt + Lp[i].X * j;
                        yt = yt + Lp[i].Y * j;
                        i++;
                    }

                    Point begin = new Point((int)xPred, (int)yPred);
                    Point end = new Point((int)xt, (int)yt);
                    Line.Draw(begin, end);
                    t += dt;
                    xPred = xt; yPred = yt;
                }
            }
        }
    }
}
