using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class Compaign
    {
        public int Id { get; set; }
        public int? AreaId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? AssignedBy { get; set; }
        public int? AssignedTo { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
