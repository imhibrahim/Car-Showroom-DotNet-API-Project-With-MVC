using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewIdentity.Areas.Identity.Data;
using NewIdentity.Models;

namespace NewIdentity.Areas.Identity.Data;

public class userDbContext : IdentityDbContext<user>
{
    public userDbContext(DbContextOptions<userDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new userconfiguration());   
    }


    public DbSet<mall> mall { get; set; } = default!;

public DbSet<NewIdentity.Models.Customer> Customer { get; set; } = default!;

}

internal class userconfiguration : IEntityTypeConfiguration<user>
{
    public void Configure(EntityTypeBuilder<user> builder)
    {
       
    }
}