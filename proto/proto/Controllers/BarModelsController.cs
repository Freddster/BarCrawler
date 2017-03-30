using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proto.DAL;
using proto.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace proto.Controllers
{
    public class BarModelsController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private BarCrawlerContext db = new BarCrawlerContext();

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: BarModels
        public ActionResult Index()
        {
            return View(unitOfWork.BarRepository.GetAllBars());
            return View(db.BarModels.ToList());
        }


        // GET: BarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barModel = unitOfWork.BarRepository.GetBarByID(id);
            //BarModel barModel = db.BarModels.Find(id);
            if (barModel == null)
            {
                return HttpNotFound();
            }
            return View(barModel);
        }

        // GET: BarModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create(HttpPostedFileBase file, [Bind(Include = "ID,Name,Description,Adresse,TelefonNr,Email,Fakultet,ImageDir,Password,RememberMe")] BarModel barModel)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images"), file.FileName));
                    barModel.ImageDir = System.IO.Path.Combine("~/Images", file.FileName);
                }
                unitOfWork.BarRepository.AddBar(barModel);
                //db.BarModels.Add(barModel);
                unitOfWork.Save();
                //db.SaveChanges();

                var user = new ApplicationUser { UserName = Convert.ToString(barModel.ID), Email = barModel.Email, BarId = barModel.ID};
                var result = await UserManager.CreateAsync(user, barModel.Password);


                

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }


                return RedirectToAction("Index");
            }

            return View(barModel);
        }

        // GET: BarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barModel = unitOfWork.BarRepository.GetBarByID(id);
            //BarModel barModel = db.BarModels.Find(id);
            if (barModel == null)
            {
                return HttpNotFound();
            }
            return View(barModel);
        }

       
        // POST: BarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Adresse,TelefonNr,Email,Fakultet,ImageDir,Password,RememberMe")] BarModel barModel)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BarRepository.UpdateBarModel(barModel);
                unitOfWork.Save();
                //db.Entry(barModel).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barModel);
        }

        // GET: BarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barModel = unitOfWork.BarRepository.GetBarByID(id);
            //BarModel barModel = db.BarModels.Find(id);
            if (barModel == null)
            {
                return HttpNotFound();
            }
            return View(barModel);
        }

        // POST: BarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarModel barModel = unitOfWork.BarRepository.GetBarByID(id);
            unitOfWork.BarRepository.DeleteStudent(barModel.ID);
            unitOfWork.Save();
            return RedirectToAction("Index");

            /*BarModel barModel = db.BarModels.Find(id);
            db.BarModels.Remove(barModel);
            db.SaveChanges();
            return RedirectToAction("Index");*/
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
