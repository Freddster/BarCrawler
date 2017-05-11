using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class DrinkPictureModel
    {
        [Key]
        public int DrinkPictureID { get; set; }
        [ForeignKey("DrinkModel")]
        public int DrinkID { get; set; }
        public DrinkModel DrinkModel { get; set; }

        public string Directory { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}