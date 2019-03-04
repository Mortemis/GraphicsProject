using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GraphicsProject.Figures
{
    public class Difference : SetOperation
    {
        public Difference(Figure figure1, Figure figure2) : base(figure1, figure2) { }

        public override void DrawSetOp(List<int> List1, List<int> List2, int y)
        {
            // Left & right borders lists.
            List<double> XrLeft = new List<double>();
            List<double> XrRight = new List<double>();
            // Incrementation array of threshold functions.
            double[] ThresholdIncr;
            // Final values list.
            List<double[]> M = new List<double[]>();

            // Difference
            ThresholdIncr = new double[1];
            ThresholdIncr[0] = 2;

            // Writing values to resulting array.
            for (int i = 0; i < List1.Count(); i += 2)
            {
                double[] k = { List1[i], 2 };
                M.Add(k);
                double[] l = { List1[i + 1], -2 };
                M.Add(l);
            }

            for (int i = 0; i < List2.Count(); i += 2)
            {
                double[] k = { List2[i], 1 };
                M.Add(k);
                double[] l = { List2[i + 1], -1 };
                M.Add(l);
            }

            // Sorting array.
            Sort(M);

            double Q = 0, x, Qn;
            // If first element is right border...
            if (M[0][0] >= 0 && M[0][1] < 0)
            {
                // Add left border.
                XrLeft.Add(0);
                Q = -M[0][1];
            }

            // Adding values to left & right borders lists.
            for (int i = 0; i < M.Count; i++)
            {
                x = M[i][0];
                Qn = Q + M[i][1];
                if (!Belong(Q, ThresholdIncr) && Belong(Qn, ThresholdIncr))
                {
                    XrLeft.Add(x);
                }

                if (Belong(Q, ThresholdIncr) && !Belong(Qn, ThresholdIncr))
                {
                    XrRight.Add(x);
                }

                Q = Qn;
            }

            if (Belong(Q, ThresholdIncr))
                XrRight.Add(MainForm.bmp.Width);

            // Drawing horizontal lines.
            for (int i = 0; i < XrLeft.Count(); i++)
            {
                Line.Draw(new Point((int)XrLeft[i] + 1, y), new Point((int)XrRight[i], y), FigureColor);
                // Finding selection borders.
                if (MaxY < y)
                    MaxY = y;
                if (MaxX < XrRight[XrRight.Count - 1])
                    MaxX = (int)XrRight[XrRight.Count - 1];
                if (MinY > y)
                    MinY = y;
                if (MinX > XrLeft[0])
                    MinX = (int)XrLeft[0];
            }
        }

        public override string ToString()
        {
            return "Difference";
        }
    }
}
 
