using System;
using System.Collections.Generic;

class SitoEratostenesa
{
    public static void Run()
    {
        Console.Write("Podaj liczbę całkowitą większą niż 1: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 1)
        {
            List<int> liczbyPierwsze = SitoEratostenes(n);
            Console.WriteLine("Liczby pierwsze od 2 do " + n + ":");
            Console.WriteLine(string.Join(", ", liczbyPierwsze));
        }
        else
        {
            Console.WriteLine("Błąd: wpisz poprawną liczbę całkowitą większą niż 1.");
        }
    }

    static List<int> SitoEratostenes(int n)
    {
        bool[] czyPierwsza = new bool[n + 1];
        for (int i = 2; i <= n; i++)
            czyPierwsza[i] = true;

        for (int i = 2; i * i <= n; i++)
        {
            if (czyPierwsza[i])
            {
                for (int j = i * i; j <= n; j += i)
                    czyPierwsza[j] = false;
            }
        }

        List<int> liczbyPierwsze = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            if (czyPierwsza[i])
                liczbyPierwsze.Add(i);
        }

        return liczbyPierwsze;
    }
}