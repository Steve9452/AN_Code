using System;

namespace Discu_Metodo_de_Newton
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> f = x => Math.Cos(x) + 2.0 * Math.Sin(x) + Math.Pow(x, 2);
            Func<double, double> fd = x => -Math.Sin(x) + 2.0 * Math.Cos(x) + 2 * x;
        }
        static void Newton(double p0, double TOL, int Nmax, Func<double, double> f, Func<double, double> fd){
            double p = 0;
            for (int i = 0; i < Nmax; i++)
            {
                p = p0 - f(p0) / fd(p0);

                Console.WriteLine($"");
                if(Math.Abs(p - p0) < TOL)



            }
        }
    }
}
