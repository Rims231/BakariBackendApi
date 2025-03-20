using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
       

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Admin> Admins => Set<Admin>();

        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Login> Logins => Set<Login>();

       
    }
}
