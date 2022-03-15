using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class BonusSalary : Decorator
    {
        public BonusSalary(Company comp) : base(comp)
        {
        }
        public override string Operation()
        {
            return $"(Salary Bonus({base.Operation()}))";
        }
    }
}
