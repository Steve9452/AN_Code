using System;

namespace Steffensen
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ejercicio parcial
            Func<double, double> g2 = x => 2.18902 * Math.Pow( Math.Pow(x,1.41844) - 32.6757,0.585062); Steffensen(g2,70,10e-5,1000);
            
        }
        public static void Steffensen(Func<double, double> g, double p0, double TOL ,int Nmax)
        {
             Func<double, double, double, double> p_hat = (p0,p1,p2) => p0 - Math.Pow(p1 - p0, 2) / (p2 - 2.0 * p1 + p0);

             double p = 0 , p1 = 0 , p2 = 0;
             
             for (int i = 0; i < Nmax; i++)
             {
                 p1 = g(p0);
                 p2 = g(p1);
                 p = p_hat(p0, p1, p2);

                 Console.WriteLine($"{i}\t{p0}\t{p1}\t{p2}\t{p}\t{Math.Abs(p0 - p)}\n"); // p o p_gorro respuesta 

                 if(Math.Abs(p0 - p) < TOL) 
                    break;

                p0 = p;
             }
        }
    }
}
