using System;

namespace Matrix1141EF.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
        public string Currency { get; set; }
        public DateTime CreadeDate { get; set; }
    }
}
