using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using BarCrawler.Models;
using NUnit.Framework;

namespace BarCrawler.Tests.Models
{
    [TestFixture]
    class DrinkModelUnitTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        //    [Test]
        //    public void ValidateDrinkModel_DrinkModel_NoError()
        //    {
        //        DrinkModel _uut = new DrinkModel();
        //        _uut.Title = "Katrines";

        //        var validationResult = ValidationHelper.
        //    }
        //}

        //public class EntityValidationResult
        //{
        //    public IList<validationresult> Errors { get; private set; }
        //    public bool HasError
        //    {
        //        get { return Errors.Count > 0; }
        //    }

        //    public EntityValidationResult(IList<validationresult> errors = null)
        //    {
        //        Errors = errors ?? new List<validationresult>();
        //    }
        //}

        //public class EntityValidator<t> where T : class
        //{
        //    public EntityValidationResult Validate(T entity)
        //    {
        //        var validationResults = new List<validationresult>();
        //        var vc = new ValidationContext(entity, null, null);
        //        var isValid = Validator.TryValidateObject
        //                (entity, vc, validationResults, true);

        //        return new EntityValidationResult(validationResults);
        //    }
        //}

        //public class ValidationHelper
        //{
        //    public static EntityValidationResult ValidateEntity<t>(T entity)
        //        where T : class
        //    {
        //        return new EntityValidator<t>().Validate(entity);
        //    }
        //}
    }
}
