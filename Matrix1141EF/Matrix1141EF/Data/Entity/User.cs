using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Matrix1141EF.Data.Entity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            UserProducts=new HashSet<UserProduct>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string FinCode { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }
    }
}
