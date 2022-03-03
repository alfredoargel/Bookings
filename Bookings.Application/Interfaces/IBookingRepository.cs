using Bookings.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetBookingsActiveByHotelAndDateRangeAsync(int HotelId, DateTime startDate, DateTime finishDate);
        Task<int> GetCountBookingsActiveByHotelAndDateRangeAsync(int HotelId, DateTime startDate, DateTime finishDate);
        Task<Booking> GetBookingsByIdAsync(int BookingId);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
    }
}
