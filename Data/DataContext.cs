using System;
using Microsoft.EntityFrameworkCore;
using SampleApiController.Entities;

namespace SampleApiController.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users{get; set;}
}
