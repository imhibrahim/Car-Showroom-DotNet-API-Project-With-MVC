using carshowroomapi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carshowroomapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext customercontext;

        public CustomerController(ApplicationDbContext customercontext)
        {
            this.customercontext = customercontext;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            await customercontext.Customers.AddAsync(customer);
            await customercontext.SaveChangesAsync();
            return Ok("Customer Is Inserted....");

        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            var data = await customercontext.Customers.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id) {

            var data = await customercontext.Customers.FindAsync(id);

            if (data==null)
            {
                return NotFound("Customer Is Not Exists In Database");
            }

            return Ok(data);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {

            var data = await customercontext.Customers.FindAsync(id);

            if (data == null)
            {
                return NotFound("Customer Is Not Exists In Database");
            }

             customercontext.Customers.Remove(data);
            await customercontext.SaveChangesAsync();
            return Ok("Customer Is Delted.....");

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> updateCustomer(int id ,Customer customer)
        {
            if (id != customer.id)
            {
                return BadRequest();
            }

            customercontext.Entry(customer).State = EntityState.Modified;
            await customercontext.SaveChangesAsync();
            return Ok("Customer is Updated");

        }




    }
}
