using Bookings.Application.Entities;
using Bookings.Application.Enum;
using Bookings.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<BookingService> _logger;
        public BookingService(IBookingRepository bookingRepository,
            IHotelRepository hotelRepository,
            IUserRepository userRepository,
            IAppLogger<BookingService> logger)
        {
            this._bookingRepository = bookingRepository;
            this._hotelRepository = hotelRepository;
            this._userRepository = userRepository;
            this._logger = logger;
        }

        public async Task<List<Booking>> GetBookingsActiveByHotelAndDateRangeAsync(int HotelId, DateTime startDate, DateTime finishDate)
        {
            if (startDate >= finishDate)
            {
                throw new Exception("La fecha inicial debe ser menor a la fecha final.");
            }

            return await this._bookingRepository.GetBookingsActiveByHotelAndDateRangeAsync(HotelId: HotelId, startDate: startDate, finishDate: finishDate);
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            this.ValidateCheckInDate(booking: booking);
            await this.ValidateHotelId(HotelId: booking.HotelId);
            await this.ValidateUserId(UserId: booking.UserId);
            await this.ValidateOverbooking(HotelId: booking.HotelId, Checkin: booking.Checkin, Checkout: booking.Checkout);
            booking.BookingDate = DateTime.Now;
            booking.State = (int)BookingState.reserved;

            return await this._bookingRepository.AddBookingAsync(booking: booking);
        }

        public async Task<Booking> CancelBookingAsync(int BookingId)
        {
            Booking booking = await this._bookingRepository.GetBookingsByIdAsync(BookingId: BookingId);
            this.ValidateBookingExist(booking: booking);
            this.ValidateBookingCancelled(booking: booking);
            booking.State = (int)BookingState.cancelled;
            await this._bookingRepository.UpdateBookingAsync(booking: booking);

            return booking;
        }

        private void ValidateBookingExist(Booking booking)
        {
            if (booking == null)
            {
                throw new Exception("La reserva no existe");
            }
        }

        private void ValidateBookingCancelled(Booking booking)
        {
            if (booking.State == (int)BookingState.cancelled)
            {
                throw new Exception("La reserva ya fue cancelada");
            }
        }

        private void ValidateCheckInDate(Booking booking)
        {
            if (booking.Checkin >= booking.Checkout)
            {
                throw new Exception("La fecha del CheckIn debe ser menor a la fecha del CheckOut.");
            }
        }

        private async Task ValidateHotelId(int HotelId)
        {
            Hotel hotel = await this._hotelRepository.GetHotelByIdAsync(HotelId);
            if (hotel == null)
            {
                throw new Exception("El Id del hotel no existe.");
            }
        }

        private async Task ValidateUserId(int UserId)
        {
            User user = await this._userRepository.GetUserByIdAsync(UserId);
            if (user == null)
            {
                throw new Exception("El Id del usuario no existe.");
            }
        }

        private async Task ValidateOverbooking(int HotelId, DateTime Checkin, DateTime Checkout)
        {
            Hotel hotel = await this._hotelRepository.GetHotelByIdAsync(HotelId);
            int countBookings = await this._bookingRepository.GetCountBookingsActiveByHotelAndDateRangeAsync(HotelId: HotelId, startDate: Checkin, finishDate: Checkout);

            if (hotel.NumberOfRooms == countBookings)
            {
                throw new Exception("Este hotel no tiene habitaciones disponibles para este rango de fechas.");
            }
        }
    }
}
