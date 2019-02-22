using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProject.Figures
{
    abstract class Polygon : Figure
    {
        List<Point> _points = new List<Point>();


        public void Fill()
        {
            int yMin;
            int yMax;
            yMin = _points[0].Y;
            yMax = _points[0].Y;

            //Вычисление минимального и максимального Y.
            for (int y = 1; y < _points.Count; y++)
            {
                if (_points[y].Y < yMin)
                {
                    yMin = _points[y].Y;
                }

                if (_points[y].Y > yMax)
                {
                    yMax = _points[y].Y;
                }
            }

            //j - индекс точки в списке точек.
            //k - индекс следующей точки в списке точек.
            for (int y = yMin; y < yMax + 1; y++)
            {
                List<int> xList = new List<int>();
                for (int j = 0; j < _points.Count - 1; j++)
                {
                    int k;
                    if (j < _points.Count)
                    {
                        k = j + 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    if ((_points[j].Y < y && _points[k].Y >= y) || (_points[j].Y >= y && _points[k].Y < y))
                    {
                        Point pt1 = _points[j];
                        Point pt2 = _points[k];
                        Point pt3 = new Point(0, y);
                        // HACK idk how to get width from canvas
                        Point pt4 = new Point(MainForm.Width - 1, y);

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
