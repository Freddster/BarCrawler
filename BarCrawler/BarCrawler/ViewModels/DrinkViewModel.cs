using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    /// <summary>
    /// Viewmodel for the DrinkModel without the navigational properties
    /// </summary>
    public class DrinkViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrinkViewModel"/> class.
        /// </summary>
        public DrinkViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrinkViewModel"/> class.
        /// </summary>
        /// <param name="dm">The dm.</param>
        public DrinkViewModel(DrinkModel dm)
        {
            DrinkID = dm.DrinkID; 
            BarID = dm.BarID;
            Title = dm.Title;
            Description = dm.Description;
            Price = dm.Price;
        }

        //[Key]
        /// <summary>
        /// Gets or sets the drink identifier.
        /// </summary>
        /// <value>
        /// The drink identifier.
        /// </value>
        public int DrinkID { get; set; }

        //[ForeignKey("BarModel")]
        /// <summary>
        /// Gets or sets the bar identifier.
        /// </summary>
        /// <value>
        /// The bar identifier.
        /// </value>
        public int BarID { get; set; }

        /// <summary>
        /// Gets or sets the Title for the drink.
        /// </summary>
        /// <value>
        /// The title for the drink.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute"/>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description for the drink.
        /// </summary>
        /// <value>
        /// The description for the drink.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag <see cref="MaxLengthAttribute" />
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute"/>
        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Description for the drink.
        /// </summary>
        /// <value>
        /// The description for the drink.
        /// </value>
        /// <remarks>
        /// This property is marked with a [MaxLength] tag <see cref="MaxLengthAttribute" />
        /// </remarks>
        /// <seealso cref="MaxLengthAttribute"/>
        [Required]
        public double Price { get; set; }
    }
}