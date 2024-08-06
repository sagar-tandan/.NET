using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.HotelDTOs;
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

            var hotelDTO = hotels.Select(hotel => new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Price = hotel.Price,
                Description = hotel.Description,
                Images = hotel.Images,
                Rating = hotel.Rating,
                FreeCancelation = hotel.FreeCancelation,
                ReserveNow = hotel.ReserveNow
            }).ToList();


            return Ok(hotelDTO);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var retrivedHotel = await _context.Hotel.FindAsync(id);

            if (retrivedHotel == null)
            {
                return NotFound();
            }

            var retrivedHotelDTO = new HotelDTO
            {
                Id = retrivedHotel.Id,
                Name = retrivedHotel.Name,
                Price = retrivedHotel.Price,
                Description = retrivedHotel.Description,
                Images = retrivedHotel.Images,
                Rating = retrivedHotel.Rating,
                FreeCancelation = retrivedHotel.FreeCancelation,
                ReserveNow = retrivedHotel.ReserveNow
            };
            return Ok(retrivedHotelDTO);
        }

        [HttpPost]

        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel = new Hotel
            {
                Name = hotelDTO.Name,
                Price = hotelDTO.Price,
                Description = hotelDTO.Description,
                Images = hotelDTO.Images,
                Rating = hotelDTO.Rating,
                FreeCancelation = hotelDTO.FreeCancelation,
                ReserveNow = hotelDTO.ReserveNow

            };

            await _context.Hotel.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = hotel.Id }, hotelDTO);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateDTO hotelDTO)
        {
            var hotelToBeUpdated = await _context.Hotel.FindAsync(id);

            if (hotelToBeUpdated == null)
            {
                return NotFound();
            }

            hotelToBeUpdated.Name = hotelDTO.Name;
            hotelToBeUpdated.Price = hotelDTO.Price;
            hotelToBeUpdated.Description = hotelDTO.Description;
            hotelToBeUpdated.Images = hotelDTO.Images;
            hotelToBeUpdated.Rating = hotelDTO.Rating;
            hotelToBeUpdated.FreeCancelation = hotelDTO.FreeCancelation;
            hotelToBeUpdated.ReserveNow = hotelDTO.ReserveNow;

            // await _context.Hotel.Update(hotelToBeUpdated);
            _context.Entry(hotelToBeUpdated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(hotelToBeUpdated);

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