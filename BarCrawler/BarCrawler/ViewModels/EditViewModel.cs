using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    public class EditViewModel
    {
        public EditViewModel()
        {
        }
        public EditViewModel(BarModel barmodel, string picture = "http://www.nice.com/PublishingImages/Career%20images/J---HR_Page-4st-strip-green-hair%20(2).png?RenditionID=-1")
        {
            if (barmodel != null)
            {
                BarID = barmodel.BarID;
                Description = barmodel.Description;
                Faculty = barmodel.Faculty;
                PhoneNumber = barmodel.PhoneNumber;
                Address1 = barmodel.Address1;
                Address2 = barmodel.Address2;
                StreetNumber = barmodel.StreetNumber;
                Zipcode = barmodel.Zipcode;
                City = barmodel.City;
                Picture = picture;
                OpenTime = barmodel.OpenTime;
                CloseTime = barmodel.CloseTime;
            }
        }

        [Key]
        public int BarID { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Required]
        [Display]
        public string Faculty { get; set; }

        [Display(Name = "Telefon Nummer")]
        [MaxLength(8)]
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


        public string Picture { get; set; }
    }
}

