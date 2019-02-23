using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProject.Figures
{
    public abstract class Polygon : Figure
    {
        public List<Point> Points = new List<Point>();


        public void Fill()
        {
            int yMin;
            int yMax;
            yMin = Points[0].Y;
            yMax = Points[0].Y;

            //Вычисление минимального и максимального Y.
            for (int y = 1; y < Points.Count; y++)
            {
                if (Points[y].Y < yMin)
                {
                    yMin = Points[y].Y;
                }

                if (Points[y].Y > yMax)
                {
                    yMax = Points[y].Y;
                }
            }

            //j - индекс точки в списке точек.
            //k - индекс следующей точки в списке точек.
            for (int y = yMin; y < yMax + 1; y++)
            {
                List<int> xList = new List<int>();
                for (int j = 0; j < Points.Count - 1; j++)
                {
                    int k;
                    if (j < Points.Count)
                    {
                        k = j + 1;
                    }
                    else
                    {
                        k = 0;
                    }
                    if ((Points[j].Y < y && Points[k].Y >= y) || (Points[j].Y >= y && Points[k].Y < y))
                    {
                        Point pt1 = Points[j];
                        Point pt2 = Points[k];
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
                    Line.Draw(new Point(xList[j], y), new Point(xList[j + 1], y));
                    //DrawLine(DrawPen, xList[j], y, xList[j + 1], y);  //= new Line...
                }
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < Points.Count-1; i++)
            {
                Line.Draw(Points[i], Points[i + 1]);
            }
            Fill();
        }

        public override string ToString()
        {
            return "Poly";
        }
    }
}
