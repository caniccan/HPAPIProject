using System.ComponentModel.DataAnnotations;

namespace HPAPI.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string Password { get; set; }
    }
}
