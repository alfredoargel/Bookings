using Bookings.Application.Interfaces;
using Bookings.Application.Services;
using Bookings.Infrastructure.Logging;
using Bookings.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Api.DependencyInjection
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IBookingService, BookingService>();

            return services;
        }
    }
}
