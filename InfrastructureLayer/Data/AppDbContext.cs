using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public object User;

        //public DbSet<Student> Students { get; set; } 
        //public DbSet<Payment> Payments { get; set; } = null!;
        //public DbSet<Login> Logins { get; set; } = null!;
        //public DbSet<Admin> Admins { get; set; } = null!;

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Admin> Admins => Set<Admin>();

        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Login> Logins => Set<Login>();

       public DbSet<UserLogin> UsersLogin => Set<UserLogin>();
    }
}