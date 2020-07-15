using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Feedback1 { get; set; }
        public int? CompaignId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
