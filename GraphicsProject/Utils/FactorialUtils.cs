using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProject.Utils
{
    public static class FactorialUtils
    {
        //Массив, который инициализируется факториалами для ускорения работы программы.
        public static double[] Factorials { get; set; }

        static FactorialUtils()
        {
            Factorials = new double[50];
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
