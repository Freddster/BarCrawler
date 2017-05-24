using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The FeedModel defines all the requirements for a bar in the database.
    /// </summary>
    public class FeedModel
    {
        /// <summary>
        /// Gets or sets the FeedID
        /// </summary>
        /// <value>
        /// The feed identifier.
        /// </value>
        /// <remarks>
        /// This property has a uniquely [Key] tag for identification <see cref="KeyAttribute" />
        /// </remarks>
        /// <seealso cref="KeyAttribute" />
        [Key]
        public int FeedID { get; set; }

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
        /// Gets or sets the created time of a feed.
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
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The feed text.
        /// </value>
        /// <remarks>
        /// This property is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [MaxLength] tag <see cref="MaxLengthAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="MaxLengthAttribute" />
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
    }
}