using Bookings.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Interfaces
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsActiveByHotelAndDateRangeAsync(int HotelId, DateTime startDate, DateTime finishDate);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<Booking> CancelBookingAsync(int BookingId);
    }
}
