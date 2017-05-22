using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BarCrawler.Models;

namespace BarCrawler.ViewModels
{
    public class PictureViewModel
    {
        public PictureViewModel()
        {
            
        }
        public PictureViewModel(PictureModel pm)
        {
            PictureID = pm.PictureID;
            Description = pm.Description;
            Directory = pm.Directory;
            BarID = pm.BarID; 
        }

        public PictureViewModel(BarProfilPictureModel pm)
        {
            PictureID = pm.BarID; 
            Description = pm.Description;
            Directory = pm.Directory;
            BarID = pm.BarID;
        }

        public PictureViewModel(CoverPictureModel cm)
        {
            PictureID = cm.BarID;
            Description = cm.Description;
            Directory = cm.Directory;
            BarID = cm.BarID;
        }

        [Key]
        public int PictureID { get; set; }
        public int BarID { get; set; }

        [MaxLength(200)]
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "URL link")]
        public string Directory { get; set; }
    }
}