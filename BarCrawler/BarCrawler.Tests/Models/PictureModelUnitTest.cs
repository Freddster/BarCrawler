using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    class PictureModelUnitTest
    {
        [Test]
        public void ValidatePictureModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new PictureModel()
            {
                BarID = 1,
                PictureID = 1,
                Directory = "Filepath goes here",
                CreateTime = DateTime.Now,
                Description = "Description goes here"
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidatePictureModelWithNoBarId_ExpectedNoValidationErrors()
        {
            var model = new PictureModel()
            {
                //BarID = 1,
                PictureID = 1,
                Directory = "Filepath goes here",
                CreateTime = DateTime.Now,
                Description = "Description goes here"
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidatePictureModelWithNoPictureId_ExpectedNoValidationErrors()
        {
            var model = new PictureModel()
            {
                BarID = 1,
                //PictureID = 1,
                Directory = "Filepath goes here",
                CreateTime = DateTime.Now,
                Description = "Description goes here"
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidatePictureModelWithNoDirectory_ExpectedNoValidationErrors()
        {
            var model = new PictureModel()
            {
                BarID = 1,
                PictureID = 1,
                //Directory = "Filepath goes here",
                CreateTime = DateTime.Now,
                Description = "Description goes here"
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        //[Test]
        //public void ValidatePictureModelWithNoCreateTime_ExpectedNoValidationErrors()
        //{
        //    var model = new PictureModel()
        //    {
        //        BarID = 1,
        //        PictureID = 1,
        //        Directory = "Filepath goes here",
        //        //CreateTime = DateTime.Now,
        //        Description = "Description goes here"
        //    };

        //    var results = ModelUnitTest.TestModelHelper.Validate(model);

        //    Assert.AreEqual(0, results.Count);
        //}

        [Test]
        public void ValidatePictureModelWithNoDescription_ExpectedNoValidationErrors()
        {
            var model = new PictureModel()
            {
                BarID = 1,
                PictureID = 1,
                Directory = "Filepath goes here",
                CreateTime = DateTime.Now,
                //Description = "Description goes here"
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }
    }
}
