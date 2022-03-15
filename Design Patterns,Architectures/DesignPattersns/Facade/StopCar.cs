using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class StopCar
    {
        public string operationStopFuelPump()
        {
            return "Stop the fuel pump\n";
        }
        public string operationStopCoolingPump()
        {
            return "Stop cooling pump\n";
        }
        public string operationDisableAirflowSensor()
        {
            return "Disable the airflow sensor\n";
        }
    }
}
