namespace HotelSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        PostalCod = c.String(),
                        PhgoneNr = c.String(),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationCode = c.String(nullable: false, maxLength: 10),
                        Created = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        Currency = c.String(nullable: false),
                        Provision = c.Double(),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservationGuest",
                c => new
                    {
                        Reservation_Id = c.Int(nullable: false),
                        Guest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_Id, t.Guest_Id })
                .ForeignKey("dbo.Reservation", t => t.Reservation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Guest", t => t.Guest_Id, cascadeDelete: true)
                .Index(t => t.Reservation_Id)
                .Index(t => t.Guest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationGuest", "Guest_Id", "dbo.Guest");
            DropForeignKey("dbo.ReservationGuest", "Reservation_Id", "dbo.Reservation");
            DropIndex("dbo.ReservationGuest", new[] { "Guest_Id" });
            DropIndex("dbo.ReservationGuest", new[] { "Reservation_Id" });
            DropTable("dbo.ReservationGuest");
            DropTable("dbo.Reservation");
            DropTable("dbo.Guest");
        }
    }
}
