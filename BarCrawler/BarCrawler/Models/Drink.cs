using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class Drink

    {
        [Key]
        public int DrinkID { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }

        //Foreign Key
        public BarModel BarModel { get; set; }
    }
}