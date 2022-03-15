using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Adapter : ISpeedConvert
    {
        private readonly Speed _speed;

        public Adapter(Speed speed)
        {
            _speed = speed;
        }
        public string GetSpeedMph()
        {
            return $"Current speed {_speed.GetSpeed()} mp/h";
        }
        public string GetSpeedKmh()
        {
            return $"Current speed {_speed.GetSpeed() * 1.609m} km/h";
        }
    }
}
