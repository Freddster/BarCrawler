using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BarCrawler.Models;

namespace BarCrawler.Controllers
{
    /// <summary>
    /// ManageController containing the actions to help manage the login system
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class ManageController : Controller
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
        /// Initializes a new instance of the <see cref="ManageController"/> class.
        /// </summary>
        public ManageController()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
        // GET: /Manage/Index
        /// <summary>
        /// Returns an index view based on the massage.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Returns IndexViewModel.</returns>
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        /// <summary>
        /// Removes the login.
        /// </summary>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns>
        /// Redirect to ManageLogins view.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref=" ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        /// <summary>
        /// Adds the phone number.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        /// <summary>
        /// Adds the phone number to the user in the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Redirect to VerifyPhoneNumber view.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        /// <summary>
        /// Enables the two factor authentication.
        /// </summary>
        /// <returns>
        /// Redirect to manage index view.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        /// <summary>
        /// Disables the two factor authentication.
        /// </summary>
        /// <returns>
        /// Redirect to manage index view.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        /// <summary>
        /// Verifies the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>
        /// Return view with a VerifyPhoneNumberViewModel
        /// </returns>
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        /// <summary>
        /// Verifies the phone number and adds it tot the user in the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Redirect to index with a message.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        /// <summary>
        /// Removes the phone number.
        /// </summary>
        /// <returns>
        /// Redirect to index with a message.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        /// <summary>
        /// Create change password view.
        /// </summary>
        /// <returns>
        /// Return ChangePassword view.
        /// </returns>
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        /// <summary>
        /// Changes the password and update the data in the database and redirect to index.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Redirect to index with a message.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        /// <summary>
        /// Create a SetPassword view.
        /// </summary>
        /// <returns>
        /// Return SetPassword view.
        /// </returns>
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        /// <summary>
        /// Sets the password and updates the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Redirect to index with a message.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        /// <summary>
        /// Manages the logins.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// Return ManageLoginsViewModel.
        /// </returns>
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        /// <summary>
        /// Links the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Return a ChallengeResult.
        /// </returns>
        /// <seealso cref="HttpPostAttribute"/>
        /// <seealso cref="ValidateAntiForgeryTokenAttribute"/>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        /// <summary>
        /// Links the login callback.
        /// </summary>
        /// <returns>
        /// Redirect to ManageLogins
        /// </returns>
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        /// <summary>
        /// The XSRF key
        /// </summary>
        private const string XsrfKey = "XsrfId";

        /// <summary>
        /// Gets the authentication manager.
        /// </summary>
        /// <value>
        /// The authentication manager.
        /// </value>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// Adds the errors.
        /// </summary>
        /// <param name="result">The result.</param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        /// <summary>
        /// Determines whether this instance has password.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has password; otherwise, <c>false</c>.
        /// </returns>
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        /// <summary>
        /// Determines whether [has phone number].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has phone number]; otherwise, <c>false</c>.
        /// </returns>
        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        /// <summary>
        /// Enum for messages
        /// </summary>
        public enum ManageMessageId
        {
            /// <summary>
            /// The add phone success
            /// </summary>
            AddPhoneSuccess,
            /// <summary>
            /// The change password success
            /// </summary>
            ChangePasswordSuccess,
            /// <summary>
            /// The set two factor success
            /// </summary>
            SetTwoFactorSuccess,
            /// <summary>
            /// The set password success
            /// </summary>
            SetPasswordSuccess,
            /// <summary>
            /// The remove login success
            /// </summary>
            RemoveLoginSuccess,
            /// <summary>
            /// The remove phone success
            /// </summary>
            RemovePhoneSuccess,
            /// <summary>
            /// The error
            /// </summary>
            Error
        }

#endregion
    }
}