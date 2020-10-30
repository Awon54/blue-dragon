using System.ComponentModel.DataAnnotations;

namespace blue_dragon.Dto.V1
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
