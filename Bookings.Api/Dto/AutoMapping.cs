using AutoMapper;
using Bookings.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Api.Dto
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Booking, BookingDto>();
            CreateMap<BookingDto, Booking>()
                .ForMember(dest => dest.Checkin, opt => opt.MapFrom(src => src.Checkin.Date))
                .ForMember(dest => dest.Checkout, opt => opt.MapFrom(src => src.Checkout.Date));

            CreateMap<Hotel, HotelDto>();
            CreateMap<HotelDto, Hotel>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
