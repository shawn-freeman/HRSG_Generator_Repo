using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSG_HandbookGenerator.Objects {
    class ClientListingItem {
        public int ID { get; set; }
        public System.DateTime Modified { get; set; }
        public System.DateTime Created { get; set; }
        public string Name { get; set; }
        public int? IndustryID { get; set; }
        public string IndustryName { get; set; }
        public string EmployeeRange { get; set; }
    }
}
