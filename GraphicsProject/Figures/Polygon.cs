using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProject.Figures
{
    abstract class Polygon : Figure
    {
        List<Point> points = new List<Point>();


        public void Fill()
        {
            int yMin;
            int yMax;
            yMin = points[0].Y;
            yMax = points[0].Y;

            //Вычисление минимального и максимального Y.
            for (int y = 1; y < points.Count; y++)
            {
                if (points[y].Y < yMin)
                {
                    yMin = points[y].Y;
                }

                if (points[y].Y > yMax)
                {
                    yMax = points[y].Y;
                }
            }

            //j - индекс точки в списке точек.
            //k - индекс следующей точки в списке точек.
            for (int y = yMin; y < yMax + 1; y++)
            {
                List<int> xList = new List<int>();
                for (int j = 0; j < points.Count - 1; j++)
                {
                    int k;
                    if (j < points.Count)
                    {
                        k = j + 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    if ((points[j].Y < y && points[k].Y >= y) || (points[j].Y >= y && points[k].Y < y))
                    {
                        Point pt1 = points[j];
                        Point pt2 = points[k];
                        Point pt3 = new Point(0, y);
                        // HACK idk how to get width from canvas
                        Point pt4 = new Point(MainForm.width - 1, y);

                        // int x = 0;
                        
                        // Из уравнения прямой.
                        int x = (y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y) + pt1.X;
                        xList.Add(x);

                    }
                }
                xList.Sort();
                for (int j = 0; j < xList.Count / 2; j += 2)
                {
                    //DrawLine(DrawPen, xList[j], y, xList[j + 1], y);  //= new Line...
                }
            }
        }


    }
}
