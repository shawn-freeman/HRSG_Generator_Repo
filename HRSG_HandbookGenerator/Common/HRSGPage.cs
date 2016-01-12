using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSG_HandbookGenerator.Common {
    public class HRSGPage : System.Web.UI.Page
    {
        protected static int? CurrentUserID { get; set; }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!CurrentUserID.HasValue)
            {
                if (Title.Contains("Log In")) return;
                Response.Redirect("~/Account/Login.aspx", false);
            }
            else
            {
                if (Title.Contains("Log In")) Response.Redirect("~/Dashboard.aspx", false); ;
                
            }
        }
    }
}
