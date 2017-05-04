using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using System.Net;
using DataAccessLogic.UnitOfWork;

namespace BarCrawler.Controllers
{

    
    public class BarProfilController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: BarProfil
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
    }
}