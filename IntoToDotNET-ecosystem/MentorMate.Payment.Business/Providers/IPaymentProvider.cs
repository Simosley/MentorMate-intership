using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorMate.Payments.Business.Models;

namespace MentorMate.Payments.Business.Providers
{
    public interface IPaymentProvider 
    {
        public bool ProcessPayment ( Payment Payment );
    }
}

