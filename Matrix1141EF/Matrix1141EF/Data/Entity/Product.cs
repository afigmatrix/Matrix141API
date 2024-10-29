using System;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class Product:BaseEntity
    {
        public Product()
        {
            UserProducts=new HashSet<UserProduct>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ManifacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }
    }
}
