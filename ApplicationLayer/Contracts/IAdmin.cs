using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface IAdmin
    {
        Task<ServiceResponse> AddAsync(Admin admin);
        Task<ServiceResponse> UpdateAsync(Admin admin);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Admin>> GetAllAdmins();
        Task<Admin> GetById(int id);


    }
}
