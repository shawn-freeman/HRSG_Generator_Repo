using HRSG_Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSG_HandbookGenerator.Popups {
    public partial class EditSection : System.Web.UI.Page {
        private int SectionID {
            get {
                var id = Request.QueryString["ID"];
                return Convert.ToInt32(id);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) return;

            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                var section = hrsgEntities.Sections.FirstOrDefault(a => a.ID == SectionID && a.Active);

                if (section != null) {
                    txtbxSectionName.Text = section.Description;
                    txtbxSectionValue.Text = section.Value;
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e) {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                var section = hrsgEntities.Sections.FirstOrDefault(a => a.ID == SectionID && a.Active);

                if (section != null) {
                    section.Modified = DateTime.Now;
                    section.Description = txtbxSectionName.Text;
                    section.Value = txtbxSectionValue.Text;

                    hrsgEntities.SaveChanges();
                }

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndSave();", true);
            }
        }
    }
}