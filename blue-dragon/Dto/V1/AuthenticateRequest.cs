using System.ComponentModel.DataAnnotations;

namespace blue_dragon.Dto.V1
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
