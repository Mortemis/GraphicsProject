using System;
using System.Drawing;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public Point SelectBegin;
        public Point SelectEnd;

        //public abstract void FetchSelectRectangle();

        public void DrawSelect()
        {
            Rect Select = new Rect(SelectBegin, SelectEnd);
            Select.Draw();
        }

        public abstract void Draw();

        public static void PutPoint(Point Position)
        {
            MainForm.g.DrawRectangle(MainForm.DrawPen, Position.X, Position.Y, 1, 1);
        }
    }

}
