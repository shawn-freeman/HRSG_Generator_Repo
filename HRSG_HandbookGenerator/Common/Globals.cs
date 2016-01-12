using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSG_Datalayer;

namespace HRSG_HandbookGenerator.Common {
    public class Globals
    {
        #region Singleton Logic

        private static bool _initialized = false;

        private static Globals _instance;
        public static Globals Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                    _initialized = true;
                }
                return _instance;
            }
        }

        #endregion

        #region Properties

        public List<Industry> Industries { get; set; }

        public List<EmployeeRanx> EmployeeRanges { get; set; } 

        #endregion

        private Globals()
        {
            if (!_initialized)
            {
                using (var hrsgEntities = new HRSG_DatabaseEntities())
                {
                    //store all the activate industries
                    Industries = hrsgEntities.Industries.Where(i => i.Active).ToList();
                    EmployeeRanges = hrsgEntities.EmployeeRanges.Where(e => e.Active).ToList();
                }
            }
        }
    }
}
