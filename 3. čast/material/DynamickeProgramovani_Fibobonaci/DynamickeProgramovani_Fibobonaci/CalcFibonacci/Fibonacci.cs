using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcFibonacci
{
    class Fibonacci
    {
        public int CalcRek(int n)
        { /*
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            else
                return CalcRek(n - 1) + CalcRek(n - 2);
            */
            return n == 0 ? 0 : n == 1 ? 1 : CalcRek(n - 1) + CalcRek(n - 2);
        }

        public int CalcRekTable(int n)
        {
            throw new NotImplementedException();
        }

        public int CalcNerek(int n)
        {
            throw new NotImplementedException();
        }
    }
}
