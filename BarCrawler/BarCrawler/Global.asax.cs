using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BarCrawler.Migrations;
using BarCrawler.Models;

namespace BarCrawler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BarCrawlerContext>());
            //Database.SetInitializer(new BarCrawlerContextInitializer(new BarCrawlerContext()));
            //var db = new ApplicationDbContext();
            //db.Database.Initialize(true);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
