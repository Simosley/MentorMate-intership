using System;

namespace DecoratorPattern
{
    public class Client
    {
        public void ClientCode(Company component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

}