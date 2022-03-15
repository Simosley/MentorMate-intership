using System.Net;
using System.Diagnostics;

namespace HandligAsync;
class Program
{
    public const string Victim_Url = "https://localhost:44321/homework/victim";
    public const string Torture_Url = "https://localhost:44321/homework/torture";

    static async Task Main(string[] args)
    {
        bool found = true;
        var watch = Stopwatch.StartNew();
        using var client =  new HttpClient();
        while (found)
        {
            var victim =  client.GetStringAsync(Victim_Url);
            var torture =  client.GetStringAsync(Torture_Url);
            await Task.WhenAll(victim, torture);
                if (victim.Result == "Simeon Tsolov" && torture.Result == ".NET")
                {
                    Console.WriteLine("my name and my torture :D {0} {1}", victim.Result,torture.Result);
                    found = false;
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("time in ms " +  elapsedMs);
                    break;
                }
                else
                {
                    Console.WriteLine(victim.Result+" "+torture.Result);
                    Console.WriteLine("time in ms " + watch.ElapsedMilliseconds);
                }         
            //in .NET 4.0 added a new feature of Parallel Programming.It can be done using Task Parallel Library (TPL).
            //This library is available from the namespace System.Threading.Tasks.
            //i think it can be used here,in the for loop cycle which can reduce the time(not so much), not sure for doing it in the foreach loop while doing the reqeusts
            //I think it will be a good use if we do a lot of stuff in the for loop where we can get faster times 
        }
    }
}