using HRSG_Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSG_HandbookGenerator.Popups {
    public partial class AddIndustry : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSave_OnClick(object sender, EventArgs e) {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                var industry = hrsgEntities.Industries.Create();

                industry.Created = DateTime.Now;
                industry.Modified = DateTime.Now;
                industry.Active = true;
                industry.Name = txtbxIndustryName.Text;

                hrsgEntities.Industries.Add(industry);
                hrsgEntities.SaveChanges();

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndSave();", true);
            }
        }
    }
}