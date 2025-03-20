using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent student;

        public StudentController(IStudent student)
        {
            this.student = student;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await student.GetStudent();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await student.GetById(id);
            return Ok(data);
        }

        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] Student studentdto)
        //{
        //    var data = await student.AddAsync(studentdto);
        //    return Ok(data);
        //}


        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] Student studentdto)
        //{
        //    var data = await student.UpdateAsync(studentdto);
        //    return Ok(data);
        //}

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student StudentDto)
        {
            var result = await student.AddAsync(StudentDto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student StudentDto)
        {
            var result = await student.UpdateAsync(StudentDto);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await student.DeleteAsync(id);
            return Ok(result);
        }
    }
}
