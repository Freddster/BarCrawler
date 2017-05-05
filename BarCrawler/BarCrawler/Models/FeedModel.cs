using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class FeedModel
    {
        [Key]
        public int FeedID { get; set; }
        [ForeignKey("BarModel")]
        public int BarID { get; set; }
        public BarModel BarModel { get; set; }


        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        //MANGLER typen DateTime til at vise hvornår en post på feeden er oprettet. 

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        [Required]
        public DateTime DateAndTimeForFeed { get; set; }
    }
}