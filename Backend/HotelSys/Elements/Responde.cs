using HotelSys.Interfaces;
using HotelSys.Models;
using System.Collections.Generic;

namespace HotelSys.Elements
{
    public class Responde : IResponde
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<Reservation> Reservations {get; set;}
        public IEnumerable<Guest> Guests { get; set; }
    }
}
