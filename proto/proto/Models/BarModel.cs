using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proto.Models
{
    public class BarModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Display(Name = "Telefon Nummer")]
        public string TelefonNr { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Fakultet { get; set; }

        [Display(Name="Barbillede")]
        public string ImageDir { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}