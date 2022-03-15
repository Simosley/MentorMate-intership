using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Customer1 : IObserver
    {
        public void Update(ISubject bank)
        {
            if ((bank as Bank).State < 3)
            {
                Console.WriteLine("Customer1: Reacted to the event.");
            }
        }
    }
}
