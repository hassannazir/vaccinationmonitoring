using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class Province
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
