using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject.Figures
{
    public class Angle : Polygon
    {
        public Angle(Point Begin, Point End)
        {
            SelectBegin = Begin;
            SelectEnd = End;

            int HalfWidth = (End.X - Begin.X) / 2;
            int HalfHeight = (End.Y - Begin.Y) / 2;
            Points.Add(Begin);
            Points.Add(new Point(Begin.X + HalfWidth, Begin.Y));
            Points.Add(new Point(Begin.X + HalfWidth, Begin.Y + HalfHeight));
            Points.Add(new Point(End.X, Begin.Y + HalfHeight));
            Points.Add(End);
            Points.Add(new Point(Begin.X, End.Y));
            Points.Add(Begin);
        }
    
    }
}
