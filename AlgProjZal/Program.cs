using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU ALGORYTMÓW");
            Console.WriteLine("1. Sito Eratostenesa");
            Console.WriteLine("2. Wyznacznik macierzy");
            Console.WriteLine("3. Metoda Bisekcji");
            Console.WriteLine("4. Monte Carlo");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    SitoEratostenesa.Run();
                    break;
                case "2":
                    WyznacznikMacierzy.Run();
                    break;
                case "3":
                    MetodaBisekcji.Run();
                    break;
                case "4":
                    MonteCarlo.Run();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić do menu...");
            Console.ReadKey();
        }
    }
}