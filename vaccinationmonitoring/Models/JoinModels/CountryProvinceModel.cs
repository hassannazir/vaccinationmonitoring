using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace vaccinationmonitoring.Models.JoinModels
{
    public class CountryProvinceModel
    {
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public string CountryName { get; set; }
        public string ProvinceName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
