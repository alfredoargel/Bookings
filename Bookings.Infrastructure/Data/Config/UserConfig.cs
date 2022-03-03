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
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Email)
            .IsUnique();

            builder.HasData(
               new User()
               {
                   UserId = 1,
                   GivenName = "Pedro",
                   FamilyName = "Perez",
                   Address = "Calle 1 # 56 - 34",
                   Email = "cliente1@gmail.com"
               },
               new User()
               {
                   UserId = 2,
                   GivenName = "Camilo",
                   FamilyName = "Bohorquez",
                   Address = "Calle 1 # 56 - 34",
                   Email = "cliente2@gmail.com"
               },
                new User()
                {
                    UserId = 3,
                    GivenName = "Luz",
                    FamilyName = "Marin",
                    Address = "Calle 1 # 56 - 34",
                    Email = "cliente3@gmail.com"
                });
        }
    }
}
