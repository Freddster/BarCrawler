using System;
using System.Activities.Expressions;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarCrawler;
using BarCrawler.Controllers;
using BarCrawler.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace BarCrawler.Tests.Models
{
    [TestFixture]
    public class BarModelUnitTest
    {
        [Test]
        public void ValidateBarModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoAddress1_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoBarName_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoCity_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoCloseTimeOrOpenTime_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoDescription_ExpectedNoValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoEmail_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoFaculty_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoPhoneNumber_ExpectedNoValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateBarModelWithTooShortPhoneNumber_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                PhoneNumber = "1234567",
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithTooLongPhoneNumber_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                PhoneNumber = "123456789",
                StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoStreetNumber_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                //StreetNumber = "22",
                Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithNoZipcode_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                //Zipcode = "8200"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithTooShortZipcode_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "820"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateBarModelWithTooLongZipcode_ExpectedOneValidationError()
        {
            var model = new BarModel
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
                StreetNumber = "22",
                Zipcode = "82000"
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(2, results.Count);
        }
    }
}
