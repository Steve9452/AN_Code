using System;

namespace aitken
{
    class Program
    {
        
        static void Main(string[] args)
        {   
            //Parcial01

            Func<double,double> g = x => 0.389045 * Math.Pow(( Math.Pow(x,1.70922) + 124.667) , 0.705); aitken(g, 20 ,10e-6,1000);
            
            
            //Console.WriteLine(g(0.3));
        }
        public static void aitken(Func<double, double> g, double p0, double TOL, int Nmax )
        {
            Func<double, double, double,double> p_hat = (p0,p1,p2) => p0 - Math.Pow(p1 - p0,2.0) / (p2 - 2.0 * p1 + p0);
            double p0_hat = 0;
            double p1_hat = 0;
            double p1 = 0 , p2 = 0;

            for (int i = 0; i < Nmax; i++)
            {
                p1 = g(p0);
                p2 = g(p1);

                p1_hat = p_hat(p0,p1,p2);
                if( i == 0) Console.WriteLine($"{i}\t{p0}\t{p1}\t{p2}\t{p1_hat}");
                else Console.WriteLine($"{i}\t{p0}\t{p1}\t{p2}\t{p1_hat}\t{Math.Abs(p1_hat - p0_hat)}");

                if(Math.Abs(p0_hat - p1_hat) < TOL)
                    break;
                
                p0 = p1;
                p0_hat = p1_hat;
            }
        }
    }
}
