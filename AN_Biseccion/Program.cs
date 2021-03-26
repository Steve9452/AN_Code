using System;

namespace AN_Biseccion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metodo de biseccion: ");
            Func<double, double> f1 = x => Math.Cos(x) - x;
            Func<double, double> f2 = x => -0.4 + 1.74 * Math.Log( Math.Pow(10,4) * Math.Sqrt(x)) - Math.Sqrt(1/x); 
            Func<double,double,double> pow = (n1 , n2) => Math.Pow(n1, n2);

            //Bisection(f1, 0, 1, pow(10,-6), 100000);
            //Bisection2(f1,0,1,pow(10,-6));
            Bisection2(f2, 0.005, 0.01, pow(10,-20));
            Bisection2(f1,0,1,pow(10,-6));
            //Bisection(f2, 0.005, 0.01, Math.Pow(10,-20),);
        }
        //Necesita un valor de limite de iteraciones especifico
        public static void Bisection(Func<double , double> f, double a, double b, double TOL, int Nmax)
                {
                    double p = 0;
                    for (int i = 0 ; i < Nmax ; i++) 
                    {
                        p = (a + b) /2;
                        Console.WriteLine($"{i}\t{p}\t{f(p)}");
                        if ( f(p) == 0 || (b - a) / 2 < TOL)
                            break;
                        else if (f(a) * f(p) < 0)
                            b = p;
                        else
                            a = p;
                    }
                }
        //No requiere un Nmax especifico
        public static void Bisection2(Func<double , double> f, double a, double b, double TOL)
        {   

            double p = 0;
            // Math.Ceiling aproxima al valor inmediatamente superior de un decimal. si es un entero exacto deja ese
            double Nmax = Math.Ceiling( Math.Log((b - a) / TOL, 2));             
            for (int i = 0 ; i < Nmax ; i++) 
            {
                p = (a + b) / 2;
                Console.WriteLine($"{i}\t{p}\t{f(p)}");
                if (f(a) * f(p) < 0)
                    b = p;
                else
                    a = p;
            }
            
        }
    }
    
}
