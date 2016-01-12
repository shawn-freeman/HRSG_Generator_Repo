using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRSG_Datalayer;
using HRSG_HandbookGenerator.Common;
using HRSG_HandbookGenerator.Objects;
using Telerik.Web.UI;

namespace HRSG_HandbookGenerator {
    public partial class Dashboard : Common.HRSGPage {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (IsPostBack) return;
            if (!CurrentUserID.HasValue) Response.Redirect("~/Account/Login.aspx", false);
        }

        #region Clients

        protected void rgClients_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities())
            {
                var results = hrsgEntities.Clients.Where(c => c.Active).ToList();
                
                //convert the results into a custom listing object
                var clientListing = results.Select(a => new ClientListingItem()
                {
                    ID = a.ID,
                    Modified = a.Modified,
                    Created = a.Created,
                    EmployeeRange = Globals.Instance.EmployeeRanges.FirstOrDefault(b => b.ID == a.EmployeeRange).Description,
                    IndustryID = a.IndustryID,
                    IndustryName = hrsgEntities.Industries.FirstOrDefault(b => b.ID == a.IndustryID).Name,
                    Name = a.Name
                }).ToList();

                rgClients.DataSource = clientListing;
            }
        }

        protected void rgClients_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                switch (e.CommandName) {
                    case "Edit":

                        break;

                    case "Delete":
                        var id = Convert.ToInt32(e.CommandArgument);    //LINQ does not understand Convert.ToInt(), convert it before passing to the expression
                        var client = hrsgEntities.Clients.FirstOrDefault(a => a.ID == id && a.Active);

                        if (client != null)
                        {
                            client.Active = false;
                            hrsgEntities.SaveChanges();
                        }
                        break;
                }
            }
        }

        #endregion

        #region Industries

        protected void rgIndustries_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities())
            {
                rgIndustries.DataSource = hrsgEntities.Industries.Where(a => a.Active).ToList();
            }
        }

        protected void rgIndustries_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                switch (e.CommandName) {
                    case "Edit":

                        break;

                    case "Delete":
                        var id = Convert.ToInt32(e.CommandArgument);    //LINQ does not understand Convert.ToInt(), convert it before passing to the expression
                        var industry = hrsgEntities.Industries.FirstOrDefault(a => a.ID == id && a.Active);

                        if (industry != null) {
                            industry.Active = false;
                            hrsgEntities.SaveChanges();
                        }
                        break;
                }
            }
        }

        #endregion

        #region Sections

        protected void rgSections_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities())
            {
                rgSections.DataSource = hrsgEntities.Sections.Where(a => a.Active).ToList();
            }
        }

        protected void rgSections_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                switch (e.CommandName) {
                    case "Edit":

                        break;

                    case "Delete":
                        var id = Convert.ToInt32(e.CommandArgument);    //LINQ does not understand Convert.ToInt(), convert it before passing to the expression
                        var section = hrsgEntities.Sections.FirstOrDefault(a => a.ID == id && a.Active);

                        if (section != null) {
                            section.Active = false;
                            hrsgEntities.SaveChanges();
                        }
                        break;
                }
            }
        }

        #endregion

        #region Subsections

        protected void rgSubsections_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e) {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                rgSubsections.DataSource = hrsgEntities.SubSections.Where(c => c.Active).ToList();
            }
        }

        protected void rgSubsections_OnItemCommand(object sender, GridCommandEventArgs e) {
            using (var hrsgEntities = new HRSG_DatabaseEntities()) {
                switch (e.CommandName) {
                    case "Edit":

                        break;

                    case "Delete":
                        var id = Convert.ToInt32(e.CommandArgument);    //LINQ does not understand Convert.ToInt(), convert it before passing to the expression
                        var subsection = hrsgEntities.SubSections.FirstOrDefault(a => a.ID == id && a.Active);

                        if (subsection != null) {
                            subsection.Active = false;
                            hrsgEntities.SaveChanges();
                        }
                        break;
                }
            }
        }

        #endregion
    }
}