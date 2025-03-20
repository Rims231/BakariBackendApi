using ApplicationLayer.Dtos;
using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }



        [HttpPost("CreateNewUser")]
        public IActionResult CreateNewUser(User obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return CreateNewUser(obj);

        }


    }
}

