using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin adminService;

        public AdminController(IAdmin adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await adminService.GetAllAdmins();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await adminService.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Admin AdminDto)
        {
            var result = await adminService.AddAsync(AdminDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Admin AdminDto)
        {
            var result = await adminService.UpdateAsync(AdminDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await adminService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
