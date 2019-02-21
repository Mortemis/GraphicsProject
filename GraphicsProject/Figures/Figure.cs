using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject
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
