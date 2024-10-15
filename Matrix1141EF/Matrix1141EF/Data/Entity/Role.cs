using System.Collections;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public ICollection<User> Users{ get; set; }
    }
}
