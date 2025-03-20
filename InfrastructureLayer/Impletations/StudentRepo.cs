using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureLayer.Impletations
{
    public class StudentRepo : IStudent
    {
        private readonly AppDbContext appDbContext;

        public StudentRepo( AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ApplicationLayer.Dtos.ServiceResponse> AddAsync(Student student)
        {
            appDbContext.Students.Add(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var student = await appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
                return new ServiceResponse(false, "User not found");

            appDbContext.Students.Remove(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Student>> GetStudent() => await appDbContext.Students.AsNoTracking().ToListAsync();

        public async Task<Student> GetById(int id) => await appDbContext.Students.FindAsync(id);

        public async Task<ServiceResponse> UpdateAsync(Student student)
        {
            appDbContext.Update(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

        private async Task SaveChangesAsync() => await appDbContext.SaveChangesAsync();
    }
}