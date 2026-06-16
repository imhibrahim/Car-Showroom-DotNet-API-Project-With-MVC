using carshowroomapi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace carshowroomapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext carDb;

        public CarController(ApplicationDbContext CarDb)
        {
            carDb = CarDb;
        }


        [HttpPost]
        public async Task<ActionResult<Car>> createCar(Car car)
        {
            await carDb.Cars.AddAsync(car);
            await carDb.SaveChangesAsync();
            return Ok("Car Inserted Successfully");
        }


        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
            var data = await carDb.Cars.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> getCarById(int id)
        {
            var data = await carDb.Cars.FindAsync(id);
            if (data == null)
            {
                return NotFound("Data in Not Found");
            }
            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var data = await carDb.Cars.FindAsync(id);
            if (data == null)
            {
                return NotFound("Data in Not Found");
            }

            carDb.Cars.Remove(data);
           await carDb.SaveChangesAsync();
            return Ok("Car Data Is Deletede...");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> UpdateCar(int id,Car car)
        {
            if (id!= car.id)
            {
                return BadRequest();
            }

            carDb.Entry(car).State = EntityState.Modified;
            await carDb.SaveChangesAsync();
            return Ok("Data is Updated");

        }




    }
}
