using System;
namespace HMW_LINQ
{
    public class OrderByCostumer
    {
        public string ProdName { get; set; }
        public int PriceOfProduct { get; set; }
        public Costumer customer;

        public OrderByCostumer(string productName, int price, Costumer costumer)
        {
            ProdName = productName;
            PriceOfProduct = price;
            this.customer = costumer;
        }
        
    }
}
