using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public bool IsSelected;
        public Point SelectBegin;
        public Point SelectEnd;
        public static int SelectGap = 0;
        public List<Point> Points = new List<Point>();


        protected double[,] C =
        {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        };


        public void Move(int DeltaX, int DeltaY)
        {
            //матрица движения
            double[,] M =
            {
                {1, 0, 0},
                {0, 1, 0},
                {DeltaX, DeltaY, 1}
            };

            C = MathUtils.MultiplyMatrices(C, M);

            SelectBegin.X += DeltaX;
            SelectBegin.Y += DeltaY;
            SelectEnd.X += DeltaX;
            SelectEnd.Y += DeltaY;
        }

        public void Rotate(Point center, double Angle)
        {
            double AngleRadian = Angle * Math.PI / 180D;
            double cosf = Math.Cos(AngleRadian);
            double sinf = Math.Sin(AngleRadian);

            double[,] M = { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] MObr = { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            double[,] R = { { cosf, -sinf, 0 }, { sinf, cosf, 0 }, { 0, 0, 1 } };

            C = MathUtils.MultiplyMatrices(C, MathUtils.MultiplyMatrices(M, MathUtils.MultiplyMatrices(R, MObr)));
        }

        public void Scale(int Scale)
        {
            double ScaleD = Scale / 100;
            double[,] S =
            {
                {1+ScaleD/100, 0, 0},
                {0, 1+ScaleD/100, 0},
                {0, 0, 1}
            };
            C = MathUtils.MultiplyMatrices(C, S);
        }
        public bool BelongsToFigure(Point Point)
        {
            int mX = Point.X;
            int mY = Point.Y;
            int n = Points.Count - 1, k = 0;
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
                    Xb.Add((int)Math.Round(x));
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

        public List<Point> ApplyTransformations()
        {
            var NewPoints = new List<Point>();
            int n = Points.Count - 1;
            for (int i = 0; i <= n; i++)
            {
                double[,] C0 = { { Points[i].X, Points[i].Y, 1 } };
                var temp = MathUtils.MultiplyMatrices(C0, C);
                NewPoints.Add(new Point((int)temp[0, 0], (int)temp[0, 1]));
            }
            return NewPoints;
        }
 

        public void DrawSelect()
        {
            Rect Select = new Rect(SelectBegin, SelectEnd);
            Select.Draw();
        }


        public abstract void Draw();

        public static void PutPoint(Point Position)
        {
            //MainForm.g.DrawRectangle(MainForm.DrawPen, Position.X, Position.Y, 1, 1);
            if (Position.Y < MainForm.bmp.Height && Position.Y >= 0 && Position.X < MainForm.bmp.Width && Position.X >= 0)
            MainForm.bmp.SetPixel(Position.X, Position.Y, Color.Black);
        }


    }

}
