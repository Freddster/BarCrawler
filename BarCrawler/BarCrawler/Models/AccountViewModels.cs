using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace BarCrawler.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Gentag kodeord")]
        [Compare("Password", ErrorMessage = "Kodeordene stemmer ikke overens")]
        public string ConfirmPassword { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Barens navn")]
        public string BarName { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Kort beskrivelse af bar")]
        public string Description { get; set; }

        [Required]
        [StringLength(5)]
        public string OpenTime { get; set; }
        [Required]
        [StringLength(5)]
        public string CloseTime { get; set; }



        [Required]
        [Display(Name = "Fakultet")]
        public string Faculty { get; set; }
        [Display(Name = "Telefonnummer")]
        [MaxLength(8)]
        public string PhoneNumber { get; set; }


        //Bar Address
        [Required]
        [Display(Name = "Vejnavn")]
        public string Address1 { get; set; }
        [Display(Name = "Etage")]
        public string Address2 { get; set; }
        [Required]
        [Display(Name = "Husnummer")]
        public string StreetNumber { get; set; }
        [Required]
        [Display(Name = "By")]
        public string City { get; set; }
        [Required]
        [MaxLength(4)]
        [Display(Name = "Postnummer")]
        public string Zipcode { get; set; }


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
