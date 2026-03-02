using System.ComponentModel.DataAnnotations;
namespace Entities
{
    public class User
    {
        [Key]
        public Guid userId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

    }
}