using HRSG_Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRSG_HandbookGenerator.Popups {
    public partial class EditSubsection : System.Web.UI.Page {
        private int SubsectionID
        {
            get
            {
                var id = Request.QueryString["ID"];
                return Convert.ToInt32(id);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                var subsection = hrsgEntities.SubSections.FirstOrDefault(a => a.ID == SubsectionID && a.Active);

                if (subsection != null)
                {
                    txtbxSubsectionName.Text = subsection.Description;
                    txtbxSubsectionValue.Text = subsection.Value;
                }
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e) {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                var subsection = hrsgEntities.SubSections.FirstOrDefault(a => a.ID == SubsectionID && a.Active);

                if (subsection != null)
                {
                    subsection.Modified = DateTime.Now;
                    subsection.Description = txtbxSubsectionName.Text;
                    subsection.Value = txtbxSubsectionValue.Text;

                    hrsgEntities.SaveChanges();
                }

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndSave();", true);
            }
        }
    }
}