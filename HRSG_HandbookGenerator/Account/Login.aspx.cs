using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HRSG_HandbookGenerator.Models;
using HRSG_Datalayer;

namespace HRSG_HandbookGenerator.Account
{
    public partial class Login : Common.HRSGPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (IsPostBack) return;

            if (CurrentUserID.HasValue)
            {
                Response.Redirect("~/Dashboard.aspx", false);
                return;
            }

            //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
            //    Response.Redirect("~/Default.aspx", false);
            //}

            //RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        protected async void LogIn(object sender, EventArgs e)
        {
            var userID = await attemptLogin(txtBxUsername.Text, txtBxPassword.Text);

            if(!userID.HasValue)
            {
                FailureText.Text = "Login Failed.";
                return;
            }
            
            Response.Redirect("~/Dashboard.aspx", false);

            //if (IsValid)
            //{
            //    // Validate the user password
            //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            //    // This doen't count login failures towards account lockout
            //    // To enable password failures to trigger lockout, change to shouldLockout: true
            //    var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

            //    switch (result)
            //    {
            //        case SignInStatus.Success:
            //            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //            break;
            //        case SignInStatus.LockedOut:
            //            Response.Redirect("/Account/Lockout");
            //            break;
            //        case SignInStatus.RequiresVerification:
            //            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
            //                                            Request.QueryString["ReturnUrl"],
            //                                            RememberMe.Checked),
            //                              true);
            //            break;
            //        case SignInStatus.Failure:
            //        default:
            //            FailureText.Text = "Invalid login attempt";
            //            ErrorMessage.Visible = true;
            //            break;
            //    }
            //}
        }

        public async Task<int?> attemptLogin(string username, string password)
        {
            var loginModel = new LoginModel();
            User currentUser = loginModel.CheckLogin(username, password);

            if (currentUser != null)
            {
                CurrentUserID = currentUser.ID;

                return currentUser.ID;
            }
            return null;
        }
    }
}