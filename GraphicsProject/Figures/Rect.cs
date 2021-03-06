﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject.Figures
{
    public class Rect : Polygon
    {
        public Rect(Point Begin, Point End)
        {
            Begin.X -= SelectGap;
            Begin.Y -= SelectGap;
            End.X += SelectGap;
            End.Y += SelectGap;

            Points = new List<Point>();
            Point Point1 = new Point(Begin.X, End.Y);
            Point Point2 = new Point(End.X, Begin.Y);
            Points.Add(Begin);
            Points.Add(Point1);
            Points.Add(End);
            Points.Add(Point2);
            Points.Add(Begin);
        }

        public override void Draw()
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                Line.Draw(Points[i], Points[i + 1], FigureColor);
            }

        }

        public override string ToString()
        {
            return "Rect";
        }

    }
}
