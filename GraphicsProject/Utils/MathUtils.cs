namespace GraphicsProject.Utils
{
    public static class MathUtils
    {
        //Массив, который инициализируется факториалами для ускорения работы программы. 
        public static readonly double[] Factorials;

        static MathUtils()
        {
            Factorials = new double[30];
            InitFactorials();
        }

        private static void InitFactorials()
        {
            for (int i = 0; i < Factorials.Length; i++)
            {
                Factorials[i] = Factorial(i);
            }
        }

        private static double Factorial(int numb)
        {
            double res = 1;
            for (int i = numb; i > 1; i--) res *= i;
            return res;
        }

        public static double[,] MultiplyMatrices(double[,] a, double[,] b)
        {
            double[,] Result = new double[a.GetLength(0), b.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        Result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return Result;
        }
    }
}