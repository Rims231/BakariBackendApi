using ApplicationLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Contracts
{
    public interface ILogin
    {
        Task<ServiceResponse> RegisterAsync(StudentDto studentDto);
        Task<ServiceResponse> LoginAsync(LoginDto loginDto);
        Task<ServiceResponse> GetUserId(int Id);
    }
}
