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
        public bool finished = false; // Кривая дорисована.

        public Bezier()
        {
        }


        // TODO remove
        public void Finish()
        {
            finished = true;
        }


        public void AddPoint(Point Point)
        {
            Points.Add(Point);
        }

        private void FindSelection(Point Point)
        {
            if (SelectBegin.X > Point.X) SelectBegin.X = Point.X;
            if (SelectBegin.Y > Point.Y) SelectBegin.Y = Point.Y;
            if (SelectEnd.X < Point.X) SelectEnd.X = Point.X;
            if (SelectEnd.Y < Point.Y) SelectEnd.Y = Point.Y;
        }

        public override void Draw()
        {
            if (finished)
            {
                var Points = ApplyTransformations();
                int n = Points.Count - 1;
                double nFact = Utils.MathUtils.Factorials[n];

                //Шаг
                double dt = 0.001;
                double t = dt;

                double xPred = Points[0].X;
                double yPred = Points[0].Y;

                SelectBegin.X = (int)xPred;
                SelectBegin.Y = (int)yPred;
                SelectEnd.X = (int)xPred;
                SelectEnd.Y = (int)yPred;

                while (t < 1 + dt / 2)
                {
                    int i = 0;
                    double xt = 0, yt = 0;
                    while (i <= n) // Было <=
                    {
                        //Интерполяционный полином Бернштейна
                        double J = Math.Pow(t, i) * Math.Pow(1 - t, n - i) * nFact / (Utils.MathUtils.Factorials[i] * Utils.MathUtils.Factorials[n - i]);
                        xt = xt + Points[i].X * J;
                        yt = yt + Points[i].Y * J;
                        i++;
                    }

                    Point Begin = new Point((int)xPred, (int)yPred);
                    Point End = new Point((int)xt, (int)yt);
                    
                    Line.Draw(Begin, End);
                    t += dt;
                    xPred = xt; yPred = yt;

                    FindSelection(new Point((int)xPred,(int)yPred)); //Finds max&min points and sets selection accordingly to it.
                }
            }

            if (IsSelected) DrawSelect();

        }

        public override string ToString()
        {
            return "Bezier";
        }

    }
}
