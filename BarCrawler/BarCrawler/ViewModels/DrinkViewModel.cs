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

        public DrinkViewModel(DrinkModel dm)
        {
            DrinkID = dm.DrinkID; 
            BarID = dm.BarID;
            Title = dm.Title;
            Description = dm.Description;
            Price = dm.Price;
        }
        //[Key]
        public int DrinkID { get; set; }

        //[ForeignKey("BarModel")]
        public int BarID { get; set; }

        //[Required]
        public string Title { get; set; }
        //[MaxLength(500)]
        public string Description { get; set; }

        //[Required]
        public double Price { get; set; }
    }
}