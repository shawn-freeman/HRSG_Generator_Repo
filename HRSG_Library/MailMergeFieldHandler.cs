using System.IO;
using Aspose.Words;
using Aspose.Words.Reporting;
using HRSG_Library.Handlers;

namespace HRSG_Library {
    public class MailMergeFieldHandler : IFieldMergingCallback {
        private readonly FieldMerger _FIELD_MERGER;

        public MailMergeFieldHandler(FieldMerger fm) {
            _FIELD_MERGER = fm;
        }

        void IFieldMergingCallback.FieldMerging(FieldMergingArgs e) {
            if (e.FieldValue == null) {
                return;
            }

            if (!e.FieldValue.ToString().StartsWith("<table") && !e.FieldValue.ToString().StartsWith("<html")) {
                e.Text = e.FieldValue.ToString();
                return;
            }

            var builder = new DocumentBuilder(e.Document);

            builder.MoveToMergeField(e.DocumentFieldName);

            builder.InsertHtml((string)e.FieldValue);

            e.Text = "";
        }

        void IFieldMergingCallback.ImageFieldMerging(ImageFieldMergingArgs e) {
            //var result = _FIELD_MERGER.GetImageMailMerge(e.FieldName);

            //if (result.Value == null || result.Value.Length == 0)
            //{
                
            //    Email.SendMail("Error", $"Could not find value for {e.FieldName}");
            //    return;
            //}

            //using (var stream = new MemoryStream(result.Value)) {
            //    e.Image = System.Drawing.Image.FromStream(stream);
            //}
        }
    }
}