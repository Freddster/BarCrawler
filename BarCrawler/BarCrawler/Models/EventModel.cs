using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class EventModel
    {
        [Key]
        public int EventID { get; set; }
        [ForeignKey("BarModel")]
        public int BarID { get; set; }
        public BarModel BarModel { get; set; }


        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [Required]
        [Display(Name = "Event navn")]
        public string Title { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Tidspunkt for event")]
        public DateTime DateAndTimeForEvent { get; set; }
        //[Required]
        public DateTime CreateTime { get; set; }

        //Her skal der bare være en standart indtastet ting fra selve baren
        //Address
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Display(Name = "Hus nr.")]
        public string StreetNumber { get; set; }
        [Display(Name = "By")]
        public string City { get; set; }
        [Display(Name = "Post nr.")]
        public string ZipCode { get; set; }
    }
}