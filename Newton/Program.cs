using System;

namespace Newton
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = 10e-4;
            
            Func <double, double> g = (x) =>  x = Math.Pow(x,4) - 16*Math.Pow(x,3) + 78 * Math.Pow(x,2) - 412 * x + 624;
            Func <double, double> dg = (x) =>  x = (g(x + h) - g(x)) / h;

            Newton(g,dg,-6.0,10e-6,1000);

        }

        public static void Newton(Func<double, double> f, Func<double, double> df, double p0, double TOL, int Nmax)
        {
            double p = 0;
            for (int i = 0; i < Nmax; i++)
            {
                    p = p0 - f(p0) / df(p0);
                    Console.WriteLine($"{i}\t{p0}\t{p}\t{Math.Abs(p - p0)}");
                    if(Math.Abs(p - p0) < TOL)
                        break;
                    p0 = p;
            }
        }
    }
}
