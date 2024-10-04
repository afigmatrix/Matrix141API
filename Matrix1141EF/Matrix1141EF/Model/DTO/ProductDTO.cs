using System;

namespace Matrix1141EF.Model.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Currency { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
