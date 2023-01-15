using System.ComponentModel.DataAnnotations;

namespace CrmProject.UILayer.Models;
public class RoleViewModel
{
    [Required(ErrorMessage = "Lütfen Rol giriniz.")]
    public string RoleName { get; set; }
}
