using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class HotelBooking
    {
        public int Id { get; set; }

        // public int UserId { get; set; }
        // public User? User { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public DateTime CheckedIn { get; set; }
        public DateTime CheckedOut { get; set; }


    }
}