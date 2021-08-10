using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSys.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string ReservationCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public double Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public string Currency { get; set; }

        public double? Provision { get; set; }

        public string Source { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
