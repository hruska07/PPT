using System;
using System.Collections;

namespace CalcFibonacci
{
    class Fibonacci
    {
        //public int[] DataFibona { get; private set; }

        public int CalcRek(int n, ref int count, ref int count_rekurze)
        {
            count += 3;
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                count += 3;
                count_rekurze += 2;
                return CalcRek(n - 2, ref count, ref count_rekurze) + CalcRek(n - 1, ref count, ref count_rekurze);
            }

            //return n == 1 || n == 2 ? 1 : CalcRek(n - 2) + CalcRek(n - 1);
        }
        public Fibonacci(){}
        /*
        public Fibonacci(int n)
        {
            int[] DataFibona = new int[n + 1];
            for (int i = 0; i < n; i++)
                DataFibona[i] = -1;
        }*/

        public int CalcRekTable(int n, ref int count, ref int count_rekurze)
        {
            count += 1;
            if (n <= 1)
                return n;
            count += 2;
            int[] fib = new int[n + 1];//tvorba pomocneho pole
            return CalcRekTable(fib, n, ref count, ref count_rekurze);
        }

        private int CalcRekTable(int[] fib, int n, ref int count, ref int count_rekurze)
        {
            // jestli je spocitany nebo n mensi nebo rovno 1tak to vraci hodnotu 
            count += 1;
            if (n <= 1)
                return n;
            count += 2;
            if (fib[n] > 0)
            {
                count += 1;
                return fib[n];
            }
            
            count += 6;
            count_rekurze += 2;
            //pocitani a vracení nevyplnenych hodnot
            return fib[n] = CalcRekTable(fib, n - 1, ref count, ref count_rekurze) + CalcRekTable(fib, n - 2, ref count, ref count_rekurze);
        }

        public int CalcNerek(int n, ref int count)
        {
            int a = 1;
            int b = 1;
            int c;
            count += 2 + 2;
            for (int i = 3; i <= n; i++)
            {
                c = a;
                a = b + a;
                b = c;
                count += 4 + 3;
            }
            return a;
        }
    }
}
