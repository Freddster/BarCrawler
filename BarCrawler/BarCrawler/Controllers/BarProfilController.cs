﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Configuration;
using DataAccessLogic.UnitOfWork;
using BarCrawler.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace BarCrawler.Controllers
{
    public class BarProfilController : Controller
    {
        BarCrawlerContext db = new BarCrawlerContext();

        private UnitOfWork _unitOfWork = new UnitOfWork();
        // GET: BarProfil


        /* Index */
        /************************* INDEX *******************************/
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barModel = _unitOfWork.GetBarprofile(id);
            if (barModel == null)
            {
                return HttpNotFound();
            }
            return View(barModel);
        }

        /* Kontaktinformation */
        /************************* ÆNDRE KONTAKINFORMATION *******************************/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barmodel = db.BarModels.Include(i => i.Pictures).SingleOrDefault(x => x.BarID == id);
            if (barmodel == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == barmodel.BarName))
            {
                EditViewModel viewModel = barmodel.Pictures.Count > 0
                    ? new EditViewModel(barmodel, barmodel.Pictures[0].Directory)
                    : new EditViewModel(barmodel);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel editviewmodel)
        {
            if (ModelState.IsValid)
            {
                var bar = db.BarModels.FirstOrDefault(m => m.BarID == editviewmodel.BarID);
                if (bar != null)
                {
                    bar.Address1 = editviewmodel.Address1;
                    bar.Address2 = editviewmodel.Address2;
                    bar.PhoneNumber = editviewmodel.PhoneNumber;
                    bar.Zipcode = editviewmodel.Zipcode;
                    bar.Description = editviewmodel.Description;
                    bar.StreetNumber = editviewmodel.StreetNumber;
                    bar.City = editviewmodel.City;
                    bar.Faculty = editviewmodel.Faculty;
                    db.Entry(bar).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return RedirectToAction("Index", new { id = bar.BarID });
            }
            else
            {
                return View(editviewmodel);
            }
        }

        /* Drink */
        /************************* ÆNDRE DRINK *******************************/
        public ActionResult EditDrink(int? id, int? barId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkModel drinkModel = _unitOfWork.DrinkRepository.GetByID(id);
            if (drinkModel == null)
            {
                return HttpNotFound();
            }
            var bm = db.BarModels.Find(barId); 
            if (bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == bm.BarName))
            {
                DrinkViewModel dm = new DrinkViewModel(drinkModel);
                return View(dm);
            }
            return RedirectToAction("BadRequestView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDrink(DrinkViewModel drinkViewModel)
        {
            DrinkModel dm = _unitOfWork.DrinkRepository.GetByID(drinkViewModel.DrinkID);
            if (dm == null)
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                _unitOfWork.DrinkRepository.AddModelForUpdate(ref drinkViewModel, ref dm);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = drinkViewModel.BarID });
            }
            return View(drinkViewModel);
        }


        /************************* SLET DRINK *******************************/
        public ActionResult DeleteDrink(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkModel drink = _unitOfWork.DrinkRepository.GetByID(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            BarModel bm = _unitOfWork.BarRepository.GetBarByID(drink.BarID);
            if (bm == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == bm.BarName))
            {
                _unitOfWork.DrinkRepository.Remove(drink);
                _unitOfWork.Save();
                return RedirectToAction("Index", new {id = bm.BarID});
            }
            return RedirectToAction("BadRequestView");
        }


        /************************* NY DRINK *******************************/
        public ActionResult CreateDrink(int id)
        {
            DrinkViewModel viewModel;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkModel drinkModel = new DrinkModel();
            var bm = db.BarModels.Find(id); 
            if(bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == bm.BarName))
            {
                drinkModel.BarID = id;
                return View(drinkModel);
            }
            return RedirectToAction("BadRequestView");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDrink(DrinkModel drinkmodel)
        {
            if (ModelState.IsValid)
            {
                db.DrinkModels.Add(drinkmodel);
                BarModel barmodel = db.BarModels.Find(drinkmodel.BarID);
                if (barmodel == null)
                {
                    return HttpNotFound();
                }
                barmodel.Drinks.Add(drinkmodel);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = drinkmodel.BarID });
        }

        /* Galleri */
        /************************* NYT BILLEDE *******************************/
        public ActionResult CreatePicture(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PictureModel picture = new PictureModel();
            var bm = db.BarModels.Find(id); 
            if(bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == bm.BarName))
            {
                picture.BarID = id;
                return View(picture);
            }
            return RedirectToAction("BadRequestView");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePicture(PictureModel picture)
        {
            if (ModelState.IsValid)
            {
                picture.CreateTime = DateTime.Now;
                db.PictureModels.Add(picture);
                BarModel barmodel = db.BarModels.Find(picture.BarID);
                if (barmodel == null)
                {
                    return HttpNotFound();
                }
                barmodel.Pictures.Add(picture);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = picture.BarID });
        }

        /************************* SLET BILLEDE *******************************/
        [HttpGet]
        public ActionResult DeletePicture(int id, int Pid/**/)
        {
            var picture = this.db.PictureModels.FirstOrDefault(p => p.PictureID == Pid);
            if (picture != null)
            {
                var bm = db.BarModels.Find(id);
                if (bm == null)
                    return HttpNotFound();
                if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == bm.BarName))
                {
                    db.PictureModels.Remove(picture);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { id = id });
        }

        /************************* ÆNDRE BILLEDE *******************************/
        [HttpGet]
        public ActionResult EditPicture(int id, int Pid/**/)
        {
            var picture = this.db.PictureModels.FirstOrDefault(p => p.PictureID == Pid);
            if (picture == null)
            {
                return HttpNotFound();
            }
            var bm = db.BarModels.Find(id);
            if(bm == null)
                return HttpNotFound();
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserName() == bm.BarName))
            {
                PictureViewModel viewModel = new PictureViewModel(picture);
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPicture(PictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = db.PictureModels.Find(viewModel.PictureID);
                model.Directory = viewModel.Directory;
                model.Description = viewModel.Description; 
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new {id = model.BarID});
            }
            return RedirectToAction("BadRequestView"); 
        }

        /* Feed */
        /************************* NYT FEED *******************************/
        //Virker stadig ikke 
        [HttpGet]
        public ActionResult CreateFeed(int id, string t/**/)
        {
            if (!t.IsNullOrWhiteSpace())
            {
                FeedModel feed = new FeedModel();
                feed.Text = t;
                feed.BarID = id;
                feed.CreateTime = DateTime.Now;
                db.FeedModels.Add(feed);
                db.SaveChanges();
            }

            return RedirectToAction("Index", new { id = id });
        }

        [HttpGet]
        public ActionResult DeleteFeed(int id, int Fid/**/)
        {
            var feed = this.db.FeedModels.FirstOrDefault(b => b.FeedID == Fid);
            if (feed != null)
            {
                db.FeedModels.Remove(feed);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult BadRequestView()
        {
            return View();

        }
    }
}