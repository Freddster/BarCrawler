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
    class DrinkPictureModelUnitTest
    {
        [Test]
        public void ValidateDrinkPictureModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new DrinkPictureModel()
            {
                DrinkID = 1,
                DrinkPictureID = 1,
                Directory = "Picture file path goes here",
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateDrinkPictureModelWithNoDrinkId_ExpectedNoValidationErrors()
        {
            var model = new DrinkPictureModel()
            {
                //DrinkID = 1,
                DrinkPictureID = 1,
                Directory = "Picture file path goes here",
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateDrinkPictureModelWithNoDrinkPictureId_ExpectedNoValidationErrors()
        {
            var model = new DrinkPictureModel()
            {
                DrinkID = 1,
                //DrinkPictureID = 1,
                Directory = "Picture file path goes here",
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateDrinkPictureModelWithNoDirectory_ExpectedNoValidationErrors()
        {
            var model = new DrinkPictureModel()
            {
                DrinkID = 1,
                DrinkPictureID = 1,
                //Directory = "Picture file path goes here",
            };

            var results = ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }
    }
}
