using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BarCrawler.Models
{
    /// <summary>
    /// The DrinkPictureModel defines all the requirements for a drink in the database.
    /// </summary>
    public class DrinkPictureModel
    {
        /// <summary>
        /// Gets or sets the DrinkPictureID. <br />
        /// </summary>
        /// <value>
        /// The drink picture identifier.
        /// </value>
        /// <seealso cref="KeyAttribute" />
        [Key]
        public int DrinkPictureID { get; set; }

        /// <summary>
        /// Gets or sets the DrinkID.
        /// </summary>
        /// <value>
        /// The drink identifier.
        /// </value>
        /// <remarks>
        /// Has a [ForeignKey] to DrinkModel <see cref="ForeignKeyAttribute" />
        /// </remarks>
        /// <seealso cref="ForeignKeyAttribute" />
        [ForeignKey("DrinkModel")]
        public int DrinkID { get; set; }

        /// <summary>
        /// Gets or sets the DrinkModel.
        /// </summary>
        /// <value>
        /// The drink model.
        /// </value>
        public virtual DrinkModel DrinkModel { get; set; }

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
        public string Directory { get; set; }

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
    }
}