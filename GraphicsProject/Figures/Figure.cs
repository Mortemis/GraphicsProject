using System;
using System.Collections.Generic;
using System.Drawing;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public Point SelectBegin;
        public Point SelectEnd;
        public Point RotationCenter;
        public int Rotation = 0;

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
            SelectEnd.Y += DeltaX;
        }

        /*
        public void Move(int DeltaX, int DeltaY)
        {
            SelectBegin.X += DeltaX;
            SelectBegin.Y += DeltaY;
            SelectEnd.X += DeltaX;
            SelectEnd.Y += DeltaX;
        }*/

        //
        public void ApplyTransformations()
        {

            var newPoints = new List<Point>();
            int n = Points.Count - 1;
            for (int i = 0; i <= n; i++)
            {
                double[,] C0 = { { Points[i].X, Points[i].Y, 1 } };
                var temp = MathUtils.MultiplyMatrices(C0, C);
                newPoints.Add(new Point((int)temp[0, 0], (int)temp[0, 1]));
            }
            Points = newPoints;
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
        
        public void DrawSelect()
        {
            Rect Select = new Rect(SelectBegin, SelectEnd);
            Select.Draw();
        }

        public abstract void Draw();

        public static void PutPoint(Point Position)
        {
            MainForm.g.DrawRectangle(MainForm.DrawPen, Position.X, Position.Y, 1, 1);
            
            //MainForm.bmp.SetPixel(Position.X, Position.Y, Color.Black);
        }
    }

}
