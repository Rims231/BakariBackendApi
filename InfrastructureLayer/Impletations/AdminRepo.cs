using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureLayer.Implementations
{
    public class AdminRepo : IAdmin
    {
        private readonly AppDbContext appDbContext;

        public AdminRepo( AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> AddAsync(Admin admin)
        {
           appDbContext.Admins.Add(admin);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var admin = await appDbContext.Admins.FirstOrDefaultAsync(a => a.Id == id);
            if (admin == null)
                return new ServiceResponse(false, "Admin not found");

            appDbContext.Admins.Remove(admin);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Admin>> GetAllAdmins() => await appDbContext.Admins.AsNoTracking().ToListAsync();

        public async Task<Admin> GetById(int id) => await appDbContext.Admins.FindAsync(id);

        public async Task<ServiceResponse> UpdateAsync(Admin admin)
        {
            appDbContext.Update(admin);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}