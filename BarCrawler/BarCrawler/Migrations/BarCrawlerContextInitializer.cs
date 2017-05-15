﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BarCrawler.Controllers;
using BarCrawler.Models;
using BarCrawler.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;


namespace BarCrawler.Migrations
{
    public class BarCrawlerContextInitializer<T> : DropCreateDatabaseAlways<BarCrawlerContext>
    {
        public BarCrawlerContextInitializer()
        {
            Debug.WriteLine("read this\n\n\n\n");
            //Seed(context);
        }


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager { get; set; }


        /**/
        protected override void Seed(BarCrawlerContext context)
        {
            Debug.WriteLine("part 2\n\n\n\n");
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();
            List<BarModel> barModels = new List<BarModel>();
            List<EventModel> eventModels = new List<EventModel>();
            List<DrinkModel> drinkModels = new List<DrinkModel>();
            BarProfilPictureModel barProfilPictureModels;
            List<PictureModel> pictureModels = new List<PictureModel>();


            var user = new ApplicationUser { UserName ="kk@ase.au.dk", Email = "kk@ase.au.dk" };
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>());
            var result = UserManager.Create(user, "qwertY1!");

            if (result.Succeeded)
                Debug.WriteLine("Shit succeeded\n\n\n\n");

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
                userID = user.Id,
                Events = eventModels.FindAll(model => model.BarID == 1),
                Drinks = drinkModels.FindAll(model => model.BarID == 1),
                Pictures = pictureModels.FindAll(model => model.BarID == 1)
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

            drinkModels.Add(new DrinkModel()
            {
                Title = "Blå Batman",
                Price = 40,
                Description = "Den er blå...",
                BarID = 1,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            });
            drinkModels.Add(new DrinkModel()
            {
                Title = "Spejlæg",
                Price = 60,
                Description = "Den smager som slik, og kommer i en kande",
                BarID = 1,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            });

            barProfilPictureModels = new BarProfilPictureModel()
            {
                Description = "Det er vores logo",
                CreateTime = DateTime.Now,
                Directory = "https://d30y9cdsu7xlg0.cloudfront.net/png/34710-200.png",
                BarID = 1,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            };

            pictureModels.Add(new PictureModel()
            {
                Description = "Pænt billede",
                CreateTime = DateTime.Now,
                Directory = "https://www.iconexperience.com/_img/o_collection_png/green_dark_grey/512x512/plain/engineer.png",
                BarID = 1,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            });
            pictureModels.Add(new PictureModel()
            {
                Description = "Meget pænt billede",
                CreateTime = DateTime.Now,
                Directory = "https://0.s3.envato.com/files/100272724/code%20background.jpg",
                BarID = 1,
                BarModel = barModels.Find(b => b.BarName == "Katrines Kælder")
            });

            barModels[0].Events.AddRange(eventModels.FindAll(model => model.BarID == 1));
            barModels[0].Drinks.AddRange(drinkModels.FindAll(model => model.BarID == 1));
            barModels[0].ProfilPictureModel = barProfilPictureModels;
            List<PictureModel> pm = new List<PictureModel>();
            pm.AddRange(pictureModels.FindAll(model => model.BarID == 1));
            barModels[0].Pictures.AddRange(pm);


            barModels.Add(new BarModel()
            {
                Address1 = "Who knows",
                BarID = 2,
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
            

            base.Seed(context);
            //SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        }
    }
}