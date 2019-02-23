using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphicsProject.Figures
{
    public class Line : Figure
    {
        public Line(IList<PointF> points) : base(points)
        {
            Points = points.Select(point => point).ToList();
        }

        public static void Draw(Point begin, Point end)
        {
            var x1 = begin.X;
            var y1 = begin.Y;
            var x2 = end.X;
            var y2 = end.Y;
            int x, y, dx, dy, sx = 0, sy = 0;
            int f = 0, fx = 0, dFx = 0, fy = 0, dFy = 0;
            dx = x2 - x1;
            dy = y2 - y1;
            sx = Math.Sign(dx);
            sy = Math.Sign(dy);
            if (sx > 0) dFx = dy;
            else dFx = -dy;
            if (sy > 0) dFy = dx;
            else dFy = -dx;
            x = x1;
            y = y1;
            f = 0;
            if (Math.Abs(dx) >= Math.Abs(dy)) // угол наклона <= 45 градусов
                do
                {
                    //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (x == x2) break;
                    fx = f + dFx;
                    f = fx - dFy;
                    x = x + sx;
                    if (Math.Abs(fx) < Math.Abs(f)) f = fx;
                    else y = y + sy;
                } while (true);
            else // угол наклона > 45 градусов
                do
                {
                    //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (y == y2) break;
                    fy = f + dFy;
                    f = fy - dFx;
                    y = y + sy;
                    if (Math.Abs(fy) < Math.Abs(f)) f = fy;
                    else x = x + sx;
                } while (true);
        }

        public override void Draw()
        {
            var x1 = (int) Points[0].X;
            var y1 = (int) Points[0].Y;
            var x2 = (int) Points[1].X;
            var y2 = (int) Points[1].Y;
            int x, y, dx, dy, sx = 0, sy = 0;
            int f = 0, fx = 0, dFx = 0, fy = 0, dFy = 0;
            dx = x2 - x1;
            dy = y2 - y1;
            sx = Math.Sign(dx);
            sy = Math.Sign(dy);
            if (sx > 0) dFx = dy;
            else dFx = -dy;
            if (sy > 0) dFy = dx;
            else dFy = -dx;
            x = x1;
            y = y1;
            f = 0;
            if (Math.Abs(dx) >= Math.Abs(dy)) // угол наклона <= 45 градусов
                do
                {
                    //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (x == x2) break;
                    fx = f + dFx;
                    f = fx - dFy;
                    x = x + sx;
                    if (Math.Abs(fx) < Math.Abs(f)) f = fx;
                    else y = y + sy;
                } while (true);
            else // угол наклона > 45 градусов
                do
                {
                    //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y));
                    if (y == y2) break;
                    fy = f + dFy;
                    f = fy - dFx;
                    y = y + sy;
                    if (Math.Abs(fy) < Math.Abs(f)) f = fy;
                    else x = x + sx;
                } while (true);
        }
    }
}