using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class HugeDiscount : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as Dictionary<string, int>;
            foreach ((var Key, var Value) in list as Dictionary<string, int>)
            {
                Console.WriteLine($"{Key} - {Value * 2}%");
            }
            return list;
        }
    }
}
