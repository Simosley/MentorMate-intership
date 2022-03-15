using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class BaseSalary : Company
    {
        public override string Operation()
        {
            return "BaseSalary";
        }
    }
}
