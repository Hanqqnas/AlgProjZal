using System;
using System.Globalization;
using NCalc;

class MetodaBisekcji
{
    public static void Run()
    {
        Console.WriteLine("METODA BISEKCJI");
        Console.WriteLine("Wpisz funkcję: ");
        Console.Write("f(x) = ");
        string funkcja = Console.ReadLine();

        Expression expr = new Expression(funkcja);
        
        Console.Write("Podaj początek przedziału: ");
        double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Podaj koniec przedziału: ");
        double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Podaj epsilon: ");
        double epsilon = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double F(double x)
        {
            expr.Parameters["x"] = x;
            return Convert.ToDouble(expr.Evaluate());
        }

        if (F(a) * F(b) >= 0)
        {
            Console.WriteLine("Błąd! f(a) i f(b) muszą mieć przeciwne znaki.");
            return;
        }

        double c = a;
        while ((b - a) >= epsilon)
        {
            c = (a + b) / 2;
            if(Math.Abs(F(c))<=epsilon)
                break;
            if (F(a) * F(c) < 0)
                b = c;
            else
                a = c;
        }

        Console.WriteLine("Przybliżony pierwiastek: ");
        Console.WriteLine($"f({c:F6}) = {F(c):F6}");
    }
}