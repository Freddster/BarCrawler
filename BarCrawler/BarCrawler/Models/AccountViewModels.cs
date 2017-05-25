using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarCrawler.Models
{
    /// <summary>
    /// Viewmodel for the ExternalLoginConfirmationViewModel containing the email to login
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// It is also has a [Display] tag <see cref="DisplayAttribute"/>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// Viewmodel for the ExternalLoginListViewModel returning the URL to a login site
    /// </summary>
    public class ExternalLoginListViewModel
    {
        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnUrl { get; set; }
    }

    /// <summary>
    /// Viewmodel for the SendCodeViewModel send code back to the views
    /// </summary>
    public class SendCodeViewModel
    {
        /// <summary>
        /// Gets or sets the selected provider.
        /// </summary>
        /// <value>
        /// The selected provider.
        /// </value>
        public string SelectedProvider { get; set; }
        /// <summary>
        /// Gets or sets the providers.
        /// </summary>
        /// <value>
        /// The providers.
        /// </value>
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
        /// </value>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// Viewmodel for the VerifyCodeViewModel to return the viewmodel to the views
    /// </summary>
    public class VerifyCodeViewModel
    {
        /// <summary>
        /// Gets or sets the Provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        [Required]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute"/><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute"/>
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Gets or sets the Remember Browser.
        /// </summary>
        /// <value>
        /// The remember browser.
        /// </value>
        /// <remarks>
        /// This property is also marked with a [Display] tag <see cref="DisplayAttribute" /><br />
        /// </remarks>
        /// <seealso cref="DisplayAttribute" />
        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
        /// </value>
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// Viewmodel for the ForgotViewModel, containing the email for a bar
    /// </summary>
    public class ForgotViewModel
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// Viewmodel for the LoginViewModel containing the information required to login
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// it is also marked with a [EmailAddress] tag <see cref="EmailAddressAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="EmailAddressAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// it is also marked with a [EmailAddress] tag <see cref="DataType.Password" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="DataType.Password" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// This property i marked with a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// Viewmodel for the RegisterViewModel containing parts of the information required to register
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// This property is also marked with a [StringLength] tag <see cref="StringLengthAttribute" /><br />
        /// it is also marked with a [Datatype] tag <see cref="DataType.Password" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DataType.Password" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Confirm Password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        /// <remarks>
        /// it is also marked with a [EmailAddress] tag <see cref="DataType.Password" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// is is also marked with a [Compare] tag <see cref="CompareAttribute"/>
        /// </remarks>
        /// <seealso cref="DataType.Password" />
        /// <seealso cref="DisplayAttribute" />
        /// <seealso cref="CompareAttribute"/>
        [DataType(DataType.Password)]
        [Display(Name = "Gentag kodeord")]
        [Compare("Password", ErrorMessage = "Kodeordene stemmer ikke overens")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// Viewmodel for the ResetPasswordViewModel containing the information required to reset the password
    /// </summary>
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// it is also marked with a [EmailAddress] tag <see cref="EmailAddressAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="EmailAddressAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// This property is also marked with a [StringLength] tag <see cref="StringLengthAttribute" /><br />
        /// it is also marked with a [Datatype] tag <see cref="DataType.Password" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="StringLengthAttribute" />
        /// <seealso cref="DataType.Password" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Confirm Password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        /// <remarks>
        /// it is also marked with a [EmailAddress] tag <see cref="DataType.Password" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// is is also marked with a [Compare] tag <see cref="CompareAttribute"/>
        /// </remarks>
        /// <seealso cref="DataType.Password" />
        /// <seealso cref="DisplayAttribute" />
        /// <seealso cref="CompareAttribute"/>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }
    }

    /// <summary>
    /// Viewmodel for the ForgotPasswordViewModel containing the information required to reset the password
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// This property is required and is marked with a [Required] tag <see cref="RequiredAttribute" /><br />
        /// it is also marked with a [EmailAddress] tag <see cref="EmailAddressAttribute" /><br />
        /// It also has a [Display] tag <see cref="DisplayAttribute" />
        /// </remarks>
        /// <seealso cref="RequiredAttribute" />
        /// <seealso cref="EmailAddressAttribute" />
        /// <seealso cref="DisplayAttribute" />
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
