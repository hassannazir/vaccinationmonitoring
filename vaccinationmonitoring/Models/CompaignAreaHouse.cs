using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class CompaignAreaHouse
    {
        public int Id { get; set; }
        public int? HouseId { get; set; }
        public int? CompaignId { get; set; }
        public int? AreaId { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
