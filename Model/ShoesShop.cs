using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    public class ShoesShop
    {
        [Key]

        public int ShoesID {get;set;}
        public string Color {get;set;}
        public string Brand {get;set;} //brand=marca
        public decimal price {get;set;} //no puede ser string
        public int quantity {get;set;} //si se refiere a cantidad es quantity
        public int BuyerID {get;set;}
        public Buyer Buyer {get; set;}
    }
}