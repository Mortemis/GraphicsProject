using System;
using System.Drawing;

namespace GraphicsProject.Figures
{
    public class Line : Figure
    {
        private Point Begin;
        private Point End;

        public Line(Point Begin, Point End)
        {
            this.Begin = Begin;
            this.End = End;
            SelectBegin = Begin;
            SelectEnd = End;
        }

        // Static method for other primitives
        public static void Draw(Point Begin, Point End)
        {
            Pen DrPen = MainForm.DrawPen;
            int x1 = Begin.X; int y1 = Begin.Y; int x2 = End.X; int y2 = End.Y;
            int x, y, dx, dy, Sx = 0, Sy = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            dx = x2 - x1;
            dy = y2 - y1;
            Sx = Math.Sign(dx);
            Sy = Math.Sign(dy);
            if (Sx > 0) dFx = dy;
            else dFx = -dy;
            if (Sy > 0) dFy = dx;
            else dFy = -dx;
            x = x1; y = y1;
            F = 0;
            if (Math.Abs(dx) >= Math.Abs(dy)) // угол наклона <= 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (x == x2) break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + Sy;
                } while (true);
            }
            else // угол наклона > 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (y == y2) break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + Sx;
                } while (true);
            }
        }

        public override void Draw()
        {
            Pen DrPen = MainForm.DrawPen;
            int x1 = Begin.X; int y1 = Begin.Y; int x2 = End.X; int y2 = End.Y;
            int x, y, dx, dy, Sx = 0, Sy = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            dx = x2 - x1;
            dy = y2 - y1;
            Sx = Math.Sign(dx);
            Sy = Math.Sign(dy);
            if (Sx > 0) dFx = dy;
            else dFx = -dy;
            if (Sy > 0) dFy = dx;
            else dFy = -dx;
            x = x1; y = y1;
            F = 0;
            if (Math.Abs(dx) >= Math.Abs(dy)) // угол наклона <= 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (x == x2) break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + Sy;
                } while (true);
            }
            else // угол наклона > 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (y == y2) break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + Sx;
                } while (true);
            }

        }

        public override string ToString()
        {
            return "Line";
        }
    }
}
