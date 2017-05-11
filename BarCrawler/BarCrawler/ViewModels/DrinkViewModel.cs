using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    public class DrinkViewModel
    {
        public DrinkViewModel()
        {
            
        }
        public DrinkViewModel(DrinkModel dm, string str = "http://www.nice.com/PublishingImages/Career%20images/J---HR_Page-4st-strip-green-hair%20(2).png?RenditionID=-1")
        {
            Drinkmodel = dm;
            Picture = str;


        }

        public DrinkModel Drinkmodel { get; set; }
        public string Picture { get; set; }

        //[ForeignKey("BarModel")]
        //public int BarID { get; set; }
        //public BarModel BarModel { get; set; }

        //[Required]
        //public string Title { get; set; }
        //[MaxLength(500)]
        //public string Description { get; set; }

        //[Required]
        //public string Price { get; set; }
    }
}