using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentCo _context; // Change to PaymentContext

        public PaymentController(Payment context) // Change to PaymentContext
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            if (_context == null)
            {
                return NotFound();
            }
            return await _context.Payments.ToListAsync(); // Access Payments DbSet
        }
    }
    }
