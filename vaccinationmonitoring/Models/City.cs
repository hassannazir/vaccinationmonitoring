using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public int? ProvinceId { get; set; }
        public string Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
