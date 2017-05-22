using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.Models;
using DataAccessLogic.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    public class DrinkModelUnitTest
    {
        [Test]
        public void ValidateDrinkModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            var model = new DrinkModel
            {
                BarModel = new BarModel(),
                BarID = 6,
                Title = "Drink title goes here",
                Description = "Description goes here",
                Price = 22.5
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateDrinkModelWithNoTitle_ExpectedOneValidationErrors()
        {
            var model = new DrinkModel
            { 
                BarModel = new BarModel(),
                BarID = 6,
                //Title = "Drink title goes here",
                Description = "Description goes here",
                Price = 22.5
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateDrinkModelWithNoPrice_ExpectedOneValidationErrors() // Virker ikke endnu
        {
            var model = new DrinkModel
            {
                BarModel = new BarModel(),
                BarID = 6,
                Title = "Drink title goes here",
                Description = "Description goes here",
                Price = 22.5
            };

            var results = Tests.ModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }
    }
}
