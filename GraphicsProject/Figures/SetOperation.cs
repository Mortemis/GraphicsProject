using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject.Figures
{
    public abstract class SetOperation : Figure
    {
        public Figure Figure1;
        public Figure Figure2;

        // For selection.
        protected int MaxY;
        protected int MinY;
        protected int MaxX;
        protected int MinX;

        public SetOperation(Figure figure1, Figure figure2)
        {
            Figure1 = figure1;
            Figure2 = figure2;
        }

        public override void Draw()
        {

            MinY = 0;
            MaxY = MainForm.bmp.Height;

            MinX = MainForm.bmp.Width;
            MaxX = 0;

            List<Point> l1 = Figure1.ApplyTransformations();
            List<Point> l2 = Figure2.ApplyTransformations();



            // Border list.
            var Xa = new List<int>();
            var Xb = new List<int>();
            int n = l1.Count() - 1;
            // Finding Y borders.
            int Ymin = l1[0].Y;
            int Ymax = Ymin, y;
            for (int i = 0; i < n; i++)
            {
                y = l1[i].Y;
                if (y < Ymin) Ymin = y;
                if (y > Ymax) Ymax = y;
            }

            n = l2.Count() - 1;
            for (int i = 0; i < n; i++)
            {
                y = l2[i].Y;
                if (y < Ymin) Ymin = y;
                if (y > Ymax) Ymax = y;
            }


            if (Ymin < 0)
                Ymin = 0;
            if (Ymax > MainForm.bmp.Height)
                Ymax = MainForm.bmp.Height;


            MaxY = Ymin;
            MinY = Ymax;


            for (int Y = Ymin; Y < Ymax; Y++)
            {
                Xa.Clear();
                Xb.Clear();
                //Finding vertices crossing lines.
                Xa = GetCrossPoints(l1, Y);
                Xb = GetCrossPoints(l2, Y);
                if (Xa.Count() != 0 || Xb.Count() != 0)
                    DrawSetOp(Xa, Xb, Y);
            }

            Points = new List<Point>();
            Points.Add(new Point(MinX, MinY));
            Points.Add(new Point(MaxX, MaxY));
            FindSelection();
            if (IsSelected) DrawSelect();

        }

        public abstract void DrawSetOp(List<int> List1, List<int> List2, int y);

        private List<int> GetCrossPoints(List<Point> l, int y)
        {
            var X = new List<int>();
            double x;
            int n = l.Count - 1;
            for (int i = 0; i < n; i++)
            {
                //критерий пересечения строки с многоугольником
                if (((l[i].Y < y) && (l[i + 1].Y >= y)) || ((l[i].Y >= y) && (l[i + 1].Y < y)))
                {
                    //вычисляем Х и записываем его в список
                    x = (y - l[i].Y) * (l[i + 1].X - l[i].X) / (l[i + 1].Y - l[i].Y) + l[i].X;
                    X.Add((int)x);
                }
            }

            X.Sort();
            return X;
        }

        protected void Sort(List<double[]> M)
        {
            double Temp, Temp2;
            for (int i = 0; i < M.Count - 1; i++)
            {
                for (int j = i + 1; j < M.Count; j++)
                {
                    if (M[i][0] > M[j][0])
                    {
                        Temp = M[i][0];
                        Temp2 = M[i][1];
                        M[i][0] = M[j][0];
                        M[i][1] = M[j][1];
                        M[j][0] = Temp;
                        M[j][1] = Temp2;
                    }
                }
            }
        }

        protected Boolean Belong(double Double, double[] DoubleArray)
        {
            for (int i = 0; i < DoubleArray.Length; i++)
                if (DoubleArray[i] == Double)
                    return true;
            return false;
        }

        protected void FindSelection()
        {

            SelectBegin = Points[0];
            SelectEnd = Points[1];

        }

        protected Point GetCenter()
        {
            return new Point(SelectBegin.X + (SelectEnd.X - SelectBegin.X) / 2, SelectBegin.Y + (SelectEnd.Y - SelectBegin.Y) / 2);
        }

        public override void Move(int DeltaX, int DeltaY)
        {
            Figure1.Move(DeltaX, DeltaY);
            Figure2.Move(DeltaX, DeltaY);
        }

        public override void Rotate(Point Pt, double Angle)
        {
            Figure1.Rotate(Pt, Angle);
            Figure2.Rotate(Pt, Angle);
        }

        public override void Scale(double Scale)
        {
            Figure1.Scale(Scale, GetCenter());
            Figure2.Scale(Scale, GetCenter());
        }

    }
}
