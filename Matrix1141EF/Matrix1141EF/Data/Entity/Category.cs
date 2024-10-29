using System;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
