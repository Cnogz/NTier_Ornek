using System.ComponentModel.DataAnnotations;

namespace YMS5122_NTier.UI.Areas.Admin.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı adını boş geçemezsiniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifreyi boş geçemezsiniz!")]
        public string Password { get; set; }

    }
}