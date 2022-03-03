using Bookings.Application.Entities;
using Bookings.Application.Interfaces;
using Bookings.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingContext _bookingContext;
        public UserRepository(BookingContext bookingContext)
        {
            this._bookingContext = bookingContext;
        }

        public async Task<User> GetUserByIdAsync(int UserId)
        {
            return await this._bookingContext.Users.FindAsync(UserId);
        }
    }
}
