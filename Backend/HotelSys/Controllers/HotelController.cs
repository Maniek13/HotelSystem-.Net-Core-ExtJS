using HotelSys.DAL;
using HotelSys.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelSys.Elements;

namespace HotelSys.Controllers
{
    [Produces("application/json")]
    public class HotelController : Controller
    { 
    
        private readonly HotelSysContext _context = new();
        private readonly Responde responde = new();


        public string Index()
        {
            return "Welcome to hotel reservation system server";
        }

        public JsonResult AllReservations()
        {
            try
            {
                responde.Code = 100;
                responde.Message = "Ok";
                responde.Reservations = _context.Reservations.ToList();
            }
            catch (Exception e)
            {
                responde.Code = 200;
                responde.Message = e.Message;
            }

            return Json(responde);
        }

        public JsonResult GuestsNamedPiotr()
        {
            try
            {
                responde.Code = 100;
                responde.Message = "Ok";
                responde.Guests = _context.Guests.ToList().Where(a => a.Name == "Piotr");
            }
            catch (Exception e)
            {
                responde.Code = 200;
                responde.Message = e.Message;
            }

            return Json(responde);
        }

        [HttpPost]
        public JsonResult SetReservation([Bind("CheckIn, CheckOut, Price, Currency, Provision, Source")] Reservation reservation, [Bind("Users")] string users)
        {
            string code = "R";
            Random rand = new();
            List<Reservation> list;

            try
            {
                list =  _context.Reservations.ToList();
                code += list.Last().Id + 1 + "C";

                if (code.Length > 10)
                {
                    code = "N" + (char)code[^10] + code.Substring(code.Length - 9, 8);
                }

                for(int i=code.Length; i<10; i++)
                {
                    code += rand.Next(0, 10);
                }

                reservation.ReservationCode = code;
                reservation.Created = DateTime.Now;

                ICollection<Guest> guests = new List<Guest>();

                foreach(string guest in users.Split(","))
                {
                    guests.Add(_context.Guests.Find(Convert.ToInt32(guest)));
                }

                reservation.Guests = guests;

               
                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                responde.Code = 100;
                responde.Message = "Ok";     
            }
            catch (Exception e)
            {
                responde.Code = 200;
                responde.Message = e.Message;
            }

            return Json(responde);
        }

    }
}
