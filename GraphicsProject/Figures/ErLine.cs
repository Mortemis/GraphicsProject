using System.Collections.Generic;
using System.Drawing;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public class ErLine : Figure
    {
        public ErLine(IList<PointF> points) : base(points)
        {
            var ermitPoints = new List<PointF>();

            //Эрмитовая матрицa
            double[,] mh =
            {
                {2, -2, 1, 1}, 
                {-3, 3, -2, -1},
                {0, 0, 1, 0},
                {1, 0, 0, 0}
            }; 
            var l = new double[4, 2]; // матрица неизвестных коэффициентов
            const double dt = 0.001; //шаг табуляции
            double t = 0;
            double xT1 = Points[0].X; // координата х начала первого вектора
            double yT1 = Points[0].Y; // координата у начала первого вектора
            double xT2 = Points[2].X; // координата x начала второго вектора
            double yT2 = Points[2].Y; // координата у начала второго вектора

            double x1 = Points[1].X - Points[0].X; //проекция первого вектора на ось ох
            double y1 = Points[1].Y - Points[0].Y; //проекция первого вектора на ось оу
            double x2 = Points[3].X - Points[2].X; //проекция второго вектора на ось ох
            double y2 = Points[3].Y - Points[2].Y; //проекция второго вектора на ось оу

            //матрица начальных условий
            double[,] gh =
            {
                {xT1, yT1},
                {xT2, yT2},
                {x1, y1},
                {x2, y2}
            }; 

            l = MatrixUtils.MatrixMult(mh, gh);

            double xPred = Points[0].X;
            double yPred = Points[0].Y;

            while (t < 1 + dt / 2)
            {
                var ptx = l[0, 0] * t * t * t + l[1, 0] * t * t + l[2, 0] * t + l[3, 0];
                var pty = l[0, 1] * t * t * t + l[1, 1] * t * t + l[2, 1] * t + l[3, 1];

                ermitPoints.Add(new PointF((float) ptx, (float) pty));
                G.DrawLine(DrawPen, (int) xPred, (int) yPred, (int) ptx, (int) pty);
                t = t + dt;
                xPred = ptx;
                yPred = pty;
                ermitPoints.Add(new PointF((float) xPred, (float) yPred));
            }

            Points = ermitPoints;
        }

        public override void Draw()
        {
            var newPoints = GetNewPoints();
            for (var i = 0; i < newPoints.Count - 1; i++)
                G.DrawLine(DrawPen, newPoints[i], newPoints[i + 1]);
        }
    }
}