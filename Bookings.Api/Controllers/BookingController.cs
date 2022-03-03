using AutoMapper;
using Bookings.Api.Dto;
using Bookings.Application.Entities;
using Bookings.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookingService _bookingService;
        private readonly IAppLogger<BookingController> _logger;
        public BookingController(IMapper mapper, IBookingService bookingService, IAppLogger<BookingController> logger)
        {
            this._mapper = mapper;
            this._bookingService = bookingService;
            this._logger = logger;
        }


        /// <summary>
        /// Metodo que permite consultar las reservas de un hotel en un rango de fechas.
        /// </summary>
        /// <param name="HotelId"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBookingsActiveByHotelAndDateRange(int HotelId, DateTime startDate, DateTime finishDate)
        {
            try
            {
                List<Booking> bookings = await this._bookingService.GetBookingsActiveByHotelAndDateRangeAsync(HotelId: HotelId, startDate: startDate, finishDate: finishDate);
                List<BookingDto> bookingDtos = this._mapper.Map<List<BookingDto>>(bookings);

                return Ok(bookingDtos);
            }
            catch (Exception ex)
            {
                this._logger.LogWarning(ex.InnerException.ToString());
                return BadRequest(new { message = ex.Message, ex = ex });
            }
        }

        /// <summary>
        /// Metodo que permite agregar una reserva de un hotel para un usuario
        /// </summary>
        /// <param name="bookingDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody]BookingDto bookingDto)
        {
            try
            {
                Booking booking = this._mapper.Map<Booking>(source: bookingDto);
                await this._bookingService.AddBookingAsync(booking: booking);

                return Ok(booking.BookingId);
            }
            catch (Exception ex)
            {
                this._logger.LogWarning(ex.InnerException.ToString());
                return BadRequest(new { message = ex.Message, ex = ex });
            }
        }

        /// <summary>
        /// Metodo que permite cancelar una reserva creada.
        /// </summary>
        /// <param name="BookingId"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> CancelBooking(int BookingId)
        {
            try
            {
                Booking booking = await this._bookingService.CancelBookingAsync(BookingId: BookingId);

                return Ok(booking.BookingId);
            }
            catch (Exception ex)
            {
                this._logger.LogWarning(ex.InnerException.ToString());
                return BadRequest(new { message = ex.Message, ex = ex });
            }
        }
    }
}
