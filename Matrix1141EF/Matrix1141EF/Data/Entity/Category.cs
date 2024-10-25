using System.Collections.Generic;
using System;

namespace Matrix1141EF.Data.Entity
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
