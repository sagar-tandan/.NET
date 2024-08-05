using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var hotels = _context.Hotel.ToList();
            if (hotels == null)
            {
                return NotFound();
            }
            return Ok(hotels);

        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var retrivedHotel = _context.Hotel.Find(id);
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
            return Ok(hotel);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateHotel(int id, [FromBody] Hotel hotel)
        {
            var hotelToBeUpdated = _context.Hotel.Find(id);

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

            _context.Hotel.Update(hotelToBeUpdated);
            _context.SaveChanges();

            return Ok(hotel);

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteHotel([FromRoute] int id)
        {
            var hotelToBeDeleted = _context.Hotel.Find(id);
            if (hotelToBeDeleted == null)
            {
                return BadRequest();
            }
            _context.Hotel.Remove(hotelToBeDeleted);
            _context.SaveChanges();

            return Ok(new { message = "The hotel is deleted Successfully!" });
        }

    }
}