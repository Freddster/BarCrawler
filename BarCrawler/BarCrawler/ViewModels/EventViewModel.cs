using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {}
        public EventViewModel(EventModel model)
        {
            EventID = model.EventID;
            BarID = model.BarID;
            Title = model.Title;
            Description = model.Description;
            DateAndTimeForEvent = model.DateAndTimeForEvent;
            Address1 = model.Address1;
            Address2 = model.Address2;
            StreetNumber = model.StreetNumber;
            City = model.City;
            Zipcode = model.Zipcode;

        }

        [Key]
        public int EventID { get; set; }
        [ForeignKey("BarModel")]
        public int BarID { get; set; }
        [Required]
        [Display(Name = "Event navn")]
        public string Title { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tidspunkt for event")]
        public DateTime DateAndTimeForEvent { get; set; }

        //Her skal der bare være en standart indtastet ting fra selve baren
        //Address
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
    }
}