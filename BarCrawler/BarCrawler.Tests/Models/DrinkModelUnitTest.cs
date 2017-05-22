using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCrawler.DataAccessLogic.UnitOfWork;
using BarCrawler.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    public class DrinkModelUnitTest
    {
        private DrinkModel model;
        private UnitOfWork uow;

        [SetUp]
        public void SetUp()
        {
            model = new DrinkModel();
            uow = new UnitOfWork();
        }

        [Test]
        public void ValidateDrinkModelWithAllRequirements_ExpectedNoValidationErrors()
        {
            model = new DrinkModel
            {
                BarModel = new BarModel(),
                BarID = 6,
                Title = "Den fede drik",
                Description = "Episk drik",
                Price = 22.5
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void ValidateDrinkModelWithNoTitle_ExpectedOneValidationErrors()
        {
            model = new DrinkModel
            { 
                BarModel = new BarModel(),
                BarID = 6,
                //Title = "Den fede drik",
                Description = "Episk drik",
                Price = 22.5
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void ValidateDrinkModelWithNoPrice_ExpectedOneValidationErrors() // Virker ikke endnu
        {
            model = new DrinkModel
            {
                BarModel = new BarModel(),
                BarID = 6,
                Title = "Den fede drik",
                Description = "Episk drik",
                Price = 22.5
            };

            var results = BarModelUnitTest.TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);
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
