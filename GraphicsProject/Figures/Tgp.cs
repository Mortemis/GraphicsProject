using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GraphicsProject.Figures
{
    public class Tgp : Polygon
    {

        public Tgp(Point centerPoint):base(centerPoint)
        {
            Points = new List<PointF>
            {
                new Point(centerPoint.X - 50, centerPoint.Y + 45),
                new Point(centerPoint.X - 50, centerPoint.Y - 45),
                new Point(centerPoint.X + 50, centerPoint.Y - 45),

            };

            Points.Add(Points.First());
            Draw();
        }

    }
}