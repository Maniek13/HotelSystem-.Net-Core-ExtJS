namespace HotelSys.Migrations
{
    using HotelSys.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelSys.DAL.HotelSysContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelSys.DAL.HotelSysContext context)
        {
            var guests = new List<Guest>
            {
                new Guest{Name="Piotr", Surname="Nowy", Email="piotr@wp.pl"},
                new Guest{Name="Kamil", Surname="Swiat", Email="kamil@wp.pl"},
                new Guest{Name="Marcin", Surname="Zielony", Email="marcin@wp.pl"},
                new Guest{Name="Adam", Surname="Nowy", Email="adam@wp.pl"},
                new Guest{Name="Alicja", Surname="Klapa", Email="alicja@wp.pl"},
                new Guest{Name="Klaudia", Surname="Nowy", Email="klaudia@wp.pl"},
                new Guest{Name="Paulina", Surname="Jak", Email="paulina@wp.pl"},
                new Guest{Name="Piotr", Surname="Nowy", Email="piotr@wp.pl"},
                new Guest{Name="Alan", Surname="Nowy", Email="alan@wp.pl"},
                new Guest{Name="Kacper", Surname="Nowy", Email="kacper@wp.pl"}
            };

            guests.ForEach(s => context.Guests.Add(s));
            context.SaveChanges();



            var reservations = new List<Reservation>
            {
                new Reservation{ReservationCode="ASO123", Created=DateTime.Parse("2019-06-13"), CheckIn=DateTime.Parse("2019-07-13"), CheckOut=DateTime.Parse("2019-08-13"), Currency="PLN", Price=3122.47, Guests=new List<Guest> {context.Guests.First()} },
                new Reservation{ReservationCode="ASO124", Created=DateTime.Parse("2019-06-14"), CheckIn=DateTime.Parse("2019-07-15"), CheckOut=DateTime.Parse("2019-09-13"), Currency="PLN", Price=3122.47,  Guests=new List<Guest> {context.Guests.First(x=>x.Name == "Piotr")}},
                new Reservation{ReservationCode="ASO124", Created=DateTime.Parse("2019-06-14"), CheckIn=DateTime.Parse("2019-07-15"), CheckOut=DateTime.Parse("2019-09-13"), Currency="PLN", Price=3122.47,  Guests=new List<Guest> {context.Guests.First(x=>x.Name == "Piotr")}},
                new Reservation{ReservationCode="ASO125", Created=DateTime.Parse("2019-06-15"), CheckIn=DateTime.Parse("2019-07-13"), CheckOut=DateTime.Parse("2019-08-06"), Currency="PLN", Price=31222.49, Guests=new List<Guest> {context.Guests.First(x=>x.Name == "Marcin")}},
                new Reservation{ReservationCode="ASO126", Created=DateTime.Parse("2019-06-16"), CheckIn=DateTime.Parse("2019-07-14"), CheckOut=DateTime.Parse("2019-08-01"), Currency="PLN", Price=2222.49, Guests=new List<Guest> {context.Guests.First(x=>x.Name == "Klaudia"), context.Guests.First(x=>x.Name == "Adam")}},
                new Reservation{ReservationCode="ASO127", Created=DateTime.Parse("2019-06-17"), CheckIn=DateTime.Parse("2019-07-18"), CheckOut=DateTime.Parse("2019-08-11"), Currency="PLN", Price=132.43, Guests=new List<Guest> {context.Guests.First(x=>x.Name == "Paulina")}},

            };

            reservations.ForEach(s => context.Reservations.Add(s));
            context.SaveChanges();
        }
    }
}
