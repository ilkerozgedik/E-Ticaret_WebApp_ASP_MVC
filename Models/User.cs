using System.ComponentModel.DataAnnotations;

namespace RegisterLoginApp_ASP_MVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
