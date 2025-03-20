using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IStudent
    {
        Task<ServiceResponse> AddAsync(Student student);
        Task<ServiceResponse> UpdateAsync(Student student);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Student>> GetStudent();
        Task<Student> GetById(int id);
    }
}
