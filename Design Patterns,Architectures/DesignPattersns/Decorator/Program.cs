namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            var simple = new BaseSalary();
            client.ClientCode(simple);
            BonusSalary decorator1 = new BonusSalary(simple);
            client.ClientCode(decorator1);

        }
    }
}