using System.Collections;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class User : BaseEntity
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        public string Name { get; set; }
        public string HashPassword { get; set; } 
        public string Email { get; set; }
        public string? Token { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
