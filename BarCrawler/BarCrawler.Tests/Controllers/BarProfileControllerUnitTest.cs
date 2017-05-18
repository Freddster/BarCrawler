using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using BarCrawler.Controllers;
using BarCrawler.Migrations;
using BarCrawler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BarCrawler.Tests.Controllers
{

    /*******************************************************
     
         READ ME GOD DAMMIT
        Forsøg at gå i krig med covertest først og fremmest, hvis der er tid og/eller overskud,
        så kan vi overveje om vi skal lave nogle test på data, men cover tager absolut prioritet.

         
 ************************************/



    [TestFixture]
    public class BarProfileControllerUnitTest
    {
        private BarProfilController controller;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            controller = new BarProfilController();
        }


        [Test]
        public void Index_NotNull_ExpectedTrue()
        {
            // Arrange

            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_IsNotNull_ExpectedTrue()
        {
            // Arrange

            // Act
            ViewResult result = controller.Index(3) as ViewResult;
            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Index_Null_ExpectedBadRequest()
        {
            var result = controller.Index(null) as HttpStatusCodeResult;
            
            Assert.That(result.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void BadRequest_IsNotNull_ExpectedTrue()
        {
            ViewResult result = controller.BadRequestView() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BarLink_UserNotLoggedIn_ThrowException()
        {
            Assert.Throws<NullReferenceException>(() => controller.BarLink());
        }

        [Test]
        public void BarLink_UserLoggedIn_ExpectSomethingWhoKnowWhat()
        {
            //Lav noget med at logge ind som en bruger.
            //Log ind som kk@ase.au.dk
            //Prøv herefter at kalde barlink
            //Hvis det ikke virker, så bare kom ned på værkstedet. Keder mig sikkert ;P
        }
    }
}
