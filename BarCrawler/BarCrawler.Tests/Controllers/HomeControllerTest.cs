using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarCrawler;
using BarCrawler.Controllers;
using BarCrawler.Migrations;
using BarCrawler.Models;
using DataAccessLogic.Repositories;
using DataAccessLogic.UnitOfWork;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BarCrawler.Tests.Controllers
{

    /*******************************************************
     
         READ ME GOD DAMMIT
        læs beskeden i den anden unit test


 ************************************/


    [TestFixture]
    public class HomeControllerTest
    {
        HomeController controller;

        [SetUp]
        public void BarControllerTest()
        {
            Database.SetInitializer(new BarCrawlerContextInitializer<BarCrawlerContext>());
            ////// Now lets create the BooksController object to test and pass our unit of work
            controller = new HomeController();
        }


        [Test]
        public void Index_NotNull_ExpectedTrue()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_TwoBarsInModel_ExpectedTrue()
        {
            // Arrange
            ViewResult result = controller.Index() as ViewResult;
            // Act
            var model = (List<BarModel>)result.ViewData.Model;
            // Assert
            Assert.That(model.Count, Is.EqualTo(2));
        }

        [Test]
        public void Index_OneFeedInModel_ExpectedTrue()
        {
            // Arrange
            ViewResult result = controller.Index() as ViewResult;
            // Act
            var model = (List<BarModel>)result.ViewData.Model;
            // Assert
            Assert.That(model[0].Feeds.Count, Is.EqualTo(1));
        }

        [Test]
        public void Contact_ViewIsCalled_ExpectedTrue()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Contact_ViewBagMessageIsShown_ExpectedMessageMatch()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;
            ;
            // Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }
    }
}
