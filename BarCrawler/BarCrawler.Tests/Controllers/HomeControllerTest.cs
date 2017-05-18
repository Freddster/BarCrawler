using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarCrawler;
using BarCrawler.Controllers;
using BarCrawler.Models;
using DataAccessLogic.Repositories;
using DataAccessLogic.UnitOfWork;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BarCrawler.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        BarModel bar1 = null;

        List<BarModel> bar = null;
        UnitOfWork uow = null;
        HomeController controller = null;
        DummyBarRepository BarRepo = null;

        [SetUp]
        public void BarControllerTest()
        {
            // Lets create some sample books
            bar1 = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                Latitude = 123,
                Longitude = 456,
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            bar = new List<BarModel>
            {
                bar1
            };

            ////// Lets create our dummy repository
            BarRepo = new DummyBarRepository(bar);
            ////// Let us now create the Unit of work with our dummy repository
            uow = new UnitOfWork(BarRepo);
            ////// Now lets create the BooksController object to test and pass our unit of work
            controller = new HomeController(uow);
        }

        [TestMethod]
        public void IndexWithOneBar_ExpectedTrue()
        {
            // Arrange
            ViewResult result = controller.Index() as ViewResult;
            // Act
            var model = (List<BarModel>)result.ViewData.Model;
            // Assert
            NUnit.Framework.CollectionAssert.Contains(model, bar1);
        }

        [TestMethod]
        public void ContactNotNull_ExpectedTrue()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Contact() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ContactViewBagMessage_ExpectedTrue()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Contact() as ViewResult;
            // Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }
    }
}
