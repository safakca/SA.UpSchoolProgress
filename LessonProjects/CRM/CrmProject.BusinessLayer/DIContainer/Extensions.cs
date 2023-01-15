using CrmProject.BusinessLayer.Abstract;
using CrmProject.BusinessLayer.Concrete;
using CrmProject.BusinessLayer.ValidationRules.ContactValidation;
using CrmProject.DataAccessLayer.Abstract;
using CrmProject.DataAccessLayer.EntityFramework;
using CrmProject.DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CrmProject.BusinessLayer.DIContainer;
public static class Extensions
{
    public static void ConteinerDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryDal, EFCategoryDal>();

        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IEmployeeDal, EFEmployeeDal>();

        services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
        services.AddScoped<IEmployeeTaskDal, EFEmployeeTaskDal>();

        services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
        services.AddScoped<IEmployeeTaskDetailDal, EFEmployeeTaskDetailDal>();

        services.AddScoped<IMessageService, MessageManager>();
        services.AddScoped<IMessageDal, EFMessageDal>();

        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

        services.AddScoped<ICustomerService, CustomerManager>();
        services.AddScoped<ICustomerDal, EFCustomerDal>();

        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IContactDal, EFContactDal>();
    }
    public static void CustomizeValidator(this IServiceCollection services)
    {
        services.AddTransient<IValidator<ContactAddDTO>, ContactAddValidator>();
        services.AddTransient<IValidator<ContactUpdateDTO>, ContactUpdateValidator>();
    }
}
