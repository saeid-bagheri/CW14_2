using WebApplication19.Models;
using WebApplication19.Models.ViewModels;

namespace WebApplication19.DAl
{
    public class PaymentRipository
    {
        public void AddPayment(PaymentViewModel paymentViewModel)
        {
            var payment = new Payment
            {
                CardNumber = paymentViewModel.CardNumber,
                Price = paymentViewModel.Price
            };
            DataStorage.Payments.Add(payment);
        }

        public string GenerateCaptcha()
        {
            Random generator = new Random();
            String r = generator.Next(0, 100000).ToString("D5");
            return r;
        }

    }

}
