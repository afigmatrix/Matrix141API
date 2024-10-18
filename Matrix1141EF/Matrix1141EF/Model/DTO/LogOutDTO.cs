using System.ComponentModel.DataAnnotations;

namespace Matrix1141EF.Model.DTO
{
    public class LogOutDTO
    {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string Token { get; set; }
    }
}
