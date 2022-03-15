using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Car
    {
        protected StartCar start;

        protected StopCar stop;

        public Car(StartCar start, StopCar stop)
        {
            this.start = start;
            this.stop = stop;
        }
        public string Operation()
        {
            string result = "";
            result += this.start.operationEnable();
            result += this.start.operationStartPump();
            result += this.start.operationEnableEngineStarter();
            result += this.start.operationStartCoolingPump();

            result += this.stop.operationStopFuelPump();
            result += this.stop.operationStopCoolingPump();
            result += this.stop.operationDisableAirflowSensor();
            return result;
        }
    }
}
