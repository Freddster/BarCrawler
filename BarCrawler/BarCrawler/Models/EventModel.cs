using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The EventModel defines all the requirements for a bar in the database.
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Gets or sets the EventID
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        /// <remarks>
        /// This property has a uniquely [Key] tag for identification <see cref="KeyAttribute" />
        /// </remarks>
        /// <seealso cref="KeyAttribute"/>
        [Key]
        public int EventID { get; set; }

        /// <summary>
        /// Gets or sets the BarID.
        /// </summary>
        /// <value>
        /// The bar identifier.
        /// </value>
        /// <remarks>
        /// Has a [ForeignKey] to BarModel <see cref="ForeignKeyAttribute"/>
        /// </remarks>
        /// <seealso cref="ForeignKeyAttribute"/>
        [ForeignKey("BarModel")]
        public int BarID { get; set; }

        /// <summary>
        /// Gets or sets the BarModel.
        /// </summary>
        /// <value>
        /// The bar model.
        /// </value>
        public virtual BarModel BarModel { get; set; }

        /// <summary>
        /// Used for optimistic locking
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        /// <remarks>
        /// The property [Timestamp] defines optimistic locking using <see cref="TimestampAttribute"/>
        /// </remarks>
        /// <seealso cref="TimestampAttribute" />
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the Title for the event.
        /// </summary>
        /// <value>
        /// The title for the event.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [Required]
        [Display(Name = "Event navn")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description for the event.
        /// </summary>
        /// <value>
        /// The description for the event.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag <see cref="MaxLengthAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the time for an event to occur.
        /// </summary>
        /// <value>
        /// The date and time for event.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Tidspunkt for event")]
        public DateTime DateAndTimeForEvent { get; set; }

        /// <summary>
        /// Gets or sets the created time of a feed <br/>
        /// </summary>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br/>
        /// It also has a [Display] tag <see cref="DisplayAttribute"/>
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="DisplayAttribute"/>        //[Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the Address1.
        /// </summary>
        /// <value>
        /// The address 1.
        /// </value>
        /// <remarks>
        /// The property for Address1 is required and is marked with a [Required] tag. <see cref="RequiredAttribute" /><br />
        /// The property also has a [Display] tag <see cref="DisplayAttribute" />
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
        /// The address 2.
        /// </value>
        /// <remarks>
        /// The property only has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="DisplayAttribute"/>
        [Display(Name = "Etage")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the StreetNumber
        /// </summary>
        /// <value>
        /// The street number.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [Required]
        [Display(Name = "Hus nr.")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "By")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Zipcode.
        /// </summary>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br/>
        /// This property is also marked with a [StringLength] tag <see cref ="StringLengthAttribute"/><br/>
        /// It also has a [Display] tag <see cref ="DisplayAttribute"/><br/>
        /// and a [RegularExpression] tag for allowing only 4 numbers <see cref = "RegularExpressionAttribute"/>
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="StringLengthAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        /// <seealso cref="RegularExpressionAttribute"/>
        [Required]
        [StringLength(4)]
        [Display(Name = "Post nr.")]
        [RegularExpression(@"[0-9]{4}$", ErrorMessage = "Post nr. skal være 4 cifre")]
        public string Zipcode { get; set; }
    }
}