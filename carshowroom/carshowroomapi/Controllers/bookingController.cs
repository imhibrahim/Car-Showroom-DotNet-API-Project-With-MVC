using carshowroomapi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carshowroomapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingController : ControllerBase
    {

        private readonly ApplicationDbContext bookingcontext;

        public bookingController(ApplicationDbContext bookingcontext)
        {
            this.bookingcontext = bookingcontext;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Createbooking(Booking booking)
        {
            await bookingcontext.Booking.AddAsync(booking);
            await bookingcontext.SaveChangesAsync();
            return Ok("Customer Is Inserted....");

        }

        [HttpGet]
        public async Task<ActionResult<List<Booking>>> Getbooking()
        {
            var data = await bookingcontext.Booking.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetbookingById(int id)
        {

            var data = await bookingcontext.Booking.FindAsync(id);

            if (data == null)
            {
                return NotFound("b ooking Is Not Exists In Database");
            }

            return Ok(data);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> Deletebooking(int id)
        {

            var data = await bookingcontext.Booking.FindAsync(id);

            if (data == null)
            {
                return NotFound("Booking Is Not Exists In Database");
            }

            bookingcontext.Booking.Remove(data);
            await bookingcontext.SaveChangesAsync();
            return Ok("Booking Is Delted.....");

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Booking>> updatebooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            bookingcontext.Entry(booking).State = EntityState.Modified;
            await bookingcontext.SaveChangesAsync();
            return Ok("booking is Updated");

        }


    }
}
