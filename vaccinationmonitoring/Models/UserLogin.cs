using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class UserLogin
    {
        public string ConcurrencyStamp { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}
