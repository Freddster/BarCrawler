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
    /// Viewmodel for the PictureViewModel without the navigational properties
    /// </summary>
    public class PictureViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PictureViewModel"/> class.
        /// </summary>
        public PictureViewModel()
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PictureViewModel"/> class.
        /// </summary>
        /// <param name="pm">The pm.</param>
        public PictureViewModel(PictureModel pm)
        {
            PictureID = pm.PictureID;
            Description = pm.Description;
            BarID = pm.BarID; 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PictureViewModel"/> class.
        /// </summary>
        /// <param name="pm">The pm.</param>
        public PictureViewModel(BarProfilePictureModel pm)
        {
            PictureID = pm.BarID; 
            Description = pm.Description;
            BarID = pm.BarID;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PictureViewModel"/> class.
        /// </summary>
        /// <param name="cm">The cm.</param>
        public PictureViewModel(CoverPictureModel cm)
        {
            PictureID = cm.BarID;
            Description = cm.Description;
            BarID = cm.BarID;
        }

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
        public int BarID { get; set; }

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