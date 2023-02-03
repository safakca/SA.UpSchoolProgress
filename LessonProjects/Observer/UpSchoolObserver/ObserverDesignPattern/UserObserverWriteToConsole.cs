using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using UpSchool_Observer_DesignPattern.DAL;

namespace UpSchool_Observer_DesignPattern.ObserverDesignPattern;
public class UserObserverWriteToConsole : IUserObserver
{ 
    private IServiceProvider _serviceProvider;  
    public UserObserverWriteToConsole(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public void CreateUser(AppUser appUser)
    {
        var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWriteToConsole>>();  
        logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli" +
            $"kullanıcı sisteme kaydoldu.");  
    }
}
