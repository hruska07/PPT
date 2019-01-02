using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcFibonacci;
using System.Diagnostics;

namespace CalcFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Zadejte pocet prvku: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 0);
            Fibonacci fib = new Fibonacci();
            Stopwatch watch = new Stopwatch();
            int vysl1, vysl2, vysl3;
            int sloz1 = 0;
            int sloz2 = 0;
            int sloz3 = 0;
            int count_rekurze1 = 0;
            int count_rekurze3 = 0;

            TimeSpan time1, time2, time3;
            watch.Start();
            vysl1 = fib.CalcRek(Convert.ToInt32(n), ref sloz1, ref count_rekurze1);
            watch.Stop();
            time1 = watch.Elapsed;

            watch.Restart();
            vysl2 = fib.CalcNerek(Convert.ToInt32(n), ref sloz2);
            watch.Stop();
            time2 = watch.Elapsed;

            watch.Restart();
            vysl3 = fib.CalcRekTable(Convert.ToInt32(n), ref sloz3, ref count_rekurze3);
            watch.Stop();
            time3 = watch.Elapsed;

            Console.Write("FIBONACCI - REKURZIVNE (bez tabulky):\n");
            Console.Write(String.Format("Vysledek: {0}; Slozitost: {1}; Cas: {2}; Pocet rekurzi: {3}\n\n", vysl1, sloz1, time1, count_rekurze1));
            Console.Write("FIBONACCI - NEREKURZIVNE:\n");
            Console.Write(String.Format("Vysledek: {0}; Slozitost: {1}; Cas: {2}\n\n", vysl2, sloz2, time2));
            Console.Write("FIBONACCI - REKURZIVNE (s tabulkou):\n");
            Console.Write(String.Format("Vysledek: {0}; Slozitost: {1}; Cas: {2}; Pocet rekurzi: {3}\n\n", vysl3, sloz3, time3, count_rekurze3));
            Console.Write("PRO UKONCENI STISKNETE ENTER");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
        }
    }
}
