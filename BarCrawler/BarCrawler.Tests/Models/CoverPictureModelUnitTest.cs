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
    class CoverPictureModelUnitTest
    {
        [Test]
        public void ValidateCoverPictureModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new CoverPictureModel()
            {
                BarID = 1,
                Description = "Description goes here",
                Directory = "Picture file path goes here",
                CreateTime = DateTime.Now,
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateCoverPictureModelWithNoBarId_ExpectedNoValidationErrors()
        {
            var model = new CoverPictureModel()
            {
                //BarID = 1,
                Description = "Description goes here",
                Directory = "Picture file path goes here",
                CreateTime = DateTime.Now,
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateCoverPictureModelWithNoDescription_ExpectedNoValidationErrors()
        {
            var model = new CoverPictureModel()
            {
                BarID = 1,
                //Description = "Description goes here",
                Directory = "Picture file path goes here",
                CreateTime = DateTime.Now,
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateCoverPictureModelWithNoDirectory_ExpectedNoValidationErrors()
        {
            var model = new CoverPictureModel()
            {
                BarID = 1,
                Description = "Description goes here",
                //Directory = "Picture file path goes here",
                CreateTime = DateTime.Now,
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        //[Test]
        //public void ValidateCoverPictureModelWithNoCreateTime_ExpectedNoValidationErrors()
        //{
        //    var model = new CoverPictureModel()
        //    {
        //        BarID = 1,
        //        Description = "Description goes here",
        //        Directory = "Picture file path goes here",
        //        //CreateTime = DateTime.Now,
        //    };

        //    var results = ModelUnitTest.TestModelHelper.Validate(model);

        //    Assert.AreEqual(0, results.Count);
        //}
    }
}
