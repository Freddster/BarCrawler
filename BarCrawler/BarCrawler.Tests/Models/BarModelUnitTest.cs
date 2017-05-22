using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    public class BarModelUnitTest
    {
        private BarModel model;

        [SetUp]
        public void SetUp()
        {
            model = new BarModel();
        }

        [Test]
        public void ValidateBarModelWithNonAndRequirements_ExpectedNoValidationErrors()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                Address2 = "Præstegården",
                Longitude = 123,
                Latitude = 345,
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
                //Events = new List<EventModel>( new EventModel() {} ) )
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoAddress1_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                //Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoBarName_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                //BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoCity_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                //City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoCloseTimeOrOpenTime_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                //CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                //OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoDescription_ExpectedNoValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                //Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoEmail_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                //Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoFaculty_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                //Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoPhoneNumber_ExpectedNoValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                //PhoneNumber = "12345678",
                StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoStreetNumber_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                //StreetNumber = "2",
                Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoZipcode_ExpectedOneValidationError()
        {
            model = new BarModel
            {
                Address1 = "Finlandsgade",
                BarID = 6,
                BarName = "Katrines Kælder",
                City = "Aarhus N",
                CloseTime = "02:00",
                Description = "For ingeniøre",
                Email = "hej@mail.dk",
                Faculty = "Ingenør",
                OpenTime = "13:00",
                PhoneNumber = "12345678",
                StreetNumber = "2",
                //Zipcode = "8200"
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }


        public class TestModelHelper
        {
            public static IList<ValidationResult> Validate(object model)
            {
                var results = new List<ValidationResult>();
                var validationContext = new ValidationContext(model, null, null);
                Validator.TryValidateObject(model, validationContext, results, true);
                if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
                return results;
            }
        }
    }
}
