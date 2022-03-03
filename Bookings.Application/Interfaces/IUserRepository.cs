using Bookings.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int UserId);
    }
}
