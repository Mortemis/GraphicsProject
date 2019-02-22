namespace GraphicsProject.Utils
{
    public static class FactorialUtils
    {
        //Массив, который инициализируется факториалами для ускорения работы программы. 
        public static readonly double[] Factorials;

        static FactorialUtils()
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
    }
}