using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BarCrawler.DataAccessLogic.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BarCrawler.Models;
using BarCrawler.ViewModels;

namespace BarCrawler.Controllers
{
    /// <summary>
    /// AccountController with functions to login and register accounts 
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    /// <seealso cref="AuthorizeAttribute"/>
    [Authorize]
    public class AccountController : Controller
    {
        /// <summary>
        /// The sign in manager
        /// </summary>
        private ApplicationSignInManager _signInManager;
        /// <summary>
        /// The user manager
        /// </summary>
        private ApplicationUserManager _userManager;
        /// <summary>
        /// The unit of work
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Gets the sign in manager.
        /// </summary>
        /// <value>
        /// The sign in manager.
        /// </value>
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        /// <value>
        /// The user manager.
        /// </value>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        /// <summary>
        /// Logins the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// Returns a view
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute" />
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        /// <summary>
        /// Login with the data specified in the LoginViewModel.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// Return a view depending on the succes of the login attempt
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="AllowAnonymousAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        /// <summary>
        /// Verifies the code.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <returns>
        /// Returns a view with the verified code
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute" />
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        /// <summary>
        /// Verifies the code.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns a view with the verified code
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="AllowAnonymousAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        /// <summary>
        /// Creates a view for the register page.
        /// </summary>
        /// <returns>
        /// Return register view
        /// </returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        /// <summary>
        /// Registers the specified profilbillede.
        /// </summary>
        /// <param name="Profilbillede">The profilbillede.</param>
        /// <param name="Coverbillede">The coverbillede.</param>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Redirects to index if succes is a succes
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="AllowAnonymousAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(HttpPostedFileBase Profilbillede, HttpPostedFileBase Coverbillede, BigRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.BarModel.Email, Email = model.BarModel.Email };
                var result = await UserManager.CreateAsync(user, model.RegisterViewModel.Password);
                if (result.Succeeded)
                {

                    var bar = new BarModel();
                    _unitOfWork.BarRepository.CreateAndAddBar(ref bar, ref model, ref user);
                    _unitOfWork.Save();

                    string[] validExt = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };
                    string profilPath = "~/Images/Fingers.png";
                    string coverPath = "~/Images/Fingers.png";

                    if (Profilbillede != null && Profilbillede.ContentLength > 0 &&
                        validExt.Contains(Path.GetExtension(Profilbillede.FileName)))
                    {
                        profilPath = Path.Combine("~/Images",
                            Guid.NewGuid().ToString() + Path.GetExtension(Profilbillede.FileName));

                        Profilbillede.SaveAs(Server.MapPath(profilPath));
                    }

                    if (Coverbillede != null && Coverbillede.ContentLength > 0 &&
                        validExt.Contains(Path.GetExtension(Coverbillede.FileName)))
                    {
                        coverPath = Path.Combine("~/Images",
                            Guid.NewGuid().ToString() + Path.GetExtension(Coverbillede.FileName));

                        Coverbillede.SaveAs(Server.MapPath(coverPath));
                    }

                    var profilbillede = new BarProfilePictureModel()
                    {
                        CreateTime = DateTime.Now,
                        BarID = bar.BarID,
                        BarModel = bar,
                        Directory = profilPath,
                    };

                    var coverbillede = new CoverPictureModel()
                    {
                        CreateTime = DateTime.Now,
                        BarID = bar.BarID,
                        BarModel = bar,
                        Directory = coverPath,
                    };

                    _unitOfWork.BarProfilePictureRepository.Add(profilbillede);
                    _unitOfWork.CoverPictureRepository.Add(coverbillede);
                    _unitOfWork.Save();

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");

                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        /// <summary>
        /// Confirms the email.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Return a view with the result of confirmation
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute" />
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        /// <summary>
        /// Create a view for the forgot password page.
        /// </summary>
        /// <returns>
        /// Return forgot password view
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute" />
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        /// <summary>
        /// Create a view for entering the new password after confirming through email.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Return ForgotPasswordConfirmation view
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="AllowAnonymousAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        /// <summary>
        /// Create a view for ForgotPasswordConfirmation.
        /// </summary>
        /// <returns>Return view</returns>
        /// <seealso cref="AllowAnonymousAttribute"/>
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        /// <summary>
        /// Return a view depending on the success of the code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// Return reset password view
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute" />
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        /// <summary>
        /// Gets data of the new password and resets the password for the account.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Return view based on the success of the reset
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="AllowAnonymousAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        /// <summary>
        /// Create a view confirming the user want to reset the password.
        /// </summary>
        /// <returns>
        /// Return ResetPasswordConfirmation view
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute"/>
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// Return <see cref="ChallengeResult" /> for external login
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="AllowAnonymousAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        /// <summary>
        /// Sends the code.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <returns>
        /// Return view the <see cref="SendCodeViewModel" />
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute" />
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        /// <summary>
        /// Sends the code.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Return view for the VerifyCode view
        /// </returns>
        /// <seealso cref="HttpPostAttribute" />
        /// <seealso cref="AllowAnonymousAttribute" />
        /// <seealso cref="ValidateAntiForgeryTokenAttribute" />
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        /// <summary>
        /// Externals the login callback.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// Return depending on the result of the login
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute"/>
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        /// <summary>
        /// Externals the login confirmation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// Return for the ExternalLoginConfirmation
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="AllowAnonymousAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns>
        /// Return Index view
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        /// <summary>
        /// Externals the login failure.
        /// </summary>
        /// <returns>
        /// Return ExternalLoginFailure view
        /// </returns>
        /// <seealso cref="AllowAnonymousAttribute"/>
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}