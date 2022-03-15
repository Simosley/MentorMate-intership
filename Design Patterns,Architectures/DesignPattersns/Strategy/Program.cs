using Strategy;
class ProgramStra
{
    static void Main(string[] args)
    {
        var context = new Context();

        Console.WriteLine("Strategy is the normal values");
        context.SetStrategy(new NormalDiscount());
        context.GetDiscount();

        Console.WriteLine();

        Console.WriteLine("Strategy is normal values * 2.");
        context.SetStrategy(new HugeDiscount());
        context.GetDiscount();
    }
}
