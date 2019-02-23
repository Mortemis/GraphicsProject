using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProject.Figures
{
    public class CubicSpline : Figure
    {
        public CubicSpline(IList<PointF> points) : base(points)
        {
        }

        public override void Draw()
        {
            double[,] Mh = {{2, -2, 1, 1}, {-3, 3, -2, -1}, {0, 0, 1, 0}, {1, 0, 0, 0}}; //Эрмитовая матрицa
            var L = new double[4, 2]; // матрица неизвестных коэффициентов
            var dt = 0.001; //шаг табуляции
            double t = 0;
            double xT1 = Points[0].X; // координата х начала первого вектора
            double yT1 = Points[0].Y; // координата у начала первого вектора
            double xT2 = Points[2].X; // координата x начала второго вектора
            double yT2 = Points[2].Y; // координата у начала второго вектора

            double x1 = Points[1].X - Points[0].X; //проекция первого вектора на ось ох
            double y1 = Points[1].Y - Points[0].Y; //проекция первого вектора на ось оу
            double x2 = Points[3].X - Points[2].X; //проекция второго вектора на ось ох
            double y2 = Points[3].Y - Points[2].Y; //проекция второго вектора на ось оу

            double[,] Gh = {{xT1, yT1}, {xT2, yT2}, {x1, y1}, {x2, y2}}; //матрица начальных условий


            var row = Mh.GetLength(0);
            var col = Gh.GetLength(1);
            var inner = Gh.GetLength(0);

            for (var i = 0; i < row; i++)
            for (var j = 0; j < col; j++)
            for (var k = 0; k < inner; k++)
                L[i, j] += Mh[i, k] * Gh[k, j];

            double Ptx = 0;
            double Pty = 0;
            double xPred = Points[0].X;
            double yPred = Points[0].Y;

            while (t < 1 + dt / 2)
            {
                Ptx = L[0, 0] * t * t * t + L[1, 0] * t * t + L[2, 0] * t + L[3, 0];
                Pty = L[0, 1] * t * t * t + L[1, 1] * t * t + L[2, 1] * t + L[3, 1];

                G.DrawLine(DrawPen, (int) xPred, (int) yPred, (int) Ptx, (int) Pty);
                t = t + dt;
                xPred = Ptx;
                yPred = Pty;
            }
        }
    }
}