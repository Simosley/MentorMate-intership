using MentorMate.Payments.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MentorMate.Payments.Business.Providers
{
    public class PayPalPaymentProvider : IPaymentProvider
    {
        bool IPaymentProvider.ProcessPayment(Payment Payment)
        {
            Console.WriteLine("You chose Paypal, the amount paid is {0} ,and the reason  is {1}", Payment.Amount, Payment.Description);
            
            return true;
        }
    }
}
