using System.ComponentModel.DataAnnotations;
namespace Data.DTOs
{
    public class UpdateUserReq
    {
        [Required]
        public String userName {get ; set;}
        [Required]
        public String email {get ; set;}
    }
}