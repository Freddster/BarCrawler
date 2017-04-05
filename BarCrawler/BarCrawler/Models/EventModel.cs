using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class EventModel
    {
        [Key]
        public int EventID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventTime { get; set; }

        //Address
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }


        //Foreign
        public BarModel Bar { get; set; }
    }
}