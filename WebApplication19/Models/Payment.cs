using System.ComponentModel.DataAnnotations;

namespace WebApplication19.Models
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public int  Price { get; set; }

        public string UserIp { get; set; }


    }
}
