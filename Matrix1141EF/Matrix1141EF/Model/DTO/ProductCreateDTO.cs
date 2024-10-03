using System;

namespace Matrix1141EF.Model.DTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
        public string Currency { get; set; }
        public DateTime CreadeDate { get; set; }
    }
}
