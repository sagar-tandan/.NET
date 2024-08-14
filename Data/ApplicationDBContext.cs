using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Hotel> Hotel { get; set; }

        // public DbSet<User> Users { get; set; }

        // public DbSet<HotelBooking> HotelBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configuring many to many relation
            // modelBuilder.Entity<HotelBooking>()
            // .HasOne(hb => hb.Hotel)
            // .WithMany(h => h.HotelBooking)
            // .HasForeignKey(hb => hb.HotelId)
            // .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<HotelBooking>()
            // .HasOne(hb => hb.User)
            // .WithMany(h => h.HotelBooking)
            // .HasForeignKey(hb => hb.UserId)
            // .OnDelete(DeleteBehavior.Restrict);



            //ROLE SEEDING
            //A list of IdentityRole objects is created to define user roles (Admin and User).
            //The NormalizedName is the uppercase version of the role name.

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles); 
            //When the database is created or updated, these roles will be inserted into the IdentityRole table
            //Here are some default roles we need in the system—please add them to the database.
        }
    }
}