using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSG_Library.Enums;

namespace HRSG_Library {
    public class FieldMerger {

        #region Merge Field Logic

        private string _holidayLeave {
            get { return "Some info entered for holiday leave."; }
        }

        private string _sickLeave {
            get { return "Some info entered for sick leave."; }
        }

        #endregion


        /// <summary>
        /// Takes the field merge text from the field and converts to FieldMerge Defintion to get MergeField value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string GetMerge(string fieldName) {
            FieldDefintions mergeFieldName;

            var sectionNameValue = String.Empty;

            return !Enum.TryParse(fieldName, true, out mergeFieldName) ?
              $"{fieldName} failed Enum FieldDefintion.Parse." : getFieldValue(mergeFieldName);
        }

        private string getFieldValue(FieldDefintions fieldName) {
            switch (fieldName) {
                case FieldDefintions.HolidayLeave:
                    return _holidayLeave;
                case FieldDefintions.SickLeave:
                    return _sickLeave;
            }

            return $"MergeFactory::MergeField() - Merge Field Type Not Found ({fieldName.ToString()})";
        }
    }
}
