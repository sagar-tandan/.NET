using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.HotelDTOs
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = "";

        public List<string> Images { get; set; } = new List<string>();

        public float Rating { get; set; }

        public bool FreeCancelation { get; set; }

        public bool ReserveNow { get; set; }
    }
}