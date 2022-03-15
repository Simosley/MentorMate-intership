using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Speed speed = new Speed();
            ISpeedConvert speedConvert = new Adapter(speed);

            Console.WriteLine("Adaptee interface is incompatible with the client need for speed to be in km/h");
            Console.WriteLine(speedConvert.GetSpeedMph());
            Console.WriteLine("But with adapter client can call it's method.");
            Console.WriteLine(speedConvert.GetSpeedKmh());
        }
    }
}
