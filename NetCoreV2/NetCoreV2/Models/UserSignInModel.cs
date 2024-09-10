using System.ComponentModel.DataAnnotations;

namespace NetCoreV2.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Gİriniz")]
        public string username { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi Gİriniz")]
        public string password { get; set; }

    }
}
