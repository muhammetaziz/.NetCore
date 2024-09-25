using System.ComponentModel.DataAnnotations;

namespace NetCoreV2.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen Rol Adı Giriniz")]

        public  string Name { get; set; }
    }
}
