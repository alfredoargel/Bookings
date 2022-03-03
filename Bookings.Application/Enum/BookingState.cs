using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Enum
{
    public enum BookingState
    {
        [Description("Reservado")]
        reserved = 1,
        [Description("Cancelado")]
        cancelled = 2
    }
}
