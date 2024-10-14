using System;

namespace Matrix1141EF.Model.DTO
{
    public class ProductDeleteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Currency { get; set; }
    }
}
