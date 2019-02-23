using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProject.Utils
{
    public static class MatrixUtils
    {
        public static double[,] MatrixMult(double[,] a, double[,] b)
        {
            double[,] rez = new double[a.GetLength(0), b.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        rez[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return rez;
        }
    }
}