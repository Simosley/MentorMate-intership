using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class BonusSalary : Company
    {
        public override IProduct FactoryMethod()
        {
            return new DeliveryPlanes();
        }
    }
}
