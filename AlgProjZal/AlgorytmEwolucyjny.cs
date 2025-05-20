using System;
using System.Collections.Generic;
using System.Linq;

class AlgorytmEwolucyjny
{
    static Random rnd = new Random();

    static double Function(double x, double y)
    {
        return Math.Sin(x) + Math.Sin(2 * x) + Math.Sin(4 * x) + Math.Sin(x) +
               Math.Cos(y) + Math.Cos(2 * y) + Math.Cos(4 * y) + Math.Cos(y);
    }

    public static void Run()
    {
        Console.Write("Liczba osobników w populacji: ");
        int populationSize = int.Parse(Console.ReadLine());

        Console.Write("Liczba pokoleń: ");
        int generations = int.Parse(Console.ReadLine());

        Console.Write("Prawdopodobieństwo mutacji (np. 0.1): ");
        double mutationRate = double.Parse(Console.ReadLine());

        double min = 0;
        double max = 2 * Math.PI;

        List<(double x, double y)> population = new();

        for (int i = 0; i < populationSize; i++)
        {
            population.Add((RandomDouble(min, max), RandomDouble(min, max)));
        }

        for (int gen = 0; gen < generations; gen++)
        {
            var evaluated = population
                .Select(ind => (ind, score: Function(ind.x, ind.y)))
                .OrderByDescending(e => e.score)
                .ToList();

            int survivors = populationSize / 2;
            var parents = evaluated.Take(survivors).Select(e => e.ind).ToList();

            List<(double x, double y)> newPopulation = new();

            while (newPopulation.Count < populationSize)
            {
                var p1 = parents[rnd.Next(parents.Count)];
                var p2 = parents[rnd.Next(parents.Count)];

                double x = (p1.x + p2.x) / 2;
                double y = (p1.y + p2.y) / 2;

                x = Mutate(x, mutationRate, min, max);
                y = Mutate(y, mutationRate, min, max);

                newPopulation.Add((x, y));
            }

            population = newPopulation;

            var best = evaluated.First();
            Console.WriteLine($"Pokolenie {gen + 1}: f({best.ind.x:F3}, {best.ind.y:F3}) = {best.score:F4}");
        }
    }

    static double RandomDouble(double min, double max)
        => min + rnd.NextDouble() * (max - min);

    static double Mutate(double value, double rate, double min, double max)
    {
        if (rnd.NextDouble() < rate)
        {
            double mutation = rnd.NextDouble() * 0.02 - 0.01; 
            value += mutation;
        }
        return Math.Clamp(value, min, max);
    }
}
