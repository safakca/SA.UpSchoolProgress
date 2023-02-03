using CrmProject.DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace CrmProject.BusinessLayer.ValidationRules.ContactValidation;
public class ContactUpdateValidator : AbstractValidator<ContactUpdateDTO>
{
    public ContactUpdateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez");
        RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez");
        RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj boş geçilemez");

        RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen en az 5 karakterli veri giriniz");
        RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakterli veri giriniz");

        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen en çok 50 karakterli veri giriniz");
        RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en çok 100 karakterli veri giriniz");
    }
}
