using System;
using System.Drawing;

namespace GraphicsProject.Figures
{
    public class Line : Figure
    {


        public Line(Point Begin, Point End)
        {
            Points.Clear();
            Points.Add(Begin);
            Points.Add(End);
            SelectBegin = Begin;
            SelectEnd = End;
        }

        private void FindSelection(Point Begin, Point End)
        {
            if (Begin.X < End.X)
            {
                SelectBegin.X = Begin.X;
                SelectEnd.X = End.X;
            }
            else
            {
                SelectBegin.X = End.X;
                SelectEnd.X = Begin.X;
            }
            if (Begin.Y < End.Y)
            {
                SelectBegin.Y = Begin.Y;
                SelectEnd.Y = End.Y;
            }
            else
            {
                SelectBegin.Y = End.Y;
                SelectEnd.Y = Begin.Y;
            }
        }
        // Static method for other primitives
        public static void Draw(Point Begin, Point End, Color FigureColor)
        {
            Pen DrPen = MainForm.DrawPen;
            int Point1X = Begin.X; int Point1Y = Begin.Y; int Point2X = End.X; int Point2Y = End.Y;
            int x, y, DeltaX, DeltaY, SignX = 0, SignY = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            DeltaX = Point2X - Point1X;
            DeltaY = Point2Y - Point1Y;
            SignX = Math.Sign(DeltaX);
            SignY = Math.Sign(DeltaY);

            // Выбрать направление движения.
            if (SignX > 0) dFx = DeltaY;
            else dFx = -DeltaY;
            if (SignY > 0) dFy = DeltaX;
            else dFy = -DeltaX;
            x = Point1X; y = Point1Y;
            F = 0;

            if (Math.Abs(DeltaX) >= Math.Abs(DeltaY)) // угол наклона <= 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y), FigureColor);
                    if (x == Point2X) break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + SignX;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + SignY;
                } while (true);
            }
            else // угол наклона > 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y), FigureColor);
                    if (y == Point2Y) break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + SignY;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + SignX;
                } while (true);
            }
        }


        public override void Draw()
        {
            var Points = ApplyTransformations();
            FindSelection(Points[0], Points[1]);
            Pen DrPen = MainForm.DrawPen;
            int Point1X = Points[0].X; int Point1Y = Points[0].Y; int Point2X = Points[1].X; int Point2Y = Points[1].Y;
            int x, y, DeltaX, DeltaY, SignX = 0, SignY = 0;
            int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0;
            DeltaX = Point2X - Point1X;
            DeltaY = Point2Y - Point1Y;
            SignX = Math.Sign(DeltaX);
            SignY = Math.Sign(DeltaY);

            // Выбрать направление движения.
            if (SignX > 0) dFx = DeltaY;
            else dFx = -DeltaY;
            if (SignY > 0) dFy = DeltaX;
            else dFy = -DeltaX;
            x = Point1X; y = Point1Y;
            F = 0;
            if (Math.Abs(DeltaX) >= Math.Abs(DeltaY)) // угол наклона <= 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y), FigureColor);
                    if (x == Point2X) break;
                    Fx = F + dFx;
                    F = Fx - dFy;
                    x = x + SignX;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx;
                    else y = y + SignY;
                } while (true);
            }
            else // угол наклона > 45 градусов
            {
                do
                { //Вывести пиксель с координатами х, у
                    PutPoint(new Point(x, y), FigureColor);
                    if (y == Point2Y) break;
                    Fy = F + dFy;
                    F = Fy - dFx;
                    y = y + SignY;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy;
                    else x = x + SignX;
                } while (true);
            }
            if (IsSelected) DrawSelect();
        }

        public override string ToString()
        {
            return "Line";
        }
    }
}
