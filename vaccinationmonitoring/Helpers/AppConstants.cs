using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vaccinationmonitoring.Helpers
{
    public class AppConstants
    {
        public const string BaseUrl = "https://localhost:44333/";
        public const string ok = "Ok";
        public const string notOk = "Error";
        public const string SuccessMessage = "success";
        public const string ErrorMessage = "error";
        public const int RoleParent = 0;
        public const int RoleWorker = 1;
        public const int RoleAdmin = 2;
        public const string Parent = "Parent";
        public const string Worker = "Worker";
        public const string Admin = "Admin";
        public const int UserNotApprovedStatus = 0;
        public const string UNotApprovedStatus = "Not Approved";
        public const int UserApprovedStatus = 1;
        public const string UApprovedStatus = "Approved";
    }
}
