﻿namespace Onion.ApiConsume.Domain.Entities;
public class AppRole
{
    public int Id { get; set; }
    public string? Defination { get; set; }
    public List<AppUser>? AppUsers { get; set; }
}
