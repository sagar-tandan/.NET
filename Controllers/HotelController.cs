using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        public HotelController(ApplicationDBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _context.Hotel.ToListAsync();
            if (hotels == null)
            {
                return NotFound();
            }
            return Ok(hotels);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var retrivedHotel = await _context.Hotel.FindAsync(id);
            if (retrivedHotel == null)
            {
                return NotFound();
            }
            return Ok(retrivedHotel);
        }

        [HttpPost]

        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();
            }
            await _context.Hotel.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotel);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            var hotelToBeUpdated = await _context.Hotel.FindAsync(id);

            if (hotelToBeUpdated == null)
            {
                return NotFound();
            }

            hotelToBeUpdated.Name = hotel.Name;
            hotelToBeUpdated.Price = hotel.Price;
            hotelToBeUpdated.Description = hotel.Description;
            hotelToBeUpdated.Images = hotel.Images;
            hotelToBeUpdated.Rating = hotel.Rating;
            hotelToBeUpdated.FreeCancelation = hotel.FreeCancelation;
            hotelToBeUpdated.ReserveNow = hotel.ReserveNow;

            // await _context.Hotel.Update(hotelToBeUpdated);
            _context.Entry(hotelToBeUpdated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(hotel);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            var hotelToBeDeleted = await _context.Hotel.FindAsync(id);
            if (hotelToBeDeleted == null)
            {
                return BadRequest();
            }
            _context.Hotel.Remove(hotelToBeDeleted);
            await _context.SaveChangesAsync();

            return Ok(new { message = "The hotel is deleted Successfully!" });
        }

    }
}