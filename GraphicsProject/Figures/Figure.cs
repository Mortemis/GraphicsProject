using System;
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

        protected double[,] C =
        {
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
        };

        public void Move(int dx, int dy)
        {
            //матрица движения
            double[,] M =
            {
                {1, 0, 0},
                {0, 1, 0},
                {dx, dy, 1}
            };

            C = MathUtils.MultiplyMatrices(C, M);
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
