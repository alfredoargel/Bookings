using Bookings.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Data.Config
{
    class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
               new Hotel()
               {
                   HotelId = 1,
                   Name = "Hotel 1",
                   Country = "Colombia",
                   Latitude = 0,
                   Length = 0,
                   Description = "Hotel 1",
                   Activo = true,
                   NumberOfRooms = 10
               },
                new Hotel()
                {
                    HotelId = 2,
                    Name = "Hotel 2",
                    Country = "Colombia",
                    Latitude = 0,
                    Length = 0,
                    Description = "Hotel 2",
                    Activo = true,
                    NumberOfRooms = 10
                },
                new Hotel()
                {
                    HotelId = 3,
                    Name = "Hotel 3",
                    Country = "Colombia",
                    Latitude = 0,
                    Length = 0,
                    Description = "Hotel 3",
                    Activo = true,
                    NumberOfRooms = 10
                });
        }
    }
}
