using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Customer2 : IObserver
    {
        public void Update(ISubject bank)
        {
            if ((bank as Bank).State == 0 || (bank as Bank).State >= 2)
            {
                Console.WriteLine("Customer2: Reacted to the event.");
            }
        }
    }
}
