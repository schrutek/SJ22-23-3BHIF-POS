using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerSearch.DomainModel.Application
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public decimal Divide(int a, int b)
        {
            if (b <= 0) return 0M;
            return (decimal)a / b;
        }
    }
}
