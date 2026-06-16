using carshowroomapi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carshowroomapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext paymentcontext;

        public PaymentController(ApplicationDbContext paymentcontext)
        {
            this.paymentcontext = paymentcontext;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(Payment Payment)
        {
            await paymentcontext.Payment.AddAsync(Payment);
            await paymentcontext.SaveChangesAsync();
            return Ok("Customer Is Inserted....");

        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetPayment()
        {
            var data = await paymentcontext.Payment.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(int id)
        {

            var data = await paymentcontext.Payment.FindAsync(id);

            if (data == null)
            {
                return NotFound("b ooking Is Not Exists In Database");
            }

            return Ok(data);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {

            var data = await paymentcontext.Payment.FindAsync(id);

            if (data == null)
            {
                return NotFound("Payment Is Not Exists In Database");
            }

            paymentcontext.Payment.Remove(data);
            await paymentcontext.SaveChangesAsync();
            return Ok("Payment Is Delted.....");

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Payment>> updatePayment(int id, Payment Payment)
        {
            if (id != Payment.Id)
            {
                return BadRequest();
            }

            paymentcontext.Entry(Payment).State = EntityState.Modified;
            await paymentcontext.SaveChangesAsync();
            return Ok("Payment is Updated");

        }
    }
}
