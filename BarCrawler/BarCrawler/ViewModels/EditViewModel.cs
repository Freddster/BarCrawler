using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    /// <summary>
    /// Viewmodel for the BarModel without the navigational properties
    /// </summary>
    public class EditViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditViewModel"/> class.
        /// </summary>
        public EditViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditViewModel"/> class.
        /// </summary>
        /// <param name="barmodel">The barmodel.</param>
        /// <param name="picture">The picture.</param>
        public EditViewModel(BarModel barmodel, string picture = "http://www.nice.com/PublishingImages/Career%20images/J---HR_Page-4st-strip-green-hair%20(2).png?RenditionID=-1")
        {
            if (barmodel != null)
            {
                BarID = barmodel.BarID;
                Description = barmodel.Description;
                Faculty = barmodel.Faculty;
                PhoneNumber = barmodel.PhoneNumber;
                Address1 = barmodel.Address1;
                Address2 = barmodel.Address2;
                StreetNumber = barmodel.StreetNumber;
                Zipcode = barmodel.Zipcode;
                City = barmodel.City;
                Picture = picture;
                OpenTime = barmodel.OpenTime;
                CloseTime = barmodel.CloseTime;
            }
        }

        /// <summary>
        /// Gets or sets the BarID.
        /// </summary>
        /// <value>
        /// The bar identifier.
        /// </value>
        /// <remarks>
        /// This property has a unique [Key] tag for identification <see cref="KeyAttribute"/>
        /// </remarks>
        /// <seealso cref="KeyAttribute" />
        [Key]
        public int BarID { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag<see cref="MaxLengthAttribute"/><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute"/>
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />

        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Faculty.
        /// </summary>
        /// <value>
        /// The faculty.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute"/>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display]
        public string Faculty { get; set; }


        /// <summary>
        /// Gets or sets the PhoneNumber.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag <see cref="MaxLengthAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/>
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Display(Name = "Telefon Nummer")]
        [MaxLength(8)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the OpenTime for a specific bar.
        /// </summary>
        /// <value>
        /// The open time.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [StringLength(5)]
        [Display(Name = "Åbningstid")]
        public string OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the CloseTime for a specific bar.
        /// </summary>
        /// <value>
        /// The close time.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [StringLength(5)]
        [Display(Name = "Lukketid")]
        public string CloseTime { get; set; }

        //Bar Address
        /// <summary>
        /// Gets or sets the Address1.
        /// </summary>
        /// <value>
        /// The address1.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the Address2.
        /// </summary>
        /// <value>
        /// The address2.
        /// </value>
        /// <remarks>
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// </remarks>
        /// <seealso cref="DisplayAttribute" />
        [Display(Name = "Etage")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the StreetNumber.
        /// </summary>
        /// <value>
        /// The street number.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Hus nr.")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "By")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Zipcode.
        /// </summary>
        /// <value>
        /// The zipcode.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute"/><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute"/><br />
        /// It also has a [RegularExpression] tag for allowing only 8 numbers <see cref="RegularExpressionAttribute"/>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        /// <seealso cref="RegularExpressionAttribute" />
        [Required]
        [StringLength(4)]
        [Display(Name = "Post nr.")]
        [RegularExpression(@"[0-9]{4}$", ErrorMessage = "Post nr. skal være 4 cifre")]
        public string Zipcode { get; set; }


        /// <summary>
        /// Gets or sets the picture directory.
        /// </summary>
        /// <value>
        /// The picture directory.
        /// </value>
        public string Picture { get; set; }
    }
}

