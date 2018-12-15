using System;
using System.Collections;

namespace CalcFibonacci
{
    class Fibonacci
    {
        public ArrayList DataFibona { get; private set; }
        public int CalcRek(int n)
        {
            /*if ( n==1||n == 2)
                return 1;
            else
                return CalcRek(n - 2) + CalcRek(n - 1);*/
            return n == 1 || n == 2 ? 1 : CalcRek(n - 2) + CalcRek(n - 1);
            // return n == 0 ? 0 : n == 1 ? 1 : CalcRek(n - 1) + CalcRek(n - 2);
        }
        public Fibonacci()
        {
            DataFibona = new ArrayList();
        }

        public int CalcRekTable(int n)
        {
            throw new NotImplementedException();
        }

        public int CalcNerek(int n)
        {
            int a =1;
            int b = 1;
            int c = 0;
            for (int i = 3; i <= n; i++)
            {
                c = a;
                a = b+a;
                b = c;
            }
            return a;
        }
    }
}
