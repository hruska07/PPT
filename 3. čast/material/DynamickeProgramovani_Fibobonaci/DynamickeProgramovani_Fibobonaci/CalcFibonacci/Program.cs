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
            Fibonacci fib = new Fibonacci();
            Console.Write("Zadejte pocet prvku: ");
            n= Convert.ToInt32( Console.ReadLine());

            Console.Write(fib.CalcRek(Convert.ToInt32(n)).ToString());
            Console.Write(fib.CalcNerek(Convert.ToInt32(n)).ToString());
            Console.Write("Zadejte pocet prvku: ");
            n = Convert.ToInt32(Console.ReadLine());
        }
    }
}
