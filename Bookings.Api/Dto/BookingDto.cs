using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Api.Dto
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }

        public UserDto User { get; set; }

        public HotelDto Hotel { get; set; }
    }
}
