using Bookings.Application.Entities;
using Bookings.Application.Enum;
using Bookings.Application.Interfaces;
using Bookings.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _bookingContext;
        public BookingRepository(BookingContext bookingContext)
        {
            this._bookingContext = bookingContext;
        }

        public async Task<List<Booking>> GetBookingsActiveByHotelAndDateRangeAsync(int HotelId, DateTime startDate, DateTime finishDate)
        {
            return await this._bookingContext.Bookings
                .Where(b => b.HotelId == HotelId && b.State == (int)BookingState.reserved &&
                b.Checkin <= finishDate && b.Checkout > startDate)
                .Include(d => d.Hotel)
                .Include(d => d.User)
                .ToListAsync();
        }

        public async Task<int> GetCountBookingsActiveByHotelAndDateRangeAsync(int HotelId, DateTime startDate, DateTime finishDate)
        {
            return await this._bookingContext.Bookings
                .CountAsync(b => b.HotelId == HotelId && b.State == (int)BookingState.reserved &&
                b.Checkin <= finishDate && b.Checkout > startDate);
        }

        public async Task<Booking> GetBookingsByIdAsync(int BookingId)
        {
            return await this._bookingContext.Bookings.FindAsync(BookingId);
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            await this._bookingContext.AddAsync(entity: booking);
            await this._bookingContext.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            this._bookingContext.Update(entity: booking);
            await this._bookingContext.SaveChangesAsync();

            return booking;
        }
    }
}
