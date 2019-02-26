using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject.Figures
{
    public class Intersection : SetOperation
    {
        public Intersection(Figure figure1, Figure figure2) : base(figure1, figure2) { }

        public override void drawTMO(List<int> listf1, List<int> listf2, int y)
        {
            List<double> Xrl = new List<double>();
            List<double> Xrr = new List<double>();
            //массив приращения пороговых функций
            double[] setQ;
            //рабочий массив итоговых значений
            List<double[]> M = new List<double[]>();


            // пересечение
            setQ = new double[1];
            setQ[0] = 3;

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
                Xrr.Add(MainForm.bmp.Width);

            //рисуем линию
            for (int i = 0; i < Xrl.Count(); i++)
            {
                //G.DrawLine(MainForm.DrawPen, (int)Xrl[i] + 1, y, (int)Xrr[i], y);
                Line.Draw(new Point((int)Xrl[i] + 1, y), new Point((int)Xrr[i], y));
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
    }
}
