using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public static Pen DrawPenStatic = MainForm.DrawPen;
        protected static Graphics G = MainForm.G;

        protected Pen DrawPen;
        protected IList<PointF> Points;

        protected double[,] C =
        {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        };

        protected Figure()
        {
            DrawPen = DrawPenStatic;
        }

        protected Figure(IList<PointF> points)
        {
            DrawPen = DrawPenStatic;
            Points = points;
            Draw();
        }

        public abstract void Draw();

        public virtual IList<PointF> GetBorderPoints()
        {
            var points = GetNewPoints();

            var leftX = points.Min(point => point.X) - 2;
            var rightX = points.Max(point => point.X) + 2;
            var upY = points.Min(point => point.Y) - 2;
            var downY = points.Max(point => point.Y) + 2;

            G.DrawLine(DrawPenUtils.DrawPenGreen, leftX, upY, rightX, upY);
            G.DrawLine(DrawPenUtils.DrawPenGreen, leftX, downY, rightX, downY);

            G.DrawLine(DrawPenUtils.DrawPenGreen, rightX, downY, rightX, upY);
            G.DrawLine(DrawPenUtils.DrawPenGreen, leftX, downY, leftX, upY);

            return new List<PointF>
            {
                new PointF(leftX,upY),
                new PointF(rightX,upY),
                new PointF(rightX,downY),
                new PointF(leftX,downY),
            };
        }

        public virtual bool IsSelected(int mX, int mY)
        {
            var newPoints = GetNewPoints();
            int n = newPoints.Count() - 1;
            double x;
            var xb = new List<int>(); //буфер сегментов
            bool isSelected = false;

            xb.Clear();
            for (int i = 0; i <= n; i++)
            {
                int k;
                if (i < n) k = i + 1;
                else k = 0;
                var pi = newPoints[i];
                var pk = newPoints[k];
                if ((pi.Y < mY) & (pk.Y >= mY) | (pi.Y >= mY) & (pk.Y < mY))
                {
                    x = (mY - pi.Y) * (pk.X - pi.X) / (pk.Y - pi.Y) + pi.X;
                    xb.Add((int) Math.Round(x));
                }
            }

            if (xb.Any())
            {
                xb.Sort();
                for (int i = 0; i < xb.Count; i = i + 2)
                {
                    if (mX >= xb[i] & mX <= xb[i + 1])
                    {
                        isSelected = true;
                        break;
                    }
                }
            }

            return isSelected;
        }

        public virtual List<PointF> GetNewPoints()
        {
            var newPoints = new List<PointF>();
            if (Points == null) return newPoints;
            int n = Points.Count - 1;
            for (int i = 0; i <= n; i++)
            {
                double[,] c0 = {{Points[i].X, Points[i].Y, 1}};
                var temp = MatrixUtils.MatrixMult(c0, C);
                newPoints.Add(new PointF((float) temp[0, 0], (float) temp[0, 1]));
            }

            return newPoints;
        }

        public virtual void Move(int dx, int dy)
        {
            //матрица движения
            double[,] m =
            {
                {1, 0, 0},
                {0, 1, 0},
                {dx, dy, 1}
            };

            C = MatrixUtils.MatrixMult(C, m);
        }

        public virtual void Rotate(PointF p, double angle)
        {
            var angleRad = angle * Math.PI / 180D;
            double cosf = Math.Cos(angleRad);
            double sinf = Math.Sin(angleRad);

            double[,] m = {{1, 0, 0}, {0, 1, 0}, {-p.X, -p.Y, 1}};
            double[,] mObr = {{1, 0, 0}, {0, 1, 0}, {p.X, p.Y, 1}};
            double[,] r = {{cosf, -sinf, 0}, {sinf, cosf, 0}, {0, 0, 1}};

            C = MatrixUtils.MatrixMult(C, MatrixUtils.MatrixMult(m, MatrixUtils.MatrixMult(r, mObr)));
        }

        public virtual void Mirror(Point a, State state)
        {
            switch (state)
            {
                case State.HorMirror:
                    HorMirror(a);
                    break;
                case State.VertMirror:
                    VertMirror(a);
                    break;
            }
        }

        public virtual void VertMirror(PointF a)
        {
            Move(-(int) (a.X), 0);

            double[,] m =
            {
                {-1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };

            C = MatrixUtils.MatrixMult(C, m);
            Move((int) (a.X), 0);
        }

        public virtual void HorMirror(PointF a)
        {
            Move(0, -(int) a.Y);

            double[,] m =
            {
                {1, 0, 0},
                {0, -1, 0},
                {0, 0, 1}
            };

            C = MatrixUtils.MatrixMult(C, m);
            Move(0, (int) a.Y);
        }

        public static void PutPoint(PointF position)
        {
            MainForm.G.DrawRectangle(DrawPenStatic , position.X, position.Y, 1, 1);
        }
    }
}