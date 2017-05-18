using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
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

        #region Index
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
        #endregion
        #region Feed
        #region Create Feed
        [HttpGet]
        public ActionResult CreateFeed(int id, string t/**/)
        {
            if (!t.IsNullOrWhiteSpace())
            {
                FeedModel feed = new FeedModel();
                feed.Text = t;
                feed.BarID = id;
                feed.CreateTime = DateTime.Now;
                _unitOfWork.FeedRepository.Add(feed);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index", new { id = id });
        }
        #endregion
        #region Delete Feed

        [HttpGet]
        public ActionResult DeleteFeed(int? id, int? FeedId /**/)
        {
            var feed = _unitOfWork.FeedRepository.GetByID(FeedId);
            if (feed != null)
            {
                _unitOfWork.FeedRepository.Remove(feed);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", new { id = id });
        }
        #endregion
        #endregion
        #region Events
        
        #region Create Event
        public ActionResult CreateEvent(int id)
        {
            var bar = _unitOfWork.BarRepository.GetProfile(id);
            EventModel EventModel = new EventModel();
            EventModel.BarID = id;
            EventModel.Address1 = bar.Address1;
            EventModel.Address2 = bar.Address2;
            EventModel.City = bar.City;
            EventModel.StreetNumber = bar.StreetNumber;
            EventModel.Zipcode = bar.Zipcode;

            return View(EventModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(EventModel EventModel)
        {
            var bar = _unitOfWork.BarRepository.GetByID(EventModel.BarID);
            if (bar == null)
            {
                return HttpNotFound();
            }

            EventModel.CreateTime = DateTime.Now;
            _unitOfWork.EventRepository.Add(EventModel);
            _unitOfWork.Save();

            return RedirectToAction("Index", new { id = EventModel.BarID });
        }
        #endregion

        #region Ændre Event
        [HttpGet]
        public ActionResult EditEvent(int id, int Eid)
        {
            if(id == null || Eid == null)
                return HttpNotFound();
            var _event = this.db.EventModels.Find(Eid);
            if (_event == null)
            {
                return HttpNotFound();
            }
            var bm = db.BarModels.Find(id);
            if (bm == null)
                return HttpNotFound();
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                EventViewModel viewModel = new EventViewModel(_event);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = db.EventModels.Find(viewModel.EventID);
                model.Title = viewModel.Title;
                model.Description = viewModel.Description;
                model.DateAndTimeForEvent = viewModel.DateAndTimeForEvent;
                model.Address1 = viewModel.Address1;
                model.Address2 = viewModel.Address2;
                model.StreetNumber = viewModel.StreetNumber;
                model.City = viewModel.City;
                model.Zipcode = viewModel.Zipcode;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = model.BarID });
            }
            return RedirectToAction("BadRequestView");
        }
        #endregion

        #region Slet Event
        [HttpGet]
        public ActionResult DeleteEvent(int id, int Eid /**/)
        {
            if(Eid == null || id == null)
                return HttpNotFound();
            var _event = this.db.EventModels.Find(Eid);
            if (_event != null)
            {
                db.EventModels.Remove(_event);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = id });
        }
        #endregion

        #endregion
        #region Gallery
        #region Create Picture
        public ActionResult CreatePicture(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PictureModel picture = new PictureModel();
            var bm = _unitOfWork.BarRepository.GetByID(id);
            //var bm = db.BarModels.Find(id);
            if (bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
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
                _unitOfWork.PictureRepository.Add(picture);
                //db.PictureModels.Add(picture);
                //BarModel barmodel = db.BarModels.Find(picture.BarID);
                BarModel barModel = _unitOfWork.BarRepository.GetByID(picture.BarID);
                if (barModel == null)
                {
                    return HttpNotFound();
                }
                barModel.Pictures.Add(picture);
                _unitOfWork.Save();
                //db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = picture.BarID });
        }
        #endregion

        
        #region Change Picture
        [HttpGet]
        public ActionResult EditPicture(int id, int Pid/**/)
        {
            //var picture = this.db.PictureModels.FirstOrDefault(p => p.PictureID == Pid);
            var picture = _unitOfWork.PictureRepository.GetByID(Pid);
            if (picture == null)
            {
                return HttpNotFound();
            }
            var bm = _unitOfWork.BarRepository.GetByID(id);
            //var bm = db.BarModels.Find(id);
            if (bm == null)
                return HttpNotFound();
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                PictureViewModel viewModel = new PictureViewModel(picture);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPicture(PictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //var model = db.PictureModels.Find(viewModel.PictureID);
                var model = _unitOfWork.PictureRepository.GetByID(viewModel.PictureID);
                _unitOfWork.PictureRepository.AddModelForUpdate(ref viewModel, ref model);
                _unitOfWork.Save();
                //db.SaveChanges();
                return RedirectToAction("Index", new { id = model.BarID });
            }
            return RedirectToAction("BadRequestView");
        }
        #endregion


        #region Delete Picture

        [HttpGet]
        public ActionResult DeletePicture(int id, int Pid/**/)
        {
            //var picture = this.db.PictureModels.FirstOrDefault(p => p.PictureID == Pid);
            var picture = _unitOfWork.PictureRepository.GetByID(Pid);
            if (picture != null)
            {
                //var bm = db.BarModels.Find(id);
                var bm = _unitOfWork.BarRepository.GetByID(id);
                if (bm == null)
                    return HttpNotFound();
                if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
                {
                    _unitOfWork.PictureRepository.Remove(picture);
                    _unitOfWork.Save();
                    //db.PictureModels.Remove(picture);
                    //db.SaveChanges();
                }
            }
            return RedirectToAction("Index", new { id = id });
        }

        #endregion
        
        #endregion
        #region Contact Information
        #region Change Contact Information
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
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == barmodel.userID))
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
        #endregion
        #endregion
        #region Drink
        
        #region Create Drink
        public ActionResult CreateDrink(int id)
        {
            DrinkViewModel viewModel;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkModel drinkModel = new DrinkModel();
            var bm = db.BarModels.Find(id);
            if (bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
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
        #endregion

        
        #region Change Drink
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
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
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
        #endregion

        
        #region Delete Drink
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
            BarModel bm = _unitOfWork.BarRepository.GetByID(drink.BarID);
            if (bm == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                _unitOfWork.DrinkRepository.Remove(drink);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = bm.BarID });
            }
            return RedirectToAction("BadRequestView");
        }
        #endregion

        #endregion
        #region Diverse
        
        #region Bad Request
        public ActionResult BadRequestView()
        {
            return View();

        }
        #endregion
        
        /************************* Link oppe i toppen *******************************/
        #region BarLink
        [HttpGet]
        public ActionResult BarLink()
        {
            var UserId = User.Identity.GetUserId();

            var bar = db.BarModels.SingleOrDefault(b => b.userID == UserId);

            if (bar == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", new { id = bar.BarID });
        }
        #endregion
        #endregion
    }
}