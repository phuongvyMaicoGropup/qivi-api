using System;
using Core.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    
    public class Product : BaseEntity
    {
        public Product()
        {

        }

        public Product(string name,string description, decimal price, bool isEmpty, string categoryId, decimal discountPrice, int discountQuantity, string quantity , string image )
        {
            Name = name;
            Description = description;
            Price = price;
            IsEmpty = isEmpty;
            Quantity = quantity; 
            CategoryId = categoryId;
            DiscountPrice = discountPrice;
            DiscountQuantity = discountQuantity;
            Image = image; 
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DiscountQuantity { set; get; }
        public decimal DiscountPrice { set; get; }
        public bool IsEmpty { get; set; }
        public string CategoryId { get; set; }
        public string Image { set; get; } = "";
        public string Quantity { set; get; } = "";
       
        //public QuantityType QuantityType { set; get; } = QuantityType.NONE; 
    }

    public enum QuantityType
    {
        KG , G , ML , L , NONE
    }
}


