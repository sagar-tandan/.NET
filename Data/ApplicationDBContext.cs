using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using api.Model.UserModel;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<HotelBooking> HotelBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuring many to many relation
            modelBuilder.Entity<HotelBooking>()
            .HasOne(hb => hb.Hotel)
            .WithMany(h => h.HotelBooking)
            .HasForeignKey(hb => hb.HotelId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HotelBooking>()
            .HasOne(hb => hb.User)
            .WithMany(h => h.HotelBooking)
            .HasForeignKey(hb => hb.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}