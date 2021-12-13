using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class Buyer
    {
        [Key]
        public int BuyerID {get;set;}
        public string Name {get;set;}
        public string Payment {get;set;}
        public string part {get;set;}

    }
}