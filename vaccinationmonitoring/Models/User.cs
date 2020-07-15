using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? AreaId { get; set; }
        public string Role { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
