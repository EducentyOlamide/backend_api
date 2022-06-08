using API.Entities;
using API.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SchooleContext : IdentityDbContext<User, Role, int>
    {
        public SchooleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<UserAddress>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Role>()
                .HasData(
                    new Role { Id = 1, Name = "Student", NormalizedName = "STUDENT" },
                    new Role { Id = 2, Name = "Admin", NormalizedName = "ADMIN" },
                     new Role { Id = 3, Name = "Staff", NormalizedName = "STAFF" },
                    new Role { Id = 4, Name = "Teacher", NormalizedName = "TEACHER" },
                     new Role { Id = 5, Name = "Super_Admin", NormalizedName = "SUPER_ADMIN" },
                    new Role { Id = 6, Name = "Parent", NormalizedName = "PARENT" }


                );
        }
    }
}