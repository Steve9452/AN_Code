using System;

namespace Metodo_PuntoFijo
{
    class Program
    {
        static void Main(string[] args)
        {
            //x = g(x)   !!!!
            //Func<double, double> f1 = x => Math.Sqrt(x + 1) ; PuntoFijo(f1,0,10e-15,1000);

            //Func<double, double> feje = x => Math.Sqrt((10/x) - 4 * x); PuntoFijo(feje,2.71458,10e-15,100);

            
            Func<double, double> conv = x => (1.0/2.0) * Math.Sqrt(10 - Math.Pow(x,3)); PuntoFijo(conv,0,10e-10,100);
            //Func<double,double> f2 = x => (Math.Sqrt(- Math.Pow(x,3) + 10)) / 2; PuntoFijo(f2,1.5,10e-10,1000);
            
            //Funciones equivalente pero esta no converge OJO
            //Func<double, double> g = x => x*x - 1 ; PuntoFijo(g,-0.5,10e-15,100);
            //Console.WriteLine(g(-0.5));







        }


        static void PuntoFijo(Func<double,double> g, double p0, double TOL , double Nmax)//Requiere un valor inicial0
        {
            double p = 0;
            for (int i = 0; i < Nmax; i++)
            {
                p = g(p0);
                Console.WriteLine($"{i}\t{p0}\t{p}\t{Math.Abs(p0 - p)}"); //Respuesta ultima iteracion p
                if (Math.Abs(p - p0) < TOL)
                    break;
                p0 = p;
            }
        }
    }
}
