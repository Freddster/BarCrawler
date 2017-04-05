using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class BarModel
    {
        [Key]
        public int BarID { get; set; }

        //Bar info
        [Required]
        public string BarName { get; set; }
        public string Description { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Faculty { get; set; }
        [Display(Name = "Telefon Nummer")]
        public string PhoneNumber { get; set; }


        //Bar Address
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }



        //Foreign keys
        public List<EventModel> Events { get; set; }
        public List<FeedModel> Feeds { get; set; }
        public List<PictureModel> Pictures { get; set; }
        public List<Drink> Drinks { get; set; }


        [Display(Name = "Barbillede")]
        public string ImageDir { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }

}