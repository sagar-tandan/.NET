using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.HotelBookingDTO;
using api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Authorize]
    [Route("api/bookings")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly UserManager<AppUser> _user;
        private readonly ApplicationDBContext _context;

        public HotelBookingController(ApplicationDBContext context, UserManager<AppUser> user)
        {
            _user = user;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _context.HotelBookings.Include(hb => hb.Hotel).Include(hb => hb.User).ToListAsync();

            var bookingDTO = bookings.Select(booking => new HotelBookingDto
            {
                Id = booking.Id,
                HotelName = booking.Hotel.Name,
                UserName = booking.User.UserName,
                BookingDate = booking.BookingDate,
                Duration = booking.Duration,
                Checkin = booking.Checkin,
                Checkout = booking.Checkout,
                TotalPrice = booking.TotalPrice

            }).ToList();

            return Ok(bookingDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var booking = await _context.HotelBookings.Include(hb => hb.Hotel).Include(hb => hb.User).FirstOrDefaultAsync(hb => hb.Id == id);

            if (booking == null)
            {
                return NotFound();
            }


            var bookingDto = new HotelBookingDto
            {
                Id = booking.Id,
                HotelName = booking.Hotel.Name,
                UserName = booking.User.UserName,
                BookingDate = booking.BookingDate,
                Duration = booking.Duration,
                Checkin = booking.Checkin,
                Checkout = booking.Checkout,
                TotalPrice = booking.TotalPrice
            };

            return Ok(bookingDto);


        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateHotelBookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel = await _context.Hotel.FindAsync(bookingDto.HotelId);
            var user = await _context.Users.FindAsync(bookingDto.UserId);

            if (hotel == null || user == null)
            {
                return BadRequest("Invalid HotelId or UserId.");
            }

            var booking = new HotelBooking
            {
                HotelId = bookingDto.HotelId,
                UserId = bookingDto.UserId,
                BookingDate = bookingDto.BookingDate,
                Duration = bookingDto.Duration,
                Checkin = bookingDto.Checkin,
                Checkout = bookingDto.Checkout,
                TotalPrice = bookingDto.TotalPrice
            };

            try
            {
                await _context.HotelBookings.AddAsync(booking);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateHotelBookingDto bookingDto)
        {
            var bookingInDatabase = await _context.HotelBookings.FindAsync(id);
            if (bookingInDatabase == null)
            {
                return NotFound();
            }

            bookingInDatabase.BookingDate = bookingDto.BookingDate;
            bookingInDatabase.Duration = bookingDto.Duration;
            bookingInDatabase.Checkin = bookingDto.Checkin;
            bookingInDatabase.Checkout = bookingDto.Checkout;
            bookingInDatabase.TotalPrice = bookingDto.TotalPrice;

            _context.Entry(bookingInDatabase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.HotelBookings.Any(hb => hb.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var bookingToDelete = await _context.HotelBookings.FindAsync(id);

            if (bookingToDelete == null)
            {
                return NotFound();
            }

            try
            {
                _context.HotelBookings.Remove(bookingToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }
    }
}