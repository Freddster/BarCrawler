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


        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [Required]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime DateAndTimeForEvent { get; set; }


        //Her skal der bare være en standart indtastet ting fra selve baren
        //Address
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}