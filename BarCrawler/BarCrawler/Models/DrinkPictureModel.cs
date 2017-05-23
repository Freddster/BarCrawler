using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BarCrawler.Models
{
    /// <summary>
    /// The DrinkPictureModel defines all the neccesary properties for creation. 
    /// </summary>
    public class DrinkPictureModel
    {
        /// <summary>
        /// Gets or sets the DrinkPictureID. <br/>
        /// </summary>
        [Key]
        public int DrinkPictureID { get; set; }

        /// <summary>
        /// Gets or sets the DrinkID and has a [ForeignKey] to DrinkModel <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.schema.foreignkeyattribute(v=vs.110).aspx">Foreignkeyattribute</see> <br/>
        /// </summary>
        [ForeignKey("DrinkModel")]
        public int DrinkID { get; set; }

        /// <summary>
        /// Gets or sets the DrinkModel. <br/>
        /// </summary>
        public virtual DrinkModel DrinkModel { get; set; }

        /// <summary>
        /// Gets or sets the Directory. <br/>
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// TimeStamp <br/>
        /// </summary>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}