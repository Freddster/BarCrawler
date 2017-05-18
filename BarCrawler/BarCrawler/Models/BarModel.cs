using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace BarCrawler.Models
{
    public class BarModel
    {
        [Key]
        [Display()]
        public int BarID { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        //Bar info
        [Required]
        [MaxLength(50)]
        [Display(Name = "Bar navn")]
        public string BarName { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Studieretning")]
        public string Faculty { get; set; }
        [StringLength(8)]
        [Display(Name = "Telefon nr.")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Telefon nr. skal være 8 cifre")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Åbningstid")]
        public string OpenTime { get; set; }
        [Required]
        [StringLength(5)]
        [Display(Name = "Lukketid")]
        public string CloseTime { get; set; }


        //Bar Address
        [Required]
        [Display(Name = "Address")]
        public string Address1 { get; set; }
        [Display(Name = "Etage")]
        public string Address2 { get; set; }
        [Required]
        [Display(Name = "Hus nr.")]
        public string StreetNumber { get; set; }
        [Required]
        [Display(Name = "By")]
        public string City { get; set; }
        [Required]
        [StringLength(4)]
        [Display(Name = "Post nr.")]
        [RegularExpression(@"[0-9]{4}$", ErrorMessage = "Post nr. skal være 4 cifre")]
        public string Zipcode { get; set; }

        
        public double Longitude { get; set; }
        public double Latitude { get; set; }



        //Foreign keys
        public List<DrinkModel> Drinks { get; set; }        //Overvej at bruge et Dictionary til at gemme i. Burg evt. navn på drink som key
        public List<EventModel> Events { get; set; }        //Overvej at bruge et Dictionary til at gemme i. Brug evt. dato + tid for hvornår event finder sted, for som key til at gemme i dictionary 
        public List<FeedModel> Feeds { get; set; }          //Overvej at bruge et Dictionary til at gemme i. Burg evt. tidspunkt for oprettelse som key
        public List<PictureModel> Pictures { get; set; }
        public virtual BarProfilPictureModel BarProfilPictureModel { get; set; }
        public virtual CoverPictureModel CoverPictureModel { get; set; }
        

        public string userID { get; set; }
        public ApplicationUser ApplicationUser;
    }

}