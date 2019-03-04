using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProject.Figures
{
    public abstract class Polygon : Figure
    {

        private void Fill()
        {
            var Points = ApplyTransformations();
            int yMin;
            int yMax;
            yMin = Points[0].Y;
            yMax = Points[0].Y;

            //Finding min&max Y.
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
                        Point pt4 = new Point(MainForm.bmp.Width - 1, y);
                        // Из уравнения прямой.
                        int x = (y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y) + pt1.X;
                        xList.Add(x);

                    }
                }
                xList.Sort();
                for (int j = 0; j < xList.Count / 2; j += 2)
                {
                    Line.Draw(new Point(xList[j], y), new Point(xList[j + 1], y), FigureColor);
                }
            }
        }

        private void FindSelection(List<Point> Points)
        {
            SelectBegin.X = Points[0].X;
            SelectEnd.X = Points[0].X;
            SelectBegin.Y = Points[0].Y;
            SelectEnd.Y = Points[0].Y;
            foreach (var Point in Points)
            {
                if (SelectBegin.X > Point.X) SelectBegin.X = Point.X;
                if (SelectBegin.Y > Point.Y) SelectBegin.Y = Point.Y;
                if (SelectEnd.X < Point.X) SelectEnd.X = Point.X;
                if (SelectEnd.Y < Point.Y) SelectEnd.Y = Point.Y;
            }
        } 

        public override void Draw()
        {
            var Points = ApplyTransformations();
            FindSelection(Points);
            for (int i = 0; i < Points.Count-1; i++)
            {
                Line.Draw(Points[i], Points[i + 1], FigureColor);
            }
            Fill();
            if (IsSelected) DrawSelect();
            
        }

        public override string ToString()
        {
            return "Poly";
        }
    }
}
