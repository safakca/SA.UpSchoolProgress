using CrmProject.EntityLayer.Concrete;
using FluentValidation;

namespace CrmProject.BusinessLayer.ValidationRules;
public class AnnouncementValidator : AbstractValidator<Announcement>
{
    public AnnouncementValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
        RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş geçilemez.");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık 5 karakterden küçük olamaz.");
        RuleFor(x => x.Title).MinimumLength(20).WithMessage("Başlık 20 karakterden büyük olamaz.");
    }
}
