using HRSG_Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSG_HandbookGenerator.Popups {
    public partial class AddSection : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSave_OnClick(object sender, EventArgs e) {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                var section = hrsgEntities.Sections.Create();

                section.Created = DateTime.Now;
                section.Modified = DateTime.Now;
                section.Active = true;
                section.Description = txtbxSectionName.Text;
                section.Value = txtbxSectionValue.Text;

                hrsgEntities.Sections.Add(section);
                hrsgEntities.SaveChanges();

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndSave();", true);
            }
        }
    }
}