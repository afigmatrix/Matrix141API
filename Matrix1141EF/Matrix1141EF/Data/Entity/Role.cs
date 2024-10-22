using Microsoft.AspNetCore.Identity;

namespace Matrix1141EF.Data.Entity
{
    public class Role : IdentityRole<int>
    {
        public string RoleName { get; set; }
    }
}
