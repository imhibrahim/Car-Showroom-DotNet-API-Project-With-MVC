using Microsoft.EntityFrameworkCore;

namespace carshowroomapi.models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Booking> Booking { get; set; }

    }
}

