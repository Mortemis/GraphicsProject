using System.Drawing;

namespace GraphicsProject.Figures
{
    public abstract class Figure
    {
        public abstract void Draw();

        public static void PutPoint(Point position)
        {
            MainForm.G.DrawRectangle(MainForm.DrawPen, position.X, position.Y, 1, 1);
        }
    }

}
