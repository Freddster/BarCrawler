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
using System.IO;
using System.Net.Configuration;
using BarCrawler.DataAccessLogic.UnitOfWork;
using BarCrawler.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace BarCrawler.Controllers
{
    /// <summary>
    /// BarProfilController containing the actions for the bar profile
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BarProfilController : Controller
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private UnitOfWork _unitOfWork = new UnitOfWork();

        #region Index
        /// <summary>
        /// Create an index view with all the relevant bars, and their information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Return the Index view with all Bars.
        /// </returns>
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
        /// <summary>
        /// Creates the feed and returns to the bar profile.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <param name="t">The text to write in the feed.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        [HttpGet]
        public ActionResult CreateFeed(int id, string t)
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

        /// <summary>
        /// Deletes the feed from the database, and returns to the bar profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="FeedId">The feed identifier.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        [HttpGet]
        public ActionResult DeleteFeed(int? id, int? FeedId)
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
        /// <summary>
        /// Creates the event view, with the data from the bar given with the id.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <returns>
        /// Return CreateEvent view.
        /// </returns>
        public ActionResult CreateEvent(int id)
        {
            var bar = _unitOfWork.BarRepository.GetProfile(id);
            if(bar == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            EventModel EventModel = new EventModel();
            EventModel.BarID = id;
            EventModel.Address1 = bar.Address1;
            EventModel.Address2 = bar.Address2;
            EventModel.City = bar.City;
            EventModel.StreetNumber = bar.StreetNumber;
            EventModel.Zipcode = bar.Zipcode;

            return View(EventModel);
        }

        /// <summary>
        /// Creates the event with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="EventModel">The event model.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(EventModel EventModel)
        {
            if (ModelState.IsValid)
            {
                var bar = _unitOfWork.BarRepository.GetByID(EventModel.BarID);
                if (bar == null)
                {
                    return HttpNotFound();
                }

                EventModel.CreateTime = DateTime.Now;
                _unitOfWork.EventRepository.Add(EventModel);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index", new { id = EventModel.BarID });
        }
        #endregion

        #region Edit Event
        /// <summary>
        /// Creates the view for the EditEvent page.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <param name="Eid">The event identifier.</param>
        /// <returns>
        /// Return EditEvent view.
        /// </returns>
        [HttpGet]
        public ActionResult EditEvent(int? id, int? Eid)
        {
            if (id == null || Eid == null)
                return HttpNotFound();
            var _event = _unitOfWork.EventRepository.GetByID(Eid);
            if (_event == null)
            {
                return HttpNotFound();
            }
            var bm = _unitOfWork.BarRepository.GetByID(id);
            if (bm == null)
                return HttpNotFound();
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                EventViewModel viewModel = new EventViewModel(_event);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }

        /// <summary>
        /// Edits the event with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.EventRepository.GetByID(viewModel.EventID);
                _unitOfWork.EventRepository.EditInfo(viewModel, model);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = model.BarID });
            }
            return RedirectToAction("BadRequestView");
        }
        #endregion

        #region Delete Event

        /// <summary>
        /// Deletes the event from the database and redirects to the bar profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="Eid">The event identifier.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        [HttpGet]
        public ActionResult DeleteEvent(int id, int Eid)
        {
            if (Eid == null || id == null)
                return HttpNotFound();
            var _event = _unitOfWork.EventRepository.GetByID(Eid);
            if (_event != null)
            {
                _unitOfWork.EventRepository.Remove(_event);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", new { id = id });
        }
        #endregion

        #endregion

        #region Gallery

        #region Edit Coverbillede

        /// <summary>
        /// Create the view to change the cover picture with.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <returns>
        /// Return EditCoverPicture view.
        /// </returns>
        [HttpGet]
        public ActionResult EditCoverPicture(int id)
        {
            var picture = _unitOfWork.CoverPictureRepository.GetByID(id);
            var bm = _unitOfWork.BarRepository.GetByID(id);
            if (bm == null)
                return HttpNotFound();
            if (picture == null)
            {
                var coverbillede = new CoverPictureModel()
                {
                    CreateTime = DateTime.Now,
                    BarID = bm.BarID,
                    BarModel = bm,
                    Directory = "~/Images/Fingers.png",
                };
                _unitOfWork.CoverPictureRepository.Add(coverbillede);
                _unitOfWork.Save();
            }
            
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                PictureViewModel viewModel = new PictureViewModel(picture);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }


        /// <summary>
        /// Edits the cover picture with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="viewModel">The view model with the data.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCoverPicture(HttpPostedFileBase file, PictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.CoverPictureRepository.GetByID(viewModel.PictureID);
                string[] validExt = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

                if (file != null && file.ContentLength > 0 && validExt.Contains(System.IO.Path.GetExtension(file.FileName)))
                {
                    string filePath = Path.Combine("~/Images",
                        Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

                    file.SaveAs(Server.MapPath(filePath));
                    var ImageDir = filePath;

                   
                    if (model == null)
                        return HttpNotFound();

                    System.IO.File.Delete(Server.MapPath(model.Directory));
                    _unitOfWork.CoverPictureRepository.AddModelForUpdate(ref viewModel, ref model, ImageDir);
                    _unitOfWork.Save();
                    
                }
                return RedirectToAction("Index", new { id = model.BarID });
            }
            return RedirectToAction("BadRequestView");
        }
        #endregion

        #region Edit Profilbillede


        /// <summary>
        /// Create the view to change the profile picture with.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <returns>
        /// Return EditProfilPicture view.
        /// </returns>
        [HttpGet]
        public ActionResult EditProfilPicture(int id)
        {
            var picture = _unitOfWork.BarProfilePictureRepository.GetByID(id);
            var bm = _unitOfWork.BarRepository.GetByID(id);
            if (bm == null)
                return HttpNotFound();
            if (picture == null)
            {
                var profilbillede = new BarProfilePictureModel()
                {
                    CreateTime = DateTime.Now,
                    BarID = id,
                    BarModel = bm,
                    Directory = "~/Images/Fingers.png",
                };
                _unitOfWork.BarProfilePictureRepository.Add(profilbillede);
                _unitOfWork.Save();
            }
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                PictureViewModel viewModel = new PictureViewModel(picture);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }


        /// <summary>
        /// Edits the profile picture with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfilPicture(HttpPostedFileBase file, PictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.BarProfilePictureRepository.GetByID(viewModel.PictureID);
                string[] validExt = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

                if (file != null && file.ContentLength > 0 && validExt.Contains(Path.GetExtension(file.FileName)))
                {
                    string filePath = Path.Combine("~/Images",
                        Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
                    
                    file.SaveAs(Server.MapPath(filePath));
                    var ImageDir = filePath;

                    
                    if (model == null)
                        return HttpNotFound();

                    System.IO.File.Delete(Server.MapPath(model.Directory));

                    _unitOfWork.BarProfilePictureRepository.AddModelForUpdate(ref viewModel, ref model, ImageDir);
                    _unitOfWork.Save();
                   }
                return RedirectToAction("Index", new { id = model.BarID });
            }
            return RedirectToAction("BadRequestView");
        }
        #endregion

        #region Create Picture
        /// <summary>
        /// Create the view to add a picture with.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Return CreatePicture view.
        /// </returns>
        public ActionResult CreatePicture(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PictureModel picture = new PictureModel();
            var bm = _unitOfWork.BarRepository.GetByID(id);
            if (bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                picture.BarID = id;
                return View(picture);
            }
            return RedirectToAction("BadRequestView");

        }

        /// <summary>
        /// Create a picture with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="picture">The picture model with the data.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePicture(HttpPostedFileBase file, PictureModel picture)
        {

            if (ModelState.IsValid)
            {
                string[] validExt = new[] {".png", ".jpg", ".jpeg", ".gif", ".bmp"};

                if (file != null && file.ContentLength > 0 && validExt.Contains(System.IO.Path.GetExtension(file.FileName)))
                {
                    string filePath = Path.Combine("~/Images",
                        Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

                    file.SaveAs(Server.MapPath(filePath));

                    picture.Directory = filePath;
                    picture.CreateTime = DateTime.Now;
                    _unitOfWork.PictureRepository.Add(picture);
                    BarModel barModel = _unitOfWork.BarRepository.GetByID(picture.BarID);
                    if (barModel == null)
                    {
                        return HttpNotFound();
                    }
                    barModel.Pictures.Add(picture);
                    _unitOfWork.Save();
                }

            }
            return RedirectToAction("Index", new { id = picture.BarID });
        }
        #endregion

        #region Edit Picture
        /// <summary>
        /// Create the view to change the picture with.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <param name="Pid">The picture identifier.</param>
        /// <returns>
        /// Return CreatePicture view.
        /// </returns>
        [HttpGet]
        public ActionResult EditPicture(int id, int Pid)
        {
            var picture = _unitOfWork.PictureRepository.GetByID(Pid);
            if (picture == null)
            {
                return HttpNotFound();
            }
            var bm = _unitOfWork.BarRepository.GetByID(id);
            if (bm == null)
                return HttpNotFound();
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                PictureViewModel viewModel = new PictureViewModel(picture);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }

        /// <summary>
        /// Edits the picture with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPicture(PictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.PictureRepository.GetByID(viewModel.PictureID);
                _unitOfWork.PictureRepository.AddModelForUpdate(ref viewModel, ref model);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = model.BarID });

            }
            return RedirectToAction("BadRequestView");
        }
        #endregion

        #region Delete Picture

        /// <summary>
        /// Deletes the picture from the database, and redirect to the bar profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="Pid">The pid.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        [HttpGet]
        public ActionResult DeletePicture(int id, int Pid/**/)
        {
            var picture = _unitOfWork.PictureRepository.GetByID(Pid);
            if (picture != null)
            {
                var bm = _unitOfWork.BarRepository.GetByID(id);
                if (bm == null)
                    return HttpNotFound();
                if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
                {
                    System.IO.File.Delete(Server.MapPath(picture.Directory));
                    _unitOfWork.PictureRepository.Remove(picture);
                    _unitOfWork.Save();
                }
            }
            return RedirectToAction("Index", new { id = id });
        }

        #endregion

        #endregion

        #region Contact Information

        #region Edit Contact Information
        /// <summary>
        /// Create the view to change the contact information.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <returns>
        /// Return Edit view.
        /// </returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barModel = _unitOfWork.BarRepository.GetEditInfo(id);
            if (barModel == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == barModel.userID))
            {
                EditViewModel viewModel = barModel.BarProfilePicture != null
                    ? new EditViewModel(barModel, barModel.BarProfilePicture.Directory)
                    : new EditViewModel(barModel);
                return View(viewModel);
            }
            return RedirectToAction("BadRequestView");
        }

        /// <summary>
        /// Edits the contact information with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="editviewmodel">The editviewmodel with the data to change to.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel editviewmodel)
        {
            if (ModelState.IsValid)
            {
                var bar = _unitOfWork.BarRepository.GetByID(editviewmodel.BarID);
                if (bar != null)
                {
                    _unitOfWork.BarRepository.EditInfo(editviewmodel, bar);
                    _unitOfWork.Save();
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
        /// <summary>
        /// Create the view to add a drink to the database.
        /// </summary>
        /// <param name="id">The bar identifier.</param>
        /// <returns>
        /// Return CreateDrink view
        /// </returns>
        public ActionResult CreateDrink(int id)
        {
            DrinkModel drinkModel = new DrinkModel();
            var bm = _unitOfWork.BarRepository.GetByID(id);
            if (bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                drinkModel.BarID = id;
                return View(drinkModel);
            }
            return RedirectToAction("BadRequestView");

        }

        /// <summary>
        /// Adds the drink with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="drinkmodel">The drinkmodel.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDrink(DrinkModel drinkmodel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DrinkRepository.Add(drinkmodel);
                BarModel barmodel = _unitOfWork.BarRepository.GetByID(drinkmodel.BarID);
                if (barmodel == null)
                {
                    return HttpNotFound();
                }
                barmodel.Drinks.Add(drinkmodel);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index", new { id = drinkmodel.BarID });
        }
        #endregion

        #region Edit Drink
        /// <summary>
        /// Create the view to change a drink in the database.
        /// </summary>
        /// <param name="id">The drink identifier.</param>
        /// <param name="barId">The bar identifier.</param>
        /// <returns>
        /// Return EditDrink view
        /// </returns>
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
            var bm = _unitOfWork.BarRepository.GetByID(barId);
            if (bm == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (User.Identity.IsAuthenticated && (User.Identity.GetUserId() == bm.userID))
            {
                DrinkViewModel dm = new DrinkViewModel(drinkModel);
                return View(dm);
            }
            return RedirectToAction("BadRequestView");
        }

        /// <summary>
        /// Edits the drink with the data entered, and saves it to the database and redirects to the bar profile.
        /// </summary>
        /// <param name="drinkViewModel">The drink view model.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
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
        /// <summary>
        /// Deletes the drink from the database and redirects to the bar profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Redirect to the bar profile index.
        /// </returns>
        public ActionResult DeleteDrink(int id)
        {
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
        /// <summary>
        /// View for bad requests, for when useres don't have permissions to access certain pages.
        /// </summary>
        /// <returns>
        /// Return BadRequest view.
        /// </returns>
        public ActionResult BadRequestView()
        {
            return View();
        }
        #endregion

        /************************* Link oppe i toppen *******************************/
        #region BarLink
        /// <summary>
        /// Gets the bars id, and redirect to the bar profile
        /// </summary>
        /// <returns>
        /// Redirect to bar profile index.
        /// </returns>
        [HttpGet]
        public ActionResult BarLink()
        {
            var UserId = User.Identity.GetUserId();

            var bar = _unitOfWork.BarRepository.GetByUserID(UserId);
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


/* [HttpGet]
        public ActionResult EditProfilPicture(int id)
        {
            var bar = _unitOfWork.BarRepository.GetByUserID(id.ToString());
            if (bar.BarProfilPictureModel == null)
            {
                BarProfilPictureModel profil = new BarProfilPictureModel();
                profil.BarID = id; 
                profil.CreateTime = DateTime.Now;
                profil.Directory = "http://www.nice.com/PublishingImages/Career%20images/J---HR_Page-4st-strip-green-hair%20(2).png?RenditionID=-1"; 
                profil.BarModel = bar;
                bar.BarProfilPictureModel = profil;
                _unitOfWork.Save(); 
            }
            var picture = _unitOfWork.BarProfilPictureRepository.GetByID(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            var bm = _unitOfWork.BarRepository.GetByID(id);
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
        public ActionResult EditProfilPicture(PictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _unitOfWork.BarProfilPictureRepository.GetByID(viewModel.BarID);
                _unitOfWork.BarProfilPictureRepository.AddModelForUpdate(ref viewModel, ref model);
                _unitOfWork.Save();
                return RedirectToAction("Index", new { id = model.BarID });

            }
            return RedirectToAction("BadRequestView");
        }
*/
