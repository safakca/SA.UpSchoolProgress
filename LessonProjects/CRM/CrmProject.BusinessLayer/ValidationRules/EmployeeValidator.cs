using CrmProject.EntityLayer.Concrete;
using FluentValidation;

namespace CrmProject.BusinessLayer.ValidationRules;
public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Personel adı boş geçilemez!");
        RuleFor(x => x.EmployeeSurname).NotEmpty().WithMessage("Personel soyadı boş geçilemez!");
        RuleFor(x => x.EmployeeName).MinimumLength(2).WithMessage("Lütfen az 2 karakterli veri giriniz!");
        RuleFor(x => x.EmployeeName).MaximumLength(20).WithMessage("Lütfen az fazla 20 karakterli veri giriniz!");
    }
}
