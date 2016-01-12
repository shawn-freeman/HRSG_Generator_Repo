using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRSG_Datalayer;

namespace HRSG_HandbookGenerator.Models {
    public class LoginModel {
        public User CheckLogin(string username, string password)
        {
            using (var hrsgEntites = new HRSG_DatabaseEntities()) {
                //TODO: convert the password to HASHED or encrypted version

                return hrsgEntites.Users.FirstOrDefault(a => a.Username == username && a.Password == password && a.Active);
            }
        }
    }
}