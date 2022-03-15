using System;
using MentorMate.Payments.Business;
using MentorMate.Payments.Business.Services;
using MentorMate.Payments.Business.Providers;
using MentorMate.Payments.Business.Models;

//get products
IProductService Service = new ProductService();
var products = Service.GetProducts();
Console.WriteLine("LIST OF ALL PRODUCTS:");

foreach (Product product in products)
{
    Console.WriteLine("ID: {0} | Name: {1} | Description: {2} |  Price: {3}", product.Id, product.Name, product.Description, product.Price);
    
}
Console.WriteLine("*********************");





#region Payment
IPaymentProvider PayPal = new PayPalPaymentProvider();
IPaymentProvider Stripe = new StripePaymentProvider();
var payMethods = new List<IPaymentProvider>();
payMethods.Add(PayPal);
payMethods.Add(Stripe);

Console.Write("Choose product by the ID: ");
int ChooseId = int.Parse(Console.ReadLine());

while (ChooseId > products.Count) {
    Console.WriteLine("Wrong ID.Choose one from the list");
    Console.Write("Choose product by the ID: ");
    ChooseId = int.Parse(Console.ReadLine());
}
Payment Payment = new Payment()
{
    Amount = products[ChooseId - 1].Price,
    Description = products[ChooseId - 1].Description
};
Console.WriteLine("Choose your payment method: ");
Console.WriteLine("1.Paypal");
Console.WriteLine("2.Stripe");
Console.Write("Type the number for the provider of your choice: ");
var PaymentType = int.Parse(Console.ReadLine());
if (PaymentType == 1)
{
    PayPal.ProcessPayment(Payment);
}
if (PaymentType == 2)
{
    Stripe.ProcessPayment(Payment);
}
else {
    while (PaymentType > payMethods.Count)
    {
        Console.WriteLine("Wrong type of payment method");
        Console.Write("Type the number for the provider of your choice: ");

        PaymentType = int.Parse(Console.ReadLine());
        if (PaymentType == 1)
        {
            PayPal.ProcessPayment(Payment);
        }
        if (PaymentType == 2)
        {
            Stripe.ProcessPayment(Payment);
        }
    }
}
#endregion