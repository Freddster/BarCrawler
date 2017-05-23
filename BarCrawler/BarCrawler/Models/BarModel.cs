using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace BarCrawler.Models
{
    /// <summary>
    /// The BarModel defines all the needed or optional requirements for a bar.
    /// </summary>
    public class BarModel
    {
        /// <summary>
        /// Gets or sets the BarID <br/>
        /// </summary>
        /// <summary>
        /// This property has a uniquely [Key] tag for identification <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.keyattribute(v=vs.110).aspx">Keyattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Key]
        [Display()]
        public int BarID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the BarName. <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// This property is marked with a [MaxLength] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.maxlengthattribute(v=vs.110).aspx">Maxlengthattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see> 
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "Bar navn")]
        public string BarName { get; set; }

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
        /// Gets or sets the Email. <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// it is also marked with a [EmailAddress] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.emailaddressattribute(v=vs.110).aspx"></see> <br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Faculty <br/>
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// It also has a [Display] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [Display(Name = "Studieretning")]
        public string Faculty { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber.
        /// </summary>
        /// <summary>
        /// This property is marked with a [StringLength] tag <see href ="https://msdn.microsoft.com/da-dk/library/system.componentmodel.dataannotations.stringlengthattribute(v=vs.110).aspx">Stringlengthattribute</see><br/>
        /// This property is also marked with a [Display] tag <see href ="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute/see></see><br/>
        /// It also has a [RegularExpression] tag for allowing only 8 numbers <see href = "https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.regularexpressionattribute(v=vs.110).aspx">Regularexpressionattrbute</see>
        /// </summary>
        [StringLength(8)]
        [Display(Name = "Telefon nr.")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Telefon nr. skal være 8 cifre")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the OpenTime for a specific bar.
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// This property is also marked with a [StringLength] tag <see href ="https://msdn.microsoft.com/da-dk/library/system.componentmodel.dataannotations.stringlengthattribute(v=vs.110).aspx">Stringlengthattribute</see><br/>
        /// It also has a [Display] tag <see href ="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [StringLength(5)]
        [Display(Name = "Åbningstid")]
        public string OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the CloseTime for a specific bar.
        /// </summary>
        /// <summary>
        /// This property is required and is marked with a [Required] tag <see href="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.requiredattribute(v=vs.110).aspx">Requiredattribute</see><br/>
        /// This property is also marked with a [StringLength] tag <see href ="https://msdn.microsoft.com/da-dk/library/system.componentmodel.dataannotations.stringlengthattribute(v=vs.110).aspx">Stringlengthattribute</see><br/>
        /// It also has a [Display] tag <see href ="https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.displayattribute(v=vs.110).aspx">Displayattribute</see>
        /// </summary>
        [Required]
        [StringLength(5)]
        [Display(Name = "Lukketid")]
        public string CloseTime { get; set; }

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

        /// <summary>
        /// Gets or sets the Longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the Latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Here is all the foreign keys to all the other models
        /// </summary>
        public virtual List<DrinkModel> Drinks { get; set; }    //Overvej at bruge et Dictionary til at gemme i. Burg evt. navn på drink som key
        public virtual List<EventModel> Events { get; set; }    //Overvej at bruge et Dictionary til at gemme i. Brug evt. dato + tid for hvornår event finder sted, for som key til at gemme i dictionary 
        public virtual List<FeedModel> Feeds { get; set; }      //Overvej at bruge et Dictionary til at gemme i. Burg evt. tidspunkt for oprettelse som key
        public virtual List<PictureModel> Pictures { get; set; }
        public virtual BarProfilePictureModel BarProfilPictureModel { get; set; }
        public virtual CoverPictureModel CoverPictureModel { get; set; }
        
        public string userID { get; set; }
        public ApplicationUser ApplicationUser;
    }

}