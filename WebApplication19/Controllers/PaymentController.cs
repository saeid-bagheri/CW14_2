using Microsoft.AspNetCore.Mvc;
using WebApplication19.DAl;
using WebApplication19.Models;
using WebApplication19.Models.ViewModels;

namespace WebApplication19.Controllers
{
    public class PaymentController : Controller
    {
        PaymentRipository paymentRipository = new();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CompleteOrder()
        {

            TempData["captcha"] = paymentRipository.GenerateCaptcha();
            TempData.Keep("captcha");

            return View();
        }


        [HttpPost]
        public IActionResult CompleteOrder(PaymentViewModel payment)
        {
            var httpType = Request.Method.ToString();
            if (TempData["captcha"].ToString() == payment.Captcha.ToString())
            {
            paymentRipository.AddPayment(payment);
            return RedirectToAction("Index","Home");    
            }
            else
            {
                TempData["message"] = "لطفا کپچا را درست وارد کنید";
            }
            return RedirectToAction("CompleteOrder");
        }


        public IActionResult ShowRequestDetails()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
            var httpType = Request.Method.ToString();
            return View(remoteIpAddress);
        }

        [HttpPost]
        public bool CheckCardNumber(string CardNumber)
        {
            if (CardNumber.StartsWith("6037"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
