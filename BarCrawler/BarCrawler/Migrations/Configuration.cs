using BarCrawler.Models;
using Microsoft.Ajax.Utilities;

namespace BarCrawler.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BarCrawler.Models.BarCrawlerContext>
    {
        private readonly bool _pendingMigrations;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

           /* var migrator = new DbMigrator(this);
            _pendingMigrations = migrator.GetPendingMigrations().Any();
            //_pendingMigrations = migrator.

            if (_pendingMigrations)
            {
                migrator.Update();
                
            }*/
            //Seed(new BarCrawlerContext());
        }

        protected override void Seed(BarCrawler.Models.BarCrawlerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //DropCreateDatabaseAlways<BarCrawlerContext> sAlways context = new BarCrawlerContext();

            /*context.BarModels.AddOrUpdate(
                b => b.BarID, new BarModel {Address1 = "kajsd",
                    Address2 = "sdsff",
                    BarID = 1,
                    BarName = "Katrines kælder",
                    City = "dsfs",
                    CloseTime = "12:00",
                    Description = "Engineering bitch",
                    Email = "kk@add.dk",
                    Faculty = "dsfd",
                    Latitude = 123,
                    Longitude = 145,
                    OpenTime = "15:00",
                    PhoneNumber = "12346578",
                    StreetNumber = "123",
                    Zipcode = "1234"}, 
                new BarModel() {
                        Address1 = "lkj",
                        Address2 = "sdsff",
                        BarID = 2,
                        BarName = "poupj",
                        City = "dsfs",
                        CloseTime = "12:00",
                        Description = "lhk",
                        Email = "dsfsd@add.dk",
                        Faculty = "dsfd",
                        Latitude = 123,
                        Longitude = 145,
                        OpenTime = "15:00",
                        PhoneNumber = "12346578",
                        StreetNumber = "123",
                        Zipcode = "1234"
                    });
            context.SaveChanges();
            base.Seed(context);*/
        }
    }
}
