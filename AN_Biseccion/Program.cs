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
           


            Func<double,double> funcion = x => 10 * ((Math.PI / 2) - Math.Asin(x) - x * Math.Sqrt(1 - Math.Pow(x,2))) - 12.4;
            Func<double,double> FNV2 = x => 10 * ((Math.PI/2) - Math.Asin(x) - (x * Math.Sqrt(1 - Math.Pow(x,2) ) ) ) - 12.4;

            Func<double, double> youtube = x => Math.Pow(Math.E, 3 * x) - 4; //Bisection2(youtube, 0, 1, 0.01);

            Func<double, double> ejer1 = x => x - Math.Tan(x);// Bisection2(ejer1,1,2, Math.Pow(10,-15));

            Func<double, double> ejer2 = x => Math.Pow(x,3) + (4* Math.Pow(x,4))- 10; Bisection2(ejer2,1,2,Math.Pow(10,-3));

            
        }
        //Necesita un valor de limite de iteraciones especifico
        public static void Bisection(Func<double , double> f, double a, double b, double TOL, int Nmax)
                {
                    double p = 0;
                    for (int i = 0 ; i < Nmax ; i++) 
                    {
                        p = (a + b) /2; // Punto medio
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
                p = (a + b) / 2; //punto medio 
                Console.WriteLine($"{i}\t{p}\t{f(p)}\t{(b - a) / 2}");
                if (f(a) * f(p) < 0) //Comprueba el signo si los dos son iguales, o tienen signo diferente
                    b = p; //si tienen signo diferente entra
                else
                    a = p; // si tienen signos iguales 
            }
            //Console.WriteLine($"Error final: {(b - a) / 2}");
            
        }
    }
    
}
