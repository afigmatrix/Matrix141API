using System;

namespace Matrix1141EF.Model
{
    public class ProductGetDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ManifacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
