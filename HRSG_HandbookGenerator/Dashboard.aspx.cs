using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSG_HandbookGenerator {
    public partial class Dashboard : Common.HRSGPage {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (IsPostBack) return;
            if (!CurrentUserID.HasValue) Response.Redirect("~/Account/Login.aspx", false);
        }

        public async void LoadClients()
        {
            
        }
    }
}