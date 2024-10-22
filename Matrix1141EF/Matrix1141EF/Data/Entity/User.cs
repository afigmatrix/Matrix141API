using Microsoft.AspNetCore.Identity;

namespace Matrix1141EF.Data.Entity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string FinCode { get; set; }
        

    }
}
