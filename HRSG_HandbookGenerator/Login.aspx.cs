using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRSG_Library;
using HRSG_Library.Objects;

namespace HRSG_HandbookGenerator {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void OnClick(object sender, EventArgs e)
        {
            var docEngine = new DocumentEngine();
            var docItem = new DocGenItem()
            {
                templateName = "custom_template.dotx",
                fileName = "generated_document.docx"
            };

            var msg = docEngine.GenerateDocument(docItem);
        }
    }
}