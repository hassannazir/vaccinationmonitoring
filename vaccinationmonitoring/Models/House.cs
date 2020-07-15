using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class House
    {
        public int Id { get; set; }
        public string HouseNo { get; set; }
        public int? AreaId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
