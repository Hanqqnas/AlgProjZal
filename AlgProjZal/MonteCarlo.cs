using System;
using System.Net;
using System.Globalization;
using NCalc;

class MonteCarlo
{
    public static void Run()
    {
        Console.WriteLine("Podaj f(x): ");
        string functionInput = Console.ReadLine();
        Console.Write("Podaj dolną granicę całki: ");
        double a = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        Console.Write("Podaj górną granicę całki: ");
        double b = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        Console.Write("Podaj maksymalną wartość funkcji f(x): ");
        double maxY = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
        Console.Write("Podaj dokładność epsilon: ");
        double epsilon = double.Parse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);

        Expression expression = new Expression(functionInput);
        Random random = new Random();
        int L = 0, L1 = 0;
        double previousIntegral = 0, currentIntegral = 0;
        double area = (b - a) * maxY;

        while (true)
        {
            L++;
            double x = a + (b - a) * random.NextDouble();
            double y = maxY * random.NextDouble();
            expression.Parameters["x"] = x;
            double fx = Convert.ToDouble(expression.Evaluate());

            if (y <= fx)
                L1++;
            if (L % 10000 == 0)
            {
                currentIntegral = area * L1 / L;
                if (Math.Abs(currentIntegral - previousIntegral) < epsilon)
                    break;
                previousIntegral = currentIntegral;
            }
        }

        Console.WriteLine($"Całka z f(x) w przedziale od {a} do {b} = {currentIntegral:F6}");
        Console.WriteLine($"Liczba wylosowanych punktów: {L}");
    }
}