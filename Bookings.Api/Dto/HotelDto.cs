using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Api.Dto
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Length { get; set; }
        public string Description { get; set; }
        public bool Activo { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
