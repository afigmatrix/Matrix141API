using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Matrix1141EF.Data.Entity
{
    public class User :IdentityUser<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string FinCode { get; set; }
        public bool IsActive { get; set; }
    }
}
