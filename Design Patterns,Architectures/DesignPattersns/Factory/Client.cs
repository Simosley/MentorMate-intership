using Factory;
using System;

namespace RefactoringGuru.DesignPatterns.FactoryMethod.Conceptual
{
    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: delivery works with ships.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: delivery works with planes.");
            ClientCode(new BonusSalary());
        }

        public void ClientCode(Company company)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + company.SomeOperation());
        }
    }
    
}