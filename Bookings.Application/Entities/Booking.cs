using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Entities
{
    public class Booking
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Checkin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Checkout { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BookingDate { get; set; }
        public int State { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
    }
}
