using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {           
            StartCar startCar = new StartCar();
            StopCar stopCar = new StopCar();
            Car car = new Car(startCar, stopCar);
            Client.ClientCode(car);
        }
    }
}