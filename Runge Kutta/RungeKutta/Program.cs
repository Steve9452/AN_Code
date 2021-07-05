using System;

namespace RungeKutta
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double,double,double> fdev = (x,y) => 2*x*y;
            Runge4(1.0,1.0,2.0,0.1,fdev);
        }






        static void Runge4(double x0, double y0,double xf, double h, Func<double,double,double> f1)
        {
            int  n = Convert.ToInt32((xf - x0)/h);
            Func<double,double,double> k1 = (x,y) => h * f1(x,y);
            Func<double,double,double> k2 = (x,y) => h * f1(x+h/2, y+ k1(x,y)/2);
            Func<double,double,double> k3 = (x,y) => h * f1(x+h/2, y+ k2(x,y)/2);
            Func<double,double,double> k4 = (x,y) => h * f1(x+h, y + k3(x,y));

            Func<double, double, double> yn = (x,y) => y + (k1(x,y) + 2 * k2(x,y) + 2 * k3(x,y) + k4(x,y))/6;

            double yna = yn(x0 ,y0);
            System.Console.WriteLine($"n {x0}\tyn {y0}\tk1 {k1(x0,y0)}\tk2 {k2(x0,y0)}\tk3 {k3(x0,y0)}\tk4 {k4(x0,y0)}");
            double x = x0;
            for (int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"n {Math.Round(x + h,2)}\tyn {yna}\tk1 {k1(Math.Round(x + h,2),yna)} \tk2 {k2(Math.Round(x + h,2),yna)} \tk3 {k3(Math.Round(x + h,2),yna)} \tk4 {k4(Math.Round(x + h,2),yna)}");
                x = x0 + i * h;
                yna= yn(x,yna);
            }
        }
    }
}
