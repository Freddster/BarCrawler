using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The PictureModel defines all the requirements for a bar in the database.
    /// </summary>
    public class PictureModel
    {
        /// <summary>
        /// Gets or sets the PictureID.
        /// </summary>
        /// <value>
        /// The picture identifier.
        /// </value>
        /// <remarks>
        /// This property has a uniquely [Key] tag for identification <see cref="KeyAttribute" />
        /// </remarks>
        /// <seealso cref="KeyAttribute" />
        [Key]
        public int PictureID { get; set; }

        /// <summary>
        /// Gets or sets the BarID.
        /// </summary>
        /// <value>
        /// The bar identifier.
        /// </value>
        /// <remarks>
        /// Has a [ForeignKey] to BarModel <see cref="ForeignKeyAttribute" />
        /// </remarks>
        /// <seealso cref="ForeignKeyAttribute" />
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
        /// Gets or sets the Directory for the image.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        /// <remarks>
        /// It also has a a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="DisplayAttribute" />
        [Display(Name= "URL link")]
        public string Directory { get; set; }

        /// <summary>
        /// Used for optimistic locking.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        /// <remarks>
        /// The property [Timestamp] defines optimistic locking using <see cref="TimestampAttribute" />
        /// </remarks>
        /// <seealso cref="TimestampAttribute" />
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the created time of a picture.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Oprettelses tidspunkt")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the description for the picture.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [MaxLength] tag <see cref="MaxLengthAttribute" /><br />
        /// It also has a a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [MaxLength(200)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
    }
}