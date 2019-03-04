using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphicsProject.Figures
{
    class Para : Polygon
    {

        public Para(Point Begin, Point End)
        {
            SelectBegin = Begin;
            SelectEnd = End;

            Points = new List<Point>();
            int Shift = (int)((End.X - Begin.X)/1.5);
            Point Point1 = new Point(Begin.X + Shift, End.Y);
            Point Point2 = new Point(End.X, Begin.Y);
            Point Point3 = new Point(End.X - Shift, Begin.Y);
            Point Point4 = new Point(Begin.X, End.Y);
            Points.Add(Point1);
            Points.Add(Point2);
            Points.Add(Point3);
            Points.Add(Point4);
            Points.Add(Point1);
        }

        public override string ToString()
        {
            return "Para";
        }
    }
}
