using Bookings.Application.Entities;
using Bookings.Application.Interfaces;
using Bookings.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly BookingContext _bookingContext;

        public HotelRepository(BookingContext bookingContext)
        {
            this._bookingContext = bookingContext;
        }

        public async Task<Hotel> GetHotelByIdAsync(int HotelId)
        {
            return await this._bookingContext.Hotels.FindAsync(HotelId);
        }
    }
}
