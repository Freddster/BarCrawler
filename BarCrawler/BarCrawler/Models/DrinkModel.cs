using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BarCrawler.Models
{
    /// <summary>
    /// The DrinkModel defines all the needed or optional requirements for a drink.
    /// </summary>
    public class DrinkModel
    {
        /// <summary>
        /// Gets or sets the DrinkID <br/>
        /// </summary>
        /// <summary>
        /// This property has a uniquely [Key] tag for identification <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.keyattribute(v=vs.110).aspx">Keyattribute</see>
        /// </summary>
        [Key]
        public int DrinkID { get; set; }

        /// <summary>
        /// Has a foreignkey to a BarModel and has a get or set for bar BarID
        /// </summary>
        [ForeignKey("BarModel")]
        public int BarID { get; set; }

        /// <summary>
        /// Gets or sets the BarModel. <br/>
        /// </summary>
        public virtual BarModel BarModel { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the Title. <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Drink navn")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description. <br/>
        /// </summary>
        /// <summary>
        /// This property is marked with a [MaxLength] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.maxlengthattribute(v=vs.110).aspx">Maxlengthattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [MaxLength(500)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price. <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Pris")]
        public double Price { get; set; }


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