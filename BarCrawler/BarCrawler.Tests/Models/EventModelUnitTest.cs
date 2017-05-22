using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    class EventModelUnitTest
    {
        [Test]
        public void ValidateEventModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoAddress1_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                //Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoAddress2_ExpectedNoValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                //Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoBarId_ExpectedNoValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                //BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoCity_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                //City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoDescription_ExpectedNoValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                //Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoStreetNumber_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                //StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoZipcode_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                //Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithTooShortZipcode_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "820",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithTooLongZipcode_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "82000",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void ValidateEventModelWithZipcodeWithLetters_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "82F0",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        //[Test]
        //public void ValidateEventModelWithNoCreateTime_ExpectedOneValidationError()
        //{
        //    var model = new EventModel()
        //    {
        //        Address1 = "Finlandsgade",
        //        Address2 = "1. th",
        //        BarID = 1,
        //        City = "Aarhus N",
        //        Description = "For ingeniøre",
        //        StreetNumber = "22",
        //        Zipcode = "8200",
        //        //CreateTime = DateTime.Now,
        //        DateAndTimeForEvent = DateTime.Now,
        //        Title = "Title for test event",
        //        EventID = 1
        //    };

        //    var results = Tests.BarModelUnitTest.TestModelHelper.Validate(model);

        //    Assert.AreEqual(1, results.Count);
        //}

        //[Test]
        //public void ValidateEventModelWithNoDateAndTimeForEvent_ExpectedOneValidationError()
        //{
        //    var model = new EventModel()
        //    {
        //        Address1 = "Finlandsgade",
        //        Address2 = "1. th",
        //        BarID = 1,
        //        City = "Aarhus N",
        //        Description = "For ingeniøre",
        //        StreetNumber = "22",
        //        Zipcode = "8200",
        //        CreateTime = DateTime.Now,
        //        //DateAndTimeForEvent = DateTime.Now,
        //        Title = "Title for test event",
        //        EventID = 1
        //    };

        //    var results = Tests.BarModelUnitTest.TestModelHelper.Validate(model);

        //    Assert.AreEqual(1, results.Count);
        //}

        [Test]
        public void ValidateEventModelWithNoTitle_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                //Title = "Title for test event",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithEmptyTitle_ExpectedOneValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateEventModelWithTitleBeingOnlyOneCharacterLong_ExpectedNoValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "T",
                EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateEventModelWithNoEventId_ExpectedNoValidationError()
        {
            var model = new EventModel()
            {
                Address1 = "Finlandsgade",
                Address2 = "1. th",
                BarID = 1,
                City = "Aarhus N",
                Description = "For ingeniøre",
                StreetNumber = "22",
                Zipcode = "8200",
                CreateTime = DateTime.Now,
                DateAndTimeForEvent = DateTime.Now,
                Title = "Title for test event",
                //EventID = 1
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }
    }
}
