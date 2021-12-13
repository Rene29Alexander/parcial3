using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class ShoesShop
    {
        [Key]

        public int ShoesID {get;set;}
        public string Color {get;set;}
        public string Brand {get;set;} 
        public decimal price {get;set;} 
        public int quantity {get;set;} 
        public int BuyerID {get;set;}
        public Buyer Buyer {get; set;}
    }
}