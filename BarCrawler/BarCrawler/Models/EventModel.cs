using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The EventModel defines all the neccesary properties for creation. 
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Gets or sets the EventID <br/>
        /// </summary>
        /// <summary>
        /// This property has a uniquely [Key] tag for identification <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.keyattribute(v=vs.110).aspx">Keyattribute</see>
        /// </summary>
        [Key]
        public int EventID { get; set; }

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
        /// Gets or sets the Title. <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Event navn")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description. <br/>
        /// </summary>
        /// <summary>
        /// This property is marked with a [MaxLength] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.maxlengthattribute(v=vs.110).aspx">Maxlengthattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the time for an event to occur. <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Tidspunkt for event")]
        public DateTime DateAndTimeForEvent { get; set; }
        
        /// <summary>
        /// Get or sets the created time of an event. <br/>
        /// </summary>
        //[Required]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the Address1.
        /// </summary>
        /// <summary>
        /// The property for Address1 is required and is marked with a [Required] tag. <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// The property also has a [Display] tag <see href ="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the Address2.
        /// </summary>
        /// /// <summary>
        /// The property only has a [Display] tag <see href ="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Display(Name = "Etage")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the StreetNumber <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Hus nr.")]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the City <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "By")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Zipcode.
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// This property is also marked with a [StringLength] tag <see href ="https://msdn.microsoft.com/da-dk/library/system.componentmodel.dataannotations.stringlengthattribute(v=vs.110).aspx">Stringlengthattribute</see><br/>
        /// It also has a [Display] tag <see href ="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see><br/>
        /// and a [RegularExpression] tag for allowing only 4 numbers <see href = "https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.regularexpressionattribute(v=vs.110).aspx">Regularexpressionattrbute</see>
        /// </summary>
        [Required]
        [StringLength(4)]
        [Display(Name = "Post nr.")]
        [RegularExpression(@"[0-9]{4}$", ErrorMessage = "Post nr. skal være 4 cifre")]
        public string Zipcode { get; set; }
    }
}