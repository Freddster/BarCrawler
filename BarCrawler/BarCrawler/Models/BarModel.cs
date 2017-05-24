using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The BarModel defines all the requirements for a bar in the database.
    /// </summary>
    public class BarModel
    {
        /// <summary>
        /// Gets or sets the BarID.
        /// </summary>
        /// <value>
        /// The bar identifier.
        /// </value>
        /// <remarks>
        /// This property has a unique [Key] tag for identification <see cref="KeyAttribute">Keyattribute</see>
        /// </remarks>
        /// <seealso cref="KeyAttribute" />
        [Key]
        public int BarID { get; set; }

        /// <summary>
        /// Used for optimistic locking.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        /// <remarks>
        /// The property [Timestamp] defines optimistic locking using <see cref="TimestampAttribute"/>
        /// </remarks>
        /// <seealso cref="TimestampAttribute"/>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the BarName.
        /// </summary>
        /// <value>
        /// The name of the bar.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is marked with a [MaxLength] tag <see cref="MaxLengthAttribute">Maxlengthattribute</see><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute">Displayattribute</see>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="MaxLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [MaxLength(50)]
        [Display(Name = "Bar navn")]
        public string BarName { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag<see cref="MaxLengthAttribute"> Maxlengthattribute </see><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute">Displayattribute</see>
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// it is also marked with a [EmailAddress] tag <see cref="EmailAddressAttribute"></see><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute">Displayattribute</see>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="EmailAddressAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Faculty.
        /// </summary>
        /// <value>
        /// The faculty.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute">Displayattribute</see>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Studieretning")]
        public string Faculty { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        /// <remarks>
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute">Stringlengthattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
        /// It also has a [RegularExpression] tag for allowing only 8 numbers <see cref="RegularExpressionAttribute">Regularexpressionattrbute</see>
        /// </remarks>
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        /// <seealso cref="RequiredAttribute" />
        [StringLength(8)]
        [Display(Name = "Telefon nr.")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Telefon nr. skal være 8 cifre")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the OpenTime for a specific bar.
        /// </summary>
        /// <value>
        /// The open time.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute">Stringlengthattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
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
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute">Stringlengthattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [StringLength(5)]
        [Display(Name = "Lukketid")]
        public string CloseTime { get; set; }

        /// <summary>
        /// Gets or sets the Address1.
        /// </summary>
        /// <value>
        /// The address1.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
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
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
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
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
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
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
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
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute">Requiredattribute</see><br />
        /// This property is marked with a [StringLength] tag <see cref="StringLengthAttribute">Stringlengthattribute</see><br />
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute">Displayattribute</see><br />
        /// It also has a [RegularExpression] tag for allowing only 8 numbers <see cref="RegularExpressionAttribute">Regularexpressionattrbute</see>
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
        /// Gets or sets the Longitude to calculate a destination.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the Latitude to calculate a destination.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; set; }


        /// <summary>
        /// Gets or sets the drinks.
        /// </summary>
        /// <value>
        /// Navigational property to <see cref="DrinkModel" />.
        /// </value>
        /// <seealso cref="DrinkModel" />
        public virtual List<DrinkModel> Drinks { get; set; }    //Overvej at bruge et Dictionary til at gemme i. Burg evt. navn på drink som key

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// Navigational property to <see cref="EventModel" />.
        /// </value>
        /// <seealso cref="EventModel" />
        public virtual List<EventModel> Events { get; set; }    //Overvej at bruge et Dictionary til at gemme i. Brug evt. dato + tid for hvornår event finder sted, for som key til at gemme i dictionary 

        /// <summary>
        /// Gets or sets the feeds.
        /// </summary>
        /// <value>
        /// Navigational property to <see cref="FeedModel" />.
        /// </value>
        /// <seealso cref="FeedModel" />
        public virtual List<FeedModel> Feeds { get; set; }      //Overvej at bruge et Dictionary til at gemme i. Burg evt. tidspunkt for oprettelse som key
        
        /// <summary>
        /// Gets or sets the pictures.
        /// </summary>
        /// <value>
        /// Navigational property to <see cref="PictureModel"/>.
        /// </value>
        /// <seealso cref="PictureModel"/>
        public virtual List<PictureModel> Pictures { get; set; }

        /// <summary>
        /// Gets or sets the bar profil picture.
        /// </summary>
        /// <value>
        /// Navigational property to <see cref="BarProfilePictureModel"/>.
        /// </value>
        /// <seealso cref="BarProfilePictureModel"/>    
        public virtual BarProfilePictureModel BarProfilePicture { get; set; }
        
        /// <summary>
        /// Gets or sets the cover picture.
        /// </summary>
        /// <value>
        /// Navigational property to <see cref="CoverPictureModel"/>.
        /// </value>
        /// <seealso cref="CoverPictureModel"/>
        public virtual CoverPictureModel CoverPicture { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string userID { get; set; }

        /// <summary>
        /// The application user.
        /// </summary>
        public ApplicationUser ApplicationUser;
    }

}