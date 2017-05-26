using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BarCrawler.Models
{
    /// <summary>
    /// The BarProfilePictureModel defines all the requirements for a bar profile picture in the database.
    /// </summary>
    public class BarProfilePictureModel
    {
        /// <summary>
        /// Primary key for the model, and acts as the foreign key to the Barmodel
        /// </summary>
        /// <value>
        /// The bar identifier.
        /// </value>
        [Key, ForeignKey("BarModel")]
        public int BarID { get; set; }

        /// <summary>
        /// Navigational property to the <see cref="BarModel" />.
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
        /// Gets or sets the CreateTime for the creation of the bar profile picture.
        /// </summary>
        /// <value>
        /// The create time for the profile picture in DateTime format.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [Required]
        [Display(Name = "Oprettelses tidspunkt")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the Directory for the image.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        /// <remarks>
        /// It also has a a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="DisplayAttribute"/>
        [Display(Name = "Profilbillede URL")]
        public string Directory { get; set; }

        /// <summary>
        /// Gets or sets the Description for the bar profile picture.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [MaxLength] tag <see cref="MaxLengthAttribute" /><br />
        /// It also has a a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [MaxLength(200)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

    }
}