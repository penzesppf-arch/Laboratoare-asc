using System;

namespace Automat_de_vanzari
{
    enum Stare
    {
        A_0_Centi,
        B_5_Centi,
        C_10_Centi,
        D_15_Centi
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stare stareCurenta = Stare.A_0_Centi;
            Console.WriteLine("=== SIMULATOR AUTOMAT VENDING ===");
            Console.WriteLine("Pret produs: 20 centi");
            Console.WriteLine("Monede acceptate: N ( Nickel - 5 centi), D ( Dime - 10 centi) , Q (Quarter - 25 centi)");
            Console.WriteLine("Apasati 'X' pentru  iesi.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n[Stare curenta]: {stareCurenta} Ai introdus {GetValoareStare(stareCurenta)} centi");
                Console.ResetColor();
                Console.WriteLine("Introduceti moneda(N / D / Q): ");
                string input = Console.ReadLine()?.ToUpper();
                if (input == "X")
                {
                    Console.WriteLine("Iesire din simulator. La revedere!");
                    break;
                }
                switch (stareCurenta)
                {
                    case Stare.A_0_Centi:
                        if (input == "N")
                        {
                            stareCurenta = Stare.B_5_Centi;
                            AfiseazaIesirea("000", "Nimic", "Nu", "Nu");
                        }
                        else if (input == "D")
                        {
                            stareCurenta = Stare.C_10_Centi;
                            AfiseazaIesirea("000", "Nimic", "Nu", "Nu");
                        }
                        else if (input == "Q")
                        {
                            stareCurenta = Stare.A_0_Centi;
                            AfiseazaIesirea("110", "DA", "DA (Nickel)", "Nu");
                        }
                        else EroareMoneda();
                        break;


                    case Stare.B_5_Centi:
                        if (input == "N")
                        {
                            stareCurenta = Stare.C_10_Centi;
                            AfiseazaIesirea("000", "Nimic", "Nu", "Nu");
                        }
                        else if (input == "D")
                        {
                            stareCurenta = Stare.D_15_Centi;
                            AfiseazaIesirea("000", "Nimic", "Nu", "Nu");
                        }
                        else if (input == "Q")
                        {
                            stareCurenta = Stare.A_0_Centi;
                            AfiseazaIesirea("101", "DA", "Nu", "DA (Dime)");
                        }
                        else EroareMoneda();
                        break;

                    case Stare.C_10_Centi:
                        if (input == "N")
                        {
                            stareCurenta = Stare.D_15_Centi;
                            AfiseazaIesirea("000", "Nimic", "Nu", "Nu");
                        }
                        else if (input == "D")
                        {
                            stareCurenta = Stare.A_0_Centi;
                            AfiseazaIesirea("100", "DA", "Nu", "Nu");
                        }
                        else if (input == "Q")
                        {
                            stareCurenta = Stare.A_0_Centi;
                            AfiseazaIesirea("111", "DA", "DA (Nickel)", "DA (Dime)");
                        }
                        else EroareMoneda();
                        break;

                    case Stare.D_15_Centi:
                        if (input == "N")
                        {
                            stareCurenta = Stare.A_0_Centi;
                            AfiseazaIesirea("100", "DA", "Nu", "Nu");
                        }
                        else if (input == "D")
                        {
                            stareCurenta = Stare.A_0_Centi;
                            AfiseazaIesirea("110", "DA", "DA (Nickel)", "Nu");
                        }
                        else if (input == "Q")
                        {
                            Console.WriteLine(">>EROARE: Moneda returnata.Nu se accepta Quarter in aceasta stare.");
                        }
                        else EroareMoneda();
                        break;

                }
            }
        }
        static void AfiseazaIesirea(string codBinar, string produs, string restNickel, string restDime)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n --- TRANZATIE REUSITA (Output {codBinar}) ---");
            Console.WriteLine($"1. Eliberare produs: {produs}");
            Console.WriteLine($"2. Rest Nickel (5c): {restNickel}");
            Console.WriteLine($"3. Rest Dime (10c): {restDime}");
            Console.ResetColor();
        }
        static int GetValoareStare(Stare s)
        {
            switch (s)
            {
                case Stare.A_0_Centi: return 0;
                case Stare.B_5_Centi: return 5;
                case Stare.C_10_Centi: return 10;
                case Stare.D_15_Centi: return 15;
                default: return 0;
            }
        }
        static void EroareMoneda()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">>EROARE: Moneda introdusa nu este acceptata. Incercati din nou.");
            Console.ResetColor();
        }
    }
}
