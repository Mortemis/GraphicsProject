using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        protected static Pen DrawPen = MainForm.DrawPen;
        protected static Graphics G = MainForm.G;

        protected IList<PointF> Points;

        protected double[,] C =
        {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        };

        protected Figure()
        {
        }

        protected Figure(IList<PointF> points)
        {
            Points = points;
            Draw();
        }

        public virtual void Rotate(PointF p, double angle)
        {
            var angleRad = angle * Math.PI / 180D;
            double cosf = Math.Cos(angleRad);
            double sinf = Math.Sin(angleRad);

            double[,] M = {{1, 0, 0}, {0, 1, 0}, {-p.X, -p.Y, 1}};
            double[,] MObr = {{1, 0, 0}, {0, 1, 0}, {p.X, p.Y, 1}};
            double[,] R = {{cosf, -sinf, 0}, {sinf, cosf, 0}, {0, 0, 1}};

            C = MatrixUtils.MatrixMult(C, MatrixUtils.MatrixMult(M, MatrixUtils.MatrixMult(R, MObr)));
        }

        public virtual void Mirror(PointF a, PointF b)
        {
            PointF o = new PointF(b.X, a.Y);
            double ax = b.X - a.X;
            double ay = b.Y - a.Y;
            double bx = o.X - a.X;
            //(ax * bx + ay * by) / (Math.Sqrt(ax * ax + ay * ay) * Math.Sqrt(bx * bx + by * by)) но by=0, так что упрощаем
            double cosf = (ax * bx) / (Math.Sqrt(ax * ax + ay * ay) * Math.Sqrt(bx * bx));
            double sinf = Math.Sqrt(1 - cosf * cosf);

            if ((ax * ay) > 0) sinf = -sinf;
            PointF c = new PointF((b.X - a.X) / 2 + a.X, (b.Y - a.Y) / 2 + a.Y);

            double[,] M = {{1, 0, 0}, {0, 1, 0}, {-c.X, -c.Y, 1}};
            double[,] MObr = {{1, 0, 0}, {0, 1, 0}, {c.X, c.Y, 1}};
            double[,] S = {{1, 0, 0}, {0, -1, 0}, {0, 0, 1}};
            double[,] R = {{cosf, sinf, 0}, {-sinf, cosf, 0}, {0, 0, 1}};
            double[,] RObr = {{cosf, -sinf, 0}, {sinf, cosf, 0}, {0, 0, 1}};

            C = MatrixUtils.MatrixMult(C,
                MatrixUtils.MatrixMult(M,
                    MatrixUtils.MatrixMult(R, 
                        MatrixUtils.MatrixMult(S, 
                            MatrixUtils.MatrixMult(RObr, MObr)))));
        }

        // выделение многоугольника
        public virtual bool IsSelected(int mX, int mY)
        {
            var Points = GetNewPoints();
            int n = Points.Count() - 1, k = 0;
            PointF Pi, Pk; //принимает дискретные пиксели и рисует в режиме сглаживания
            double x;
            List<int> Xb = new List<int>(); //буфер сегментов
            bool check = false;

            Xb.Clear();
            for (int i = 0; i <= n; i++)
            {
                if (i < n) k = i + 1;
                else k = 0;
                Pi = Points[i];
                Pk = Points[k];
                if ((Pi.Y < mY) & (Pk.Y >= mY) | (Pi.Y >= mY) & (Pk.Y < mY))
                {
                    x = (mY - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y) + Pi.X;
                    Xb.Add((int) Math.Round(x));
                }
            }

            if (Xb.Any())
            {
                Xb.Sort();
                for (int i = 0; i < Xb.Count; i = i + 2)
                {
                    if (mX >= Xb[i] & mX <= Xb[i + 1])
                    {
                        check = true;
                        break;
                    }
                }
            }

            return check;
        }

        public void Move(int dx, int dy)
        {
            //матрица движения
            double[,] M =
            {
                {1, 0, 0},
                {0, 1, 0},
                {dx, dy, 1}
            };

            C = MatrixUtils.MatrixMult(C, M);
        }

        protected List<PointF> GetNewPoints()
        {
            var newPoints = new List<PointF>();
            int n = Points.Count - 1;
            for (int i = 0; i <= n; i++)
            {
                double[,] C0 = {{Points[i].X, Points[i].Y, 1}};
                var temp = MatrixUtils.MatrixMult(C0, C);
                newPoints.Add(new PointF((float) temp[0, 0], (float) temp[0, 1]));
            }

            return newPoints;
        }

        public abstract void Draw();

        public static void PutPoint(PointF position)
        {
            MainForm.G.DrawRectangle(DrawPen, position.X, position.Y, 1, 1);
        }
    }
}