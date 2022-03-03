using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Entities
{
    public class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Country { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Length { get; set; }
        public string Description { get; set; }
        public bool Activo { get; set; }
        public int NumberOfRooms { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
