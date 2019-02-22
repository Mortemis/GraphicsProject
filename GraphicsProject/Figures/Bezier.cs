using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public class Bezier : Figure
    {
        // Максимальное количество точек для кривой Безье.
        private const int Np = 20; 

        private readonly List<Point> _lp;

        // Кривая дорисована.
        private bool _isFinished;

        public Bezier()
        {
            _lp = new List<Point>();
            _isFinished = false;
        }      

        public void Finish()
        {
            _isFinished = true;
        }

        public void AddPoint(Point point)
        {
            _lp.Add(point);
        }

        public override void Draw()
        {
            if (_isFinished)
            {
                int n = _lp.Count - 1;
                double nFact = FactorialUtils.Factorials[n];

                //Шаг
                double dt = 0.001;
                double t = dt;

                double xPred = _lp[0].X;
                double yPred = _lp[0].Y;


                while (t < 1 + dt / 2)
                {
                    int i = 0;
                    double xt = 0, yt = 0;
                    while (i <= n) // Было <=
                    {
                        //Интерполяционный полином Бернштейна
                        double j = Math.Pow(t, i) * Math.Pow(1 - t, n - i) * nFact / (FactorialUtils.Factorials[i] * FactorialUtils.Factorials[n - i]);
                        xt = xt + _lp[i].X * j;
                        yt = yt + _lp[i].Y * j;
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
