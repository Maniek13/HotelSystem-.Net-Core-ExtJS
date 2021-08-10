using HotelSys.Models;
using System.Collections;
using System.Collections.Generic;

namespace HotelSys.Interfaces
{
    public class IResponde
    {
        int Code { get; set; }
        string Message { get; set; }
        IEnumerable<Reservation> Reservations { get; set; }
        IEnumerable<Guest> Guests { get; set; }
    }
}
