using System;

class WyznacznikMacierzy
{
    public static void Run()
    {
        Console.Write("Podaj rozmiar macierzy kwadratowej (n x n): ");
        int n = int.Parse(Console.ReadLine());

        double[,] macierz = new double[n, n];

        Console.WriteLine("Wprowadź elementy macierzy: ");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"A[{i+1},{j+1}] = ");
                macierz[i, j] = double.Parse(Console.ReadLine());
            }
        }

        double wynik = WyznacznikMacierz(macierz);
        Console.WriteLine($"Wyznacznik macierzy: {wynik}");
    }

    static double WyznacznikMacierz(double[,] macierz)
    {
        int n = macierz.GetLength(0);
        if (n == 1)
            return macierz[0, 0];
        if (n==2)
        {
            return macierz[0, 0] * macierz[1, 1] - macierz[0, 1] * macierz[1, 0];
        }
        double wynik = 0;

        for (int k = 0; k < n; k++)
        {
            double[,] macierz2 = TworzenieMacierzy2(macierz, 0, k);
            wynik += Math.Pow(-1, k) * macierz[0, k] * WyznacznikMacierz(macierz2);
        }

        return wynik;
    }

    static double[,] TworzenieMacierzy2(double[,] macierz, int wierszDoPominiecia, int kolumnaDoPominiecia)
    {
        int n = macierz.GetLength(0);
        double[,] podmacierz = new double[n - 1, n - 1];

        int w = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == wierszDoPominiecia) continue;
            int k = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == kolumnaDoPominiecia) continue;
                podmacierz[w, k] = macierz[i, j];
                k++;
            }
            w++;
        }

        return podmacierz;
    }
}