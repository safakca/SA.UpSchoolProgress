﻿using System.Collections.Generic;
using UpSchool_Observer_DesignPattern.DAL;

namespace UpSchool_Observer_DesignPattern.ObserverDesignPattern;
public class UserObserverSubject
{   
    private readonly List<IUserObserver> _userObservers;   
    public UserObserverSubject()
    {
        _userObservers = new List<IUserObserver>();
    }
     
    public void RegisterObserver(IUserObserver userObserver)
    {
        _userObservers.Add(userObserver);
    }
    public void RemoveObserver(IUserObserver userObserver)
    {
        _userObservers.Remove(userObserver);
    }
    public void NotifyObserver(AppUser appUser)
    {
        _userObservers.ForEach(x =>
        {
            x.CreateUser(appUser);
        });
    }
}
