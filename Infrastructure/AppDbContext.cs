using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options) 
{
    DbSet<Student> Students { get; set; }
}
