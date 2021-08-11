using HotelSys.Models;
using System.Collections.Generic;

namespace HotelSys.Interfaces
{
    interface IResponde
    {
        int Code { get; set; }
        string Message { get; set; }
        IEnumerable<Reservation> Reservations { get; set; }
        IEnumerable<Guest> Guests { get; set; }
    }
}
