using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.HotelDTOs
{
    public class UpdateDTO
    {
        public string Name { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public List<string> Images { get; set; } = new List<string>();

        public string Description { get; set; } = String.Empty;

        public float Rating { get; set; }

        public bool FreeCancelation { get; set; }

        public bool ReserveNow { get; set; }
    }
}