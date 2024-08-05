using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<string> Images { get; set; } = new List<string>();

        public float Rating { get; set; }

        public bool FreeCancelation { get; set; }

        public bool ReserveNow { get; set; }


    }
}