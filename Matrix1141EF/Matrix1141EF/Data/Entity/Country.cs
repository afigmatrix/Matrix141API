using System.Collections;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Region> regions { get; set; }
    }
}
