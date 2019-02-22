using System.Drawing;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public abstract void Draw();

        protected static Pen DrawPen = MainForm.DrawPen;

        public static void PutPoint(Point position)
        {
            MainForm.G.DrawRectangle(DrawPen, position.X, position.Y, 1, 1);
        }
    }

}
