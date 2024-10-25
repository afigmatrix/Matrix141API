using System;

namespace Matrix1141EF.Model.DTO
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
