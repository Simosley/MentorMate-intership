using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Observer
{
    public class Bank : ISubject
    {
        public int State { get; set; } = -0;
        private List<IObserver> clients = new List<IObserver>();
        public void Attach(IObserver client)
        {
            Console.WriteLine("Bank: Attached an client.");
            this.clients.Add(client);
        }
        public void Detach(IObserver client)
        {
            this.clients.Remove(client);
            Console.WriteLine("Bank: Detached an client.");
        }
        public void Notify()
        {
            Console.WriteLine("Bank: Notifying clients...");
            foreach (var client in clients)
            {
                client.Update(this);
            }

        }
            public void TaxChange()
            {
                Console.WriteLine("\nBank: INCOMING TAX CHANGES");
                this.State = new Random().Next(0, 10);

                Thread.Sleep(15);

                Console.WriteLine("Subject: My state has just changed to: " + this.State);
                this.Notify();
            }
        
    }
}