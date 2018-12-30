using System;
using System.Collections;

namespace CalcFibonacci
{
    class Fibonacci
    {
     //   public int[] DataFibona { get; private set; }
        public int CalcRek(int n)
        {
            /*if ( n==1||n == 2)
                return 1;
            else
                return CalcRek(n - 2) + CalcRek(n - 1);*/
            return n == 1 || n == 2 ? 1 : CalcRek(n - 2) + CalcRek(n - 1);
        }
        public Fibonacci(){}
        /*
        public Fibonacci(int n)
        {
            int[] DataFibona = new int[n + 1];
            for (int i = 0; i < n; i++)
                DataFibona[i] = -1;
        }*/

        public int CalcRekTable(int n)
        {
            if (n <= 1)
                return n;
            int[] fib = new int[n + 1];//tvorba pomocneho pole
            return CalcRekTable(fib, n);
        }

        private int CalcRekTable(int[] fib, int n)
        {
            // jestli je spocitany nebo n mensi nebo rovno 1tak to vraci hodnotu 
            if (n <= 1)
                return n;
            if (fib[n] > 0)
                return fib[n];
            //pocitani a vracení nevyplnenych hodnot
            return fib[n] = CalcRekTable(fib, n - 1) + CalcRekTable(fib, n - 2);
        }

        public int CalcNerek(int n)
        {
            int a = 1;
            int b = 1;
            int c;
            for (int i = 3; i <= n; i++)
            {
                c = a;
                a = b + a;
                b = c;
            }
            return a;
        }
    }
}
