using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcFibonacci;

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
            Console.Write(fib.CalcRek(Convert.ToInt32(n)).ToString()+"\n");
            Console.Write(fib.CalcNerek(Convert.ToInt32(n)).ToString() + "\n");
            Console.Write(fib.CalcRekTable(Convert.ToInt32(n)).ToString() + "\n");
            Console.Write("PRO UKONCENI STISKNETE ENTER");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
        }
    }
}
