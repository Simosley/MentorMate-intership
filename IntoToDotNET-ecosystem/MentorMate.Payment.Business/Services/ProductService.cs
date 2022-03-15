using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using MentorMate.Payments.Business.Models;

namespace MentorMate.Payments.Business.Services
{
    public class ProductService : IProductService
    {

        IList<Product> IProductService.GetProducts()
        {
            string FileName = Path.Combine(Environment.CurrentDirectory, @"../../../../MentorMate.Payment.Business/Services/sample.json");
           
            string JsonString = File.ReadAllText(FileName);
            IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(JsonString);
         
            return products;

        }
    }
}
