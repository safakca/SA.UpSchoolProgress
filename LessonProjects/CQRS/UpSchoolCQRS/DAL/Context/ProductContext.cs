﻿using Microsoft.EntityFrameworkCore;
using UpSchool_CQRS_DesignPatterns.DAL.Entities;

namespace UpSchool_CQRS_DesignPatterns.DAL.Context;
public class ProductContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=UpSchoolCQRS;integrated security=True;");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<University> Universities { get; set; }
}
