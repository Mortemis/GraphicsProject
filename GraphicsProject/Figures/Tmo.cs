using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GraphicsProject.Utils;

namespace GraphicsProject.Figures
{
    public class Tmo : Figure
    {
        private readonly Figure _firstFigure;
        private readonly Figure _secondFigure;

        // тип ТМО
        private readonly State _tmoType;

        // границы ТМО
        private double _downY;
        private double _upY;
        private double _rightX;
        private double _leftX;

        private IList<PointF> _borderPoints;

        public Tmo(Figure fig1, Figure fig2, State tmoType)
        {
            _firstFigure = fig1;
            _secondFigure = fig2;
            _tmoType = tmoType;
        }

        public override IList<PointF> GetBorderPoints()
        {
            return _borderPoints;
        }

        public override void Draw()
        {
            _upY = 0;
            _downY = MainForm.CanvasHeight;

            _leftX = MainForm.CanvasWidth;
            _rightX = 0;

            var firstFigureNewPoints = _firstFigure.GetNewPoints();
            var secondFigureNewPoints = _secondFigure.GetNewPoints();

            //списки границ фигур
            var Xa = new List<double>();
            var Xb = new List<double>();

            var upperAndLowerBorder = BordersUtils.GetUpperAndLowerBorderTuple(firstFigureNewPoints);

            //ищем максимальные и минимальные значения по У
            int ymin = upperAndLowerBorder.Item1;
            int ymax = upperAndLowerBorder.Item2;

            var n = secondFigureNewPoints.Count() - 1;
            for (int i = 0; i < n; i++)
            {
                var y = (int) Math.Round(secondFigureNewPoints[i].Y);
                if (y < ymin) ymin = y;
                if (y > ymax) ymax = y;
            }

            if (ymin < 0)
                ymin = 0;
            if (ymax > MainForm.CanvasHeight)
                ymax = MainForm.CanvasHeight;

            _downY = ymin;
            _upY = ymax;

            //для У в границах многоугольника
            for (int y = ymin; y < ymax; y++)
            {
                //чистим списки
                Xa.Clear();
                Xb.Clear();
                //считаем число вершин пересекающихся со строкой
                Xa = GetCrossPoints(firstFigureNewPoints, y);
                Xb = GetCrossPoints(secondFigureNewPoints, y);

                if (Xa.Count() != 0 || Xb.Count() != 0)
                    DrawTmo(Xa, Xb, y);
            }

            _borderPoints = new List<PointF>
            {
                new PointF((float) _leftX, (float) _upY),
                new PointF((float) _rightX, (float) _upY),
                new PointF((float) _rightX, (float) _downY),
                new PointF((float) _leftX, (float) _downY)
            };
        }

        //пересечение фигуры со строкой У
        private List<double> GetCrossPoints(List<PointF> figurePoints, int y)
        {
            List<double> X = new List<double>();
            double x;
            int n = figurePoints.Count - 1;
            for (int i = 0; i < n; i++)
            {
                //критерий пересечения строки с многоугольником
                if (((figurePoints[i].Y < y) && (figurePoints[i + 1].Y >= y)) ||
                    ((figurePoints[i].Y >= y) && (figurePoints[i + 1].Y < y)))
                {
                    //вычисляем Х и записываем его в список
                    x = (y - figurePoints[i].Y) * (figurePoints[i + 1].X - figurePoints[i].X) /
                        (figurePoints[i + 1].Y - figurePoints[i].Y) + figurePoints[i].X;
                    X.Add(x);
                }
            }

            X.Sort();
            return X;
        }

        private void Sort(List<double[]> M)
        {
            for (int i = 0; i < M.Count - 1; i++)
            {
                for (int j = i + 1; j < M.Count; j++)
                {
                    if (M[i][0] > M[j][0])
                    {
                        var temp = M[i][0];
                        var tpQ = M[i][1];
                        M[i][0] = M[j][0];
                        M[i][1] = M[j][1];
                        M[j][0] = temp;
                        M[j][1] = tpQ;
                    }
                }
            }
        }

        private void DrawTmo(List<double> listf1, List<double> listf2, int y)
        {
            var Xrl = new List<double>();
            var Xrr = new List<double>();

            //массив приращения пороговых функций
            double[] setQ;

            //рабочий массив итоговых значений
            var M = new List<double[]>();

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
                double[] k = {listf1[i], 2};
                M.Add(k);
                double[] l = {listf1[i + 1], -2};
                M.Add(l);
            }

            n = listf2.Count();
            for (int i = 0; i < n; i += 2)
            {
                double[] k = {listf2[i], 1};
                M.Add(k);
                double[] l = {listf2[i + 1], -1};
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
                if (!BelongToArray(Q, setQ) && BelongToArray(Qn, setQ))
                {
                    Xrl.Add(x);
                }

                if (BelongToArray(Q, setQ) && !BelongToArray(Qn, setQ))
                {
                    Xrr.Add(x);
                }

                Q = Qn;
            }

            if (BelongToArray(Q, setQ))
                Xrr.Add(MainForm.CanvasWidth);

            //рисуем линию
            for (int i = 0; i < Xrl.Count(); i++)
            {
                G.DrawLine(DrawPen, (int) Xrl[i] + 1, y, (int) Xrr[i], y);

                // вычисляем границы
                if (_downY < y)
                    _downY = y;
                if (_rightX < Xrr[Xrr.Count - 1])
                    _rightX = (float) Xrr[Xrr.Count - 1];
                if (_upY > y)
                    _upY = y;
                if (_leftX > Xrl[0])
                    _leftX = (float) Xrl[0];
            }
        }

        //функция, выясняющая принадлежит ли значение массиву
        private bool BelongToArray(double q, double[] sq)
        {
            return sq.Contains(q);
        }

        public override bool IsSelected(int mX, int mY)
        {
            return _firstFigure.IsSelected(mX, mY) || _secondFigure.IsSelected(mX, mY);
        }

        public override void Move(int dx, int dy)
        {
            _firstFigure.Move(dx, dy);
            _secondFigure.Move(dx, dy);
        }

        public override void Rotate(PointF p, double angle)
        {
            _firstFigure.Rotate(p, angle);
            _secondFigure.Rotate(p, angle);
        }

        public override void Mirror(Point a, State state)
        {
            switch (state)
            {
                case State.HorMirror:
                    _firstFigure.HorMirror(a);
                    _secondFigure.HorMirror(a);
                    break;
                case State.VertMirror:
                    _firstFigure.VertMirror(a);
                    _secondFigure.VertMirror(a);
                    break;
            }
        }

        public override void VertMirror(PointF a)
        {
            _firstFigure.VertMirror(a);
            _secondFigure.VertMirror(a);
        }

        public override void HorMirror(PointF a)
        {
            _firstFigure.HorMirror(a);
            _secondFigure.HorMirror(a);
        }

        public override string ToString()
        {
            return "ТМО";       
        }
    }
}