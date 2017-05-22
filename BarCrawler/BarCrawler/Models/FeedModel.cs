using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The FeedModel defines all the neccesary properties for creation. 
    /// </summary>
    public class FeedModel
    {
        /// <summary>
        /// Gets or sets the FeedID <br/>
        /// </summary>
        /// <summary>
        /// This property has a uniquely [Key] tag for identification <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.keyattribute(v=vs.110).aspx">Keyattribute</see>
        /// </summary>
        [Key]
        public int FeedID { get; set; }

        /// <summary>
        /// Gets or sets the BarID and has a [ForeignKey] to BarModel <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.schema.foreignkeyattribute(v=vs.110).aspx">Foreignkeyattribute</see> <br/>
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
        /// Gets or sets the created time of a feed <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Oprettelses tidspunkt")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the Description. <br/>
        /// </summary>
        /// <summary>
        /// This property is marked with a [MaxLength] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.maxlengthattribute(v=vs.110).aspx">Maxlengthattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
    }
}