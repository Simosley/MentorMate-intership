using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class StartCar
    {
        public string operationEnable()
        {
            return "Enable the airflow sensor\n";
        }
        public string operationStartPump()
        {
            return "Start the fuel pump\n";
        }

        public string operationEnableEngineStarter()
        {
            return "Enable the engine starter\n";
        }
        public string operationStartCoolingPump()
        {
            return "Start cooling pump\n";
        }
    }
}
