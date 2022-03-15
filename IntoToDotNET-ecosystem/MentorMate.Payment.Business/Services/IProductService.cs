using MentorMate.Payments.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorMate.Payments.Business.Services
{
    public interface IProductService
    {
        public IList<Product> GetProducts();
    }
}
