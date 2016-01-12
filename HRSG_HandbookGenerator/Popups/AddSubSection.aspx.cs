using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRSG_Datalayer;

namespace HRSG_HandbookGenerator.Popups {
    public partial class AddSubSection : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities())
            {
                var subsection = hrsgEntities.SubSections.Create();

                subsection.Created = DateTime.Now;
                subsection.Modified = DateTime.Now;
                subsection.Active = true;
                subsection.Description = txtbxSubsectionName.Text;
                subsection.Value = txtbxSubsectionValue.Text;
                
                hrsgEntities.SubSections.Add(subsection);
                hrsgEntities.SaveChanges();

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndSave();", true);
            }
        }
    }
}