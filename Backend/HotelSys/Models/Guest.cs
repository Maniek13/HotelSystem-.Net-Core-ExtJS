using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelSys.Models
{
    [Table("Guest")]
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string PostalCod { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhgoneNr { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
