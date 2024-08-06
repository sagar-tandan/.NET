using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Hotel
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } 

        public decimal Price { get; set; }

        public string Description { get; set; } = "";

        public List<string> Images { get; set; } = new List<string>();

        public float Rating { get; set; }

        public bool FreeCancelation { get; set; }

        public bool ReserveNow { get; set; }

        //One to many Relation
        public List<HotelReview> HotelReviews { get; set; } = new List<HotelReview>();


    }
}