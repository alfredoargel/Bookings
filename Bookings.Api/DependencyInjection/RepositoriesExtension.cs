using Bookings.Application.Interfaces;
using Bookings.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Api.DependencyInjection
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
