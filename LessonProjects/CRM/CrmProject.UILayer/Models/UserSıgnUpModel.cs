using System.ComponentModel.DataAnnotations;

namespace CrmProject.UILayer.Models;
public class UserSıgnUpModel
{
    [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "Lütfen mailinizi giriniz.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Lütfen şifrenizi yeniden giriniz.")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor lütfen tekrar deneyin.")]
    public string ConfirmPassword { get; set; }
}
