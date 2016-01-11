using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HRSG_Datalayer;
using HRSG_Library.Objects;
using System.IO;

namespace HRSG_Library {
    public class DocumentEngine
    {
        private string CLIENT_NAME = "TEST";

        private DocGenItem _documentGeneratedItem;
        private string templateFileName {
            get {
                //if (HttpContext.Current != null) return HttpContext.Current.Server.MapPath("~/templates/") + CLIENT_NAME + @"\" + _documentItem.TemplateName;
                var path = ConfigurationManager.AppSettings["ProjectLocation"];
                //return $"{path}/temp/{CLIENT_NAME}/{_documentGeneratedItem.templateName}";
                return $"{ConfigurationManager.AppSettings["ProjectLocation"]}templates/{CLIENT_NAME}/{_documentGeneratedItem.templateName}";
            }
        }

        private string documentFileName {
            get {
                //if (HttpContext.Current != null) return HttpContext.Current.Server.MapPath("~/temp/") + CLIENT_NAME + @"\" + uniqueFileName;
                var path = ConfigurationManager.AppSettings["ProjectLocation"];
                //return $"{path}/temp/{CLIENT_NAME}/{_documentGeneratedItem.fileName}";
                return $"{ConfigurationManager.AppSettings["ProjectLocation"]}temp/{CLIENT_NAME}/{_documentGeneratedItem.fileName}";
            }
        }

        public DocumentEngine(){
            var license = new Aspose.Words.License();
            license.SetLicense("Licenses/Aspose.Words.lic");
        }

        public string GenerateDocument(DocGenItem docItem)
        {
            try
            {
                _documentGeneratedItem = docItem;

                var fm = new FieldMerger();

                //look for the temporary folder that the document will be place in
                //if it does not exist, create the directory
                string tempDirStr = documentFileName.Substring(0,
                    documentFileName.IndexOf(CLIENT_NAME, 0) + CLIENT_NAME.Length);
                if (!Directory.Exists(tempDirStr)) Directory.CreateDirectory(tempDirStr);

                //if a document exists in the temp directory with the same name already, delete it
                if (File.Exists(documentFileName)) File.Delete(documentFileName);

                //check if the template file exists and throw an exception if it does not
                if (!File.Exists(templateFileName))
                {
                    throw new Exception("templateFileName (" + templateFileName + ") does not exist");
                }

                //copy the template file, Copy() will not overwrite an existing file
                File.Copy(templateFileName, documentFileName);

                var docGenerated = new Aspose.Words.Document(documentFileName);
                docGenerated.MailMerge.FieldMergingCallback = new MailMergeFieldHandler(fm);

                var fieldNames = docGenerated.MailMerge.GetFieldNames();

                if (fieldNames != null && fieldNames.Length > 0)
                {
                    foreach (var fieldName in fieldNames)
                    {
                        var fieldValue = fm.GetMerge(fieldName);

                        if (!string.IsNullOrEmpty(fieldValue))
                        {
                            fieldValue = fieldValue.Replace(System.Environment.NewLine,
                                Aspose.Words.ControlChar.LineBreak);
                        }

                        docGenerated.MailMerge.Execute(new string[] {fieldName}, new object[] {fieldValue});
                    }
                }

                docGenerated.Save(documentFileName);

                return "Success";
            }catch (Exception ex){
                return ex.ToString();
            }
            
        }
    }
}
