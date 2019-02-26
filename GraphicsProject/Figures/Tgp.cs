using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public class Tgp : Polygon
    {
        public Tgp(Point centerPoint) 
        {
            Points = new List<PointF>
            {
                new Point(centerPoint.X - 50, centerPoint.Y + 45),
                new Point(centerPoint.X - 50, centerPoint.Y - 45),
                new Point(centerPoint.X + 50, centerPoint.Y - 45),
            };

            Points.Add(Points.First());
        }

        public override string ToString()
        {
            return NamesUtils.Tgp;
        }
    }
}