using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarCrawler.Models
{
    public class BarProfilPictureModel
    {
        [Key, ForeignKey("BarModel")]
        public int BarID { get; set; }
        public virtual BarModel BarModel { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        [Required]
        [Display(Name = "Oprettelses tidspunkt")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "Profilbillede URL")]
        public string Directory { get; set; }

        [MaxLength(200)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
        
    }
}