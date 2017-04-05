using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class PictureModel
    {
        [Key]
        public int PictureID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

        //Foreign Key
        public BarModel BarModel { get; set; }
    }
}