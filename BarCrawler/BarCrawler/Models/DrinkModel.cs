﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class DrinkModel

    {
        [Key]
        public int DrinkID { get; set; }
        [ForeignKey("BarModel")]
        public int BarID { get; set; }
        public BarModel BarModel { get; set; }


        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        /*
         Opret model til drinks billeder, sådan at det er muligt at baren
         kan lægge et billede op af den pågældende drink.
         Det skal evt være muligt at have to forskellige visningstilstande.
         Den første tilstand vil være alm tabel form med billede ved siden af.
         Den anden tilstand vil være et stort billede af drinken, hvor man så kan 
         trykke på drinken, og så kommer informationen op i et lille "overlay" vindue.
         */
    }
}