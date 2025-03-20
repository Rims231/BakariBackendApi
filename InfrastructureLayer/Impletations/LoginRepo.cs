using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Impletations
{
    
    internal class LoginRepo : ILogin
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginRepo(AppDbContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private async Task<Student?> GetUserById(string email)
        {
            var login = await _context.Logins.FirstOrDefaultAsync(x => x.Email == email);
            if (login == null)
                return null;

            // Map Login to Student (example mapping)
            return new Student
            {
                Id = login.Id, 
                Email = login.Email,
              
            };
        }
     

        public Task<ServiceResponse> GetUserId(int Id)
        {
            throw new NotImplementedException();
        }
        
        public Task<ServiceResponse> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> RegisterAsync(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
