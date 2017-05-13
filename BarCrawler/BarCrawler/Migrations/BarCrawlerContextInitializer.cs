using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.Migrations
{
    public class BarCrawlerContextInitializer<T> : DropCreateDatabaseAlways<BarCrawlerContext>
    {
        public BarCrawlerContextInitializer()
        {
            Debug.WriteLine("read this\n\n\n\n");
            //Seed(context);
        }

        /**/
        protected override void Seed(BarCrawlerContext context)
        {
            Debug.WriteLine("part 2\n\n\n\n");
            List<BarModel> barModels = new List<BarModel>();
            List<EventModel> eventModels = new List<EventModel>();
            /**/

            barModels.Add(new BarModel()
            {
                Address1 = "Finlandsgade",
                BarID = 1,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "kk@ase.au.dk",
                Faculty = "Ingenør",
                Latitude = 123,
                Longitude = 456,
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200",
                Events = eventModels.FindAll(model => model.BarID == 1)
            });

            eventModels.Add(new EventModel()
            {
                BarID = 1,
                CreateTime = DateTime.Now,
                Description = "Hvem ved ikke hvad beer pong er??",
                Title = "Beer Pong",
                DateAndTimeForEvent = DateTime.Now,
                Address1 = barModels[0].Address1,
                City = barModels[0].City,
                StreetNumber = barModels[0].StreetNumber,
                Zipcode = barModels[0].Zipcode,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            });
            eventModels.Add(new EventModel()
            {
                BarID = 1,
                CreateTime = DateTime.Now,
                Description = "Øl bowling",
                Title = "Øl bowling",
                DateAndTimeForEvent = DateTime.Now,
                Address1 = barModels[0].Address1,
                City = barModels[0].City,
                StreetNumber = barModels[0].StreetNumber,
                Zipcode = barModels[0].Zipcode,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            });

            barModels[0].Events.AddRange(eventModels.FindAll(model => model.BarID == 1));
            barModels.Add(new BarModel()
            {
                Address1 = "Who knows",
                //*BarID = 1,*
                BarName = "Klubben",
                City = "Aarhus N",
                CloseTime = "04:00",
                Description = "Rich kids",
                Email = "rich@kid.com",
                Faculty = "Snobber",
                Latitude = 123,
                Longitude = 456,
                OpenTime = "05:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            });

            foreach (var barModel in barModels)
            {
                context.BarModels.Add(barModel);
            }
            /*foreach (var eventModel in eventModels)
            {
                context.EventModels.Add(eventModel);
            }*/
            //context.BarModels.Add();

            base.Seed(context);
        }
    }
}