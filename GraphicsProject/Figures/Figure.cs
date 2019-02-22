using System.Drawing;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public abstract void Draw();

        public static void PutPoint(Point Position)
        {
            MainForm.g.DrawRectangle(MainForm.DrawPen, Position.X, Position.Y, 1, 1);
        }
    }

}
