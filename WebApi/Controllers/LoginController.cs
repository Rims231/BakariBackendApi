using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

      [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var login = _context.Logins.FirstOrDefault(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
            if (login == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Password", loginDto.Password.ToString()),
                new Claim("Email", loginDto.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
            );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenValue, Login = login });
        }

        [HttpPost("RegisterAdmin")]
        public IActionResult Register(AdminDto adminDto)
        {
            var login = new DomainLayer.Entities.Login
            {
                Email = adminDto.Email,
                Password = adminDto.Password
            };
            _context.Logins.Add(login);
            _context.SaveChanges();
            return Ok(new { Token = "Admin User Registered Successfully" });
        }


        [HttpPost("RegisterStudent")]
        public IActionResult RegisterStudent(StudentDto studentDto)
        {
            var login = new DomainLayer.Entities.Login
            {
                Email = studentDto.Email,
                Password = studentDto.Password
            };
            _context.Logins.Add(login);
            _context.SaveChanges();
            return Ok(new { Token = "Student Registered Successfully" });
        }


        [Authorize]
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_context.Logins);
        }
    }
}

