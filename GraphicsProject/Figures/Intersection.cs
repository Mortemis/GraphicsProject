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

        public override void DrawSetOp(List<int> List1, List<int> List2, int y)
        {
            List<double> Xrl = new List<double>();
            List<double> Xrr = new List<double>();
            //массив приращения пороговых функций
            double[] ThresholdIncr;
            //рабочий массив итоговых значений
            List<double[]> M = new List<double[]>();


            // пересечение
            ThresholdIncr = new double[1];
            ThresholdIncr[0] = 3;

            //переписываем значения в итоговый массив
            int n = List1.Count();
            for (int i = 0; i < n; i += 2)
            {
                double[] k = { List1[i], 2 };
                M.Add(k);
                double[] l = { List1[i + 1], -2 };
                M.Add(l);
            }

            n = List2.Count();
            for (int i = 0; i < n; i += 2)
            {
                double[] k = { List2[i], 1 };
                M.Add(k);
                double[] l = { List2[i + 1], -1 };
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
                if (!Belong(Q, ThresholdIncr) && Belong(Qn, ThresholdIncr))
                {
                    Xrl.Add(x);
                }

                if (Belong(Q, ThresholdIncr) && !Belong(Qn, ThresholdIncr))
                {
                    Xrr.Add(x);
                }

                Q = Qn;
            }

            if (Belong(Q, ThresholdIncr))
                Xrr.Add(MainForm.bmp.Width);

            //рисуем линию
            for (int i = 0; i < Xrl.Count(); i++)
            {
                Line.Draw(new Point((int)Xrl[i] + 1, y), new Point((int)Xrr[i], y), FigureColor);
                if (MaxY < y)
                    MaxY = y;
                if (MaxX < Xrr[Xrr.Count - 1])
                    MaxX = (int)Xrr[Xrr.Count - 1];
                if (MinY > y)
                    MinY = y;
                if (MinX > Xrl[0])
                    MinX = (int)Xrl[0];
            }
        }

        public override string ToString()
        {
            return "Intersection";
        }
    }
}
