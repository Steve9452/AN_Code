using System;

namespace MetodoSecante
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<double,double> f1 = x => x - Math.Cos(x);
            Func<double, double> f2 = x => Math.Cos(x) - x; MetodoSecante(f2,0.4,0.5,10e-20,10000);
        }
        public static void MetodoSecante(Func<double,double> f,double p0, double p1, double TOL, int Nmax)
        {
            double p = 0;
            for (int i = 0; i < Nmax; i++)
            {
                p = p1 - f(p1) * (p1 - p0) / (f(p1) - f(p0)) ;
                Console.WriteLine($"{i}\t{p0}\t{p1}\t{p}\t{Math.Abs(p - p1)}");
                if(Math.Abs(p - p1) < TOL)
                    break;
                p0 = p1; p1 = p;
            }
        }
    }
}
