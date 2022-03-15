using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class ConcreteCreator1 : Company
    {
        public override IProduct FactoryMethod()
        {
            return new DeliveryShips();
        }
    }
}
