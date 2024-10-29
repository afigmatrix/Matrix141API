using System;

namespace Matrix1141EF.Model.DTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public DateTime ManifacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
    }
}
