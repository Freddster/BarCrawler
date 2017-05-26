using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BarCrawler.Models
{
    /// <summary>
    /// The DrinkModel defines all the requirements for a drink in the database.
    /// </summary>
    public class DrinkModel
    {
        /// <summary>
        /// Gets or sets the DrinkID
        /// </summary>
        /// <value>
        /// The drink identifier.
        /// </value>
        /// <remarks>
        /// This property has a uniquely [Key] tag for identification <see cref="KeyAttribute"/>
        /// </remarks>
        /// <seealso cref="KeyAttribute"/>
        [Key]
        public int DrinkID { get; set; }

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
        /// Gets or sets the Title for the drink.
        /// </summary>
        /// <value>
        /// The title for the drink.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [Required]
        [Display(Name = "Drink navn")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description for the drink.
        /// </summary>
        /// <value>
        /// The description for the drink.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag <see cref="MaxLengthAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [MaxLength(500)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price for the drink.
        /// </summary>
        /// <value>
        /// The price for the drink.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        /// <seealso cref="DisplayAttribute"/>
        [Required]
        [Display(Name = "Pris")]
        public double Price { get; set; }


        /// <summary>
        /// Navigational property for the DrinkPictureModel.
        /// </summary>
        /// <value>
        /// The drink picture models.
        /// </value>
        /// <seealso cref="DrinkPictureModels" />
        public List<DrinkPictureModel> DrinkPictureModels { get; set; }

        /*
         Opret model til drinks billeder, sådan at det er muligt at baren
         kan lægge et billede op af den pågældende drink.
         Det skal evt være muligt at have to forskellige visningstilstande.
         Den første tilstand vil være alm tabel form med billede ved siden af.
         Den anden tilstand vil være et stort billede af drinken, hvor man så kan 
         trykke på drinken, og så kommer informationen op i et lille "overlay" vindue.
         */
    }
}