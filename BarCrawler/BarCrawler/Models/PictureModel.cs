using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarCrawler.Models
{
    public class PictureModel
    {
        [Key]
        public int PictureID { get; set; }
        [ForeignKey("BarModel")]
        public int BarID { get; set; }
        public BarModel BarModel { get; set; }
        [Display(Name= "URL link")]
        public string Directory { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [Required]
        [Display(Name = "Oprettelses tidspunkt")]
        public DateTime CreateTime { get; set; }


        [MaxLength(200)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
    }
}