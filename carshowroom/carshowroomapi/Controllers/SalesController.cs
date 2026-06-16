using carshowroomapi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carshowroomapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext salesContext;

        public SalesController(ApplicationDbContext SalesContext)
        {
            salesContext = SalesContext;
        }


        [HttpPost]
        public async Task<ActionResult<Sales>> CreateSales(Sales sales )
        {

            var car = await salesContext.Cars.FindAsync(sales.Carid);
            var customer = await salesContext.Customers.FindAsync(sales.Customerid);

            sales.Car = car;
            sales.Customer = customer;


            await salesContext.Sales.AddAsync( sales );
            await salesContext.SaveChangesAsync();
            return Ok("Data is Inserted....");
        }

        [HttpGet]
        public async Task<ActionResult<List<Sales>>> GetAllSales()
        {
            var data = await salesContext.Sales
                .Include(x => x.Car)
                .Include(x => x.Customer)
                .ToListAsync();

            return Ok(data);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Sales>> Deletesales(int id)
        {

            var data = await salesContext.Sales.FindAsync(id);

            if (data == null)
            {
                return NotFound("salaes Is Not Exists In Database");
            }

            salesContext.Sales.Remove(data);
            await salesContext.SaveChangesAsync();
            return Ok("Sales Is Delted.....");

        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Sales>> updateSales(int id, Sales sales)
        {
            if (id != sales.id)
            {
                return BadRequest();
            }
            var car = await salesContext.Cars.FindAsync(sales.Carid);
            var customer = await salesContext.Customers.FindAsync(sales.Customerid);

            sales.Car = car;
            sales.Customer = customer;

            salesContext.Entry(sales).State = EntityState.Modified;
            await salesContext.SaveChangesAsync();
            return Ok("sales is updated");
        }




    }
}
