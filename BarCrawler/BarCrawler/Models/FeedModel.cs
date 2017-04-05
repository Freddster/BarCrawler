using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class FeedModel
    {
        [Key]
        public int FeedID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Text { get; set; }

        //Foreign
        public BarModel Bar { get; set; }
    }
}