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
            /*
            SelectBegin.X = (Figure1.SelectBegin.X + Figure2.SelectBegin.X) / 2;
            SelectBegin.Y = (Figure1.SelectBegin.Y + Figure2.SelectBegin.Y) / 2;
            SelectEnd.X = (Figure1.SelectEnd.X + Figure2.SelectEnd.X) / 2;
            SelectEnd.Y = (Figure1.SelectEnd.Y + Figure2.SelectEnd.Y) / 2;

            */
            SelectBegin = Points[0];
            SelectEnd = Points[1];
            /*
            SelectBegin.X = MinX;
            SelectBegin.Y = MinY;
            SelectEnd.X = MaxX;
            SelectEnd.Y = MaxY;*/
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
            Figure1.Scale(Scale);
            Figure2.Scale(Scale);
        }
 
    }
}

/*
namespace GraphicsProject.Figures
{
    public class Tmo : Figure
    {
        Figure f1;
        Figure f2;
        private State _tmoType;
        private double _downY;
        private double _upY;
        private double _rightX;
        private double _leftX;

        public Tmo(Figure fig1, Figure fig2, State tmoType)
        {
            f1 = fig1;
            f2 = fig2;
            _tmoType = tmoType;
        }

        public IList<PointF> GetBorderPoints()
        {
            return Points;
        }

        public override void Draw()
        {

            _upY = 0;
            _downY = MainForm.CanvasHeight;

            _leftX = MainForm.CanvasWidth;
            _rightX = 0;

            List<PointF> l1 = f1.GetNewPoints();
            List<PointF> l2 = f2.GetNewPoints();

            //списки границ фигур
            List<double> Xa = new List<double>();
            List<double> Xb = new List<double>();
            int n = l1.Count() - 1;
            //вычисляем границы фигуры по У
            int Ymin = (int)Math.Round(l1[0].Y);
            int Ymax = Ymin, y;
            for (int i = 0; i < n; i++)
            {
                y = (int)Math.Round(l1[i].Y);
                if (y < Ymin) Ymin = y;
                if (y > Ymax) Ymax = y;
            }

            n = l2.Count() - 1;
            for (int i = 0; i < n; i++)
            {
                y = (int)Math.Round(l2[i].Y);
                if (y < Ymin) Ymin = y;
                if (y > Ymax) Ymax = y;
            }

            if (Ymin < 0)
                Ymin = 0;
            if (Ymax > MainForm.CanvasHeight)
                Ymax = MainForm.CanvasHeight;

            _downY = Ymin;
            _upY = Ymax;

            //для У в границах многоугольника
            for (int Y = Ymin; Y < Ymax; Y++)
            {
                //чистим списки
                Xa.Clear();
                Xb.Clear();
                //считаем число вершин пересекающихся со строкой
                Xa = cross(l1, Y);
                Xb = cross(l2, Y);
                if (Xa.Count() != 0 || Xb.Count() != 0)
                    drawTMO(Xa, Xb, Y);
            }

            Points = new List<PointF>();
            Points.Add(new PointF((float)_leftX, (float)_upY));
            Points.Add(new PointF((float)_rightX, (float)_upY));
            Points.Add(new PointF((float)_rightX, (float)_downY));
            Points.Add(new PointF((float)_leftX, (float)_downY));

        }

        //пересечение фигуры со строкой У
        private List<double> cross(List<PointF> l, int y)
        {
            List<double> X = new List<double>();
            double x;
            int n = l.Count - 1;
            for (int i = 0; i < n; i++)
            {
                //критерий пересечения строки с многоугольником
                if (((l[i].Y < y) && (l[i + 1].Y >= y)) || ((l[i].Y >= y) && (l[i + 1].Y < y)))
                {
                    //вычисляем Х и записываем его в список
                    x = (y - l[i].Y) * (l[i + 1].X - l[i].X) / (l[i + 1].Y - l[i].Y) + l[i].X;
                    X.Add(x);
                }
            }

            X.Sort();
            return X;
        }

        private void Sort(List<double[]> M)
        {
            double temp, tpQ;
            for (int i = 0; i < M.Count - 1; i++)
            {
                for (int j = i + 1; j < M.Count; j++)
                {
                    if (M[i][0] > M[j][0])
                    {
                        temp = M[i][0];
                        tpQ = M[i][1];
                        M[i][0] = M[j][0];
                        M[i][1] = M[j][1];
                        M[j][0] = temp;
                        M[j][1] = tpQ;
                    }
                }
            }
        }

        //рисуем ТМО
        private void drawTMO(List<double> listf1, List<double> listf2, int y)
        {
            List<double> Xrl = new List<double>();
            List<double> Xrr = new List<double>();
            //массив приращения пороговых функций
            double[] setQ;
            //рабочий массив итоговых значений
            List<double[]> M = new List<double[]>();

            //объединение
            if (_tmoType == State.TmoUnion)
            {
                setQ = new double[3];
                setQ[0] = 1;
                setQ[1] = 2;
                setQ[2] = 3;
            }
            // пересечение
            else
            {
                setQ = new double[1];
                setQ[0] = 3;
            }

            //переписываем значения в итоговый массив
            int n = listf1.Count();
            for (int i = 0; i < n; i += 2)
            {
                double[] k = { listf1[i], 2 };
                M.Add(k);
                double[] l = { listf1[i + 1], -2 };
                M.Add(l);
            }

            n = listf2.Count();
            for (int i = 0; i < n; i += 2)
            {
                double[] k = { listf2[i], 1 };
                M.Add(k);
                double[] l = { listf2[i + 1], -1 };
                M.Add(l);
            }

            //сортируем массив
            Sort(M);

            double Q = 0, x, Qn;
            //если первый элемент массива правая граница сегмента
            if (M[0][0] >= 0 && M[0][1] < 0)
            {
                //добавляем левую границу
                Xrl.Add(0);
                Q = -M[0][1];
            }

            //внос значений в списки левых и правых границ
            for (int i = 0; i < M.Count; i++)
            {
                x = M[i][0];
                Qn = Q + M[i][1];
                if (!belong(Q, setQ) && belong(Qn, setQ))
                {
                    Xrl.Add(x);
                }

                if (belong(Q, setQ) && !belong(Qn, setQ))
                {
                    Xrr.Add(x);
                }

                Q = Qn;
            }

            if (belong(Q, setQ))
                Xrr.Add(MainForm.CanvasWidth);

            //рисуем линию
            for (int i = 0; i < Xrl.Count(); i++)
            {
                G.DrawLine(DrawPen, (int)Xrl[i] + 1, y, (int)Xrr[i], y);

                if (_downY < y)
                    _downY = y;
                if (_rightX < Xrr[Xrr.Count - 1])
                    _rightX = (float)Xrr[Xrr.Count - 1];
                if (_upY > y)
                    _upY = y;
                if (_leftX > Xrl[0])
                    _leftX = (float)Xrl[0];
            }
        }

        //функция, выясняющая принадлежит ли значение массиву
        private Boolean belong(double q, double[] sq)
        {
            for (int i = 0; i < sq.Length; i++)
                if (sq[i] == q)
                    return true;
            return false;
        }

        public override bool IsSelected(int mX, int mY)
        {
            return f1.IsSelected(mX, mY) || f2.IsSelected(mX, mY);
        }

        public override void Move(int dx, int dy)
        {
            f1.Move(dx, dy);
            f2.Move(dx, dy);
        }

        public override void Rotate(PointF p, double angle)
        {
            f1.Rotate(p, angle);
            f2.Rotate(p, angle);
        }

        public override void Mirror(PointF a, PointF b)
        {
            f1.Mirror(a, b);
            f2.Mirror(a, b);
        }
    }
}*/