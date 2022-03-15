using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class DeliveryShips : IProduct
    {
        public string Operation()
        {
            return "ships";
        }
    }
}
