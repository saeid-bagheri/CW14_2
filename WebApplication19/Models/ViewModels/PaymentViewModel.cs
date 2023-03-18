using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication19.Models.ViewModels
{
    public class PaymentViewModel
    {
        //[RegularExpression(@"^6037.*", ErrorMessage ="با 6037 شروع شود")]
        [Display(Name ="شماره کارت")]
        [Remote(action: "CheckCardNumber",controller: "Payment", HttpMethod = "POST", ErrorMessage = "با 6037 شروع شود")]
        [StringLength(16, ErrorMessage = "16 رقمی باشد", MinimumLength = 16)]
        public string CardNumber { get; set; }

        [Display(Name ="قیمت")]
        public int Price { get; set; }

        [Display(Name ="کد کپچا")]
        [StringLength(5, ErrorMessage = "5 رقمی باشد", MinimumLength = 5)]
        public string Captcha { get; set; }

        
        [Display(Name ="cvv2")]
        [StringLength(4, ErrorMessage = "3 یا 4 رقمی باشد", MinimumLength = 3)]
        public string CVV2 { get; set; }
        [Compare(otherProperty:"CVV2", ErrorMessage ="تکراری باشد")]
        public string CVV2Confirm { get; set; }

    }
}
