using Microsoft.AspNetCore.Identity;

namespace CrmProject.UILayer.Models;
public class CustomIdentityValidator : IdentityErrorDescriber
{
    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError()
        {
            Code = "PasswordTooShort",
            Description = $"Şifre en az {length} karakter olmalıdır."
        };
    }
    public override IdentityError PasswordRequiresLower()
    {
        return new IdentityError()
        {
            Code = "PasswordRequiresLower",
            Description = "Lütfen en az 1 küçük karakter giriniz."
        };
    }
    public override IdentityError PasswordRequiresUpper()
    {
        return new IdentityError()
        {
            Code = "PasswordRequiresUpper",
            Description = "Lütfen en az 1 büyük karakter giriniz."
        };
    }
    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError()
        {
            Code = "PasswordRequiresDigit",
            Description = "Lütfen en az 1 sayı giriniz."
        };
    }
    public override IdentityError DuplicateEmail(string email)
    {
        return new IdentityError()
        {
            Code = "DuplicateEmail",
            Description = $"İlgili mail adresi :{email} sistemde mevcut.Farklı bir mail adresi deneyin."
        };
    }
    public override IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError()
        {
            Code = "DuplicateUserName",
            Description = $"İlgili kullanıcı adı :{userName} sistemde mevcut.Farklı bir kullanıcı adı deneyin."
        };
    }
}
