using System;

namespace Matrix1141EF.Data.Entity
{
    public class Product:BaseEntity
    {
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
    }
}
