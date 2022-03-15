using Observer;
class Program
{
    static void Main(string[] args)
    {
        var bank = new Bank();
        var customer1 = new Customer1();
        bank.Attach(customer1);

        var customer2 = new Customer2();
        bank.Attach(customer2);

        bank.TaxChange();
        bank.TaxChange();

        bank.Detach(customer2);

        bank.TaxChange();
    }
}
