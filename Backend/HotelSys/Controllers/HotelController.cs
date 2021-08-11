using HotelSys.DAL;
using HotelSys.Models;
using HotelSys.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<Reservation> list;

            try
            {
                list =  _context.Reservations.ToList();

                CodeGenertor codeGen = new();
                string code = codeGen.Generate(list.Last().Id);
            
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
