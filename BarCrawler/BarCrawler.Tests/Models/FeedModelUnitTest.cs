using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    class FeedModelUnitTest
    {
        [Test]
        public void ValidateFeedModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new FeedModel()
            {
                BarID = 1,
                FeedID = 1,
                Text = "Text is here",
                CreateTime = DateTime.Now,
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateFeedModelWithNoBarId_ExpectedNoValidationErrors()
        {
            var model = new FeedModel()
            {
                //BarID = 1,
                FeedID = 1,
                Text = "Text is here",
                CreateTime = DateTime.Now,
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateFeedModelWithNoFeedId_ExpectedNoValidationErrors()
        {
            var model = new FeedModel()
            {
                BarID = 1,
                //FeedID = 1,
                Text = "Text is here",
                CreateTime = DateTime.Now,
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateFeedModelWithNoText_ExpectedNoValidationErrors()
        {
            var model = new FeedModel()
            {
                BarID = 1,
                FeedID = 1,
                //Text = "Text is here",
                CreateTime = DateTime.Now,
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateFeedModelWithEmptyText_ExpectedNoValidationErrors()
        {
            var model = new FeedModel()
            {
                BarID = 1,
                FeedID = 1,
                Text = "",
                CreateTime = DateTime.Now,
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        //[Test]
        //public void ValidateFeedModelWithNoCreateTime_ExpectedNoValidationErrors()
        //{
        //    var model = new FeedModel()
        //    {
        //        BarID = 1,
        //        FeedID = 1,
        //        Text = "Text is here",
        //        //CreateTime = DateTime.Now,
        //    };

        //    var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

        //    Assert.AreEqual(0, results.Count);
        //}
    }
}
