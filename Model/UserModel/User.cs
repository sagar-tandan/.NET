using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.UserModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        // public string? ConfirmPassword { get; set; }


        public List<HotelBooking> HotelBooking { get; set; } = new List<HotelBooking>();

    }
}