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
        
        public static int SelectGap = 5;
        public List<Point> Points = new List<Point>();

        public Color FigureColor = Color.Black;

        //Transformation matrix. 
        protected double[,] C =
        {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        };


        public virtual void Move(int DeltaX, int DeltaY)
        {
            //Move matrix
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

        public virtual void Rotate(Point Center, double Angle)
        {
            double AngleRadian = Angle * Math.PI / 180D;
            double cosf = Math.Cos(AngleRadian);
            double sinf = Math.Sin(AngleRadian);

            double[,] M = { 
                { 1, 0, 0 }, 
                { 0, 1, 0 }, 
                { -Center.X, -Center.Y, 1 } };
            double[,] MReversed = { { 1, 0, 0 }, { 0, 1, 0 }, { Center.X, Center.Y, 1 } };
            //Rotation matrix
            double[,] R = { 
                { cosf, -sinf, 0 }, 
                { sinf, cosf, 0 }, 
                { 0, 0, 1 }
            };
            C = MathUtils.MultiplyMatrices(C, MathUtils.MultiplyMatrices(M, MathUtils.MultiplyMatrices(R, MReversed)));
        }

        public virtual void Scale(double Scale)
        {
            Point Center = new Point(SelectBegin.X + (SelectEnd.X - SelectBegin.X)/2, SelectBegin.Y +(SelectEnd.Y - SelectBegin.Y) / 2);
            double[,] M = { { 1, 0, 0 }, { 0, 1, 0 }, { -Center.X, -Center.Y, 1 } };
            double[,] MObr = { { 1, 0, 0 }, { 0, 1, 0 }, { Center.X, Center.Y, 1 } };
            //Scale matrix
            double[,] S =
            {
                {Scale, 0, 0},
                {0, Scale, 0},
                {0, 0, 1 }
            };
            C = MathUtils.MultiplyMatrices(C, MathUtils.MultiplyMatrices(M, MathUtils.MultiplyMatrices(S, MObr)));
        }

        public virtual void Scale(double Scale, Point Center)
        {
            double[,] M = { { 1, 0, 0 }, { 0, 1, 0 }, { -Center.X, -Center.Y, 1 } };
            double[,] MObr = { { 1, 0, 0 }, { 0, 1, 0 }, { Center.X, Center.Y, 1 } };
            //Scale matrix
            double[,] S =
            {
                {Scale, 0, 0},
                {0, Scale, 0},
                {0, 0, 1 }
            };
            C = MathUtils.MultiplyMatrices(C, MathUtils.MultiplyMatrices(M, MathUtils.MultiplyMatrices(S, MObr)));
        }

        public void SetTransformationMatrix(double[,] TransformMatrix)
        {
            C = TransformMatrix;
        }

        /*
         * Checks if point belongs to figure. 
         */
        public bool BelongsToFigure(Point Point)
        {
            int mX = Point.X;
            int mY = Point.Y;
            int n = Points.Count - 1, k = 0;
            PointF Pi, Pk; 
            double x;
            List<int> SegmentBuffer = new List<int>();
            bool Flag = false;

            SegmentBuffer.Clear();
            for (int i = 0; i <= n; i++)
            {
                if (i < n) k = i + 1;
                else k = 0;
                Pi = Points[i];
                Pk = Points[k];
                if ((Pi.Y < mY) & (Pk.Y >= mY) | (Pi.Y >= mY) & (Pk.Y < mY))
                {
                    x = (mY - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y) + Pi.X;
                    SegmentBuffer.Add((int)Math.Round(x));
                }
            }

            if (SegmentBuffer.Any())
            {
                SegmentBuffer.Sort();
                for (int i = 0; i < SegmentBuffer.Count; i = i + 2)
                {
                    if (mX >= SegmentBuffer[i] & mX <= SegmentBuffer[i + 1])
                    {
                        Flag = true;
                        break;
                    }
                }
            }

            return Flag;
        }

        /*
         * Applying transformations stored in C matrix.
         */
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

        /*
         * Draws selection rectangle. 
         */
        public void DrawSelect()
        {
            Rect Select = new Rect(SelectBegin, SelectEnd);
            Select.Draw();
        }


        public abstract void Draw();

        public static void PutPoint(Point Position, Color FigureColor)
        {
            if (Position.Y < MainForm.bmp.Height && Position.Y >= 0 && Position.X < MainForm.bmp.Width && Position.X >= 0)
                MainForm.bmp.SetPixel(Position.X, Position.Y, FigureColor);
        }


    }

}
