using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphicsProject.Utils
{
    public static class BordersUtils
    {
        public static Tuple<int, int> GetUpperAndLowerBorderTuple(IList<PointF> points)
        {
            //вычисляем границы фигуры по У
            int ymin = (int) Math.Round( points.Max(point => point.Y));
            int ymax = (int)Math.Round(points.Min(point => point.Y));

            if (ymin < 0)
                ymin = 0;
            if (ymax > MainForm.CanvasHeight)
                ymax = MainForm.CanvasHeight;

            return new Tuple<int, int>(ymax, ymin);
        }
    }
}