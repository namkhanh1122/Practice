using System.ComponentModel.DataAnnotations;

namespace Data.DTOs
{
    public class CreateUserReq
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}