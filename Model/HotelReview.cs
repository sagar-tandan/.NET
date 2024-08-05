using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class HotelReview
    {

        [Key]
        public int ReviewId { get; set; }

        public string? ReviewText { get; set; }

        public int Rating { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        //Navigating Property

        public Hotel? Hotel { get; set; }


    }
}