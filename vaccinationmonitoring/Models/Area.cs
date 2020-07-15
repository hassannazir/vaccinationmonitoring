using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class Area
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public string Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
