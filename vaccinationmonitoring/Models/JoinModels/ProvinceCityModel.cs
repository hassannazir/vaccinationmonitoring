using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vaccinationmonitoring.Models.JoinModels
{
    public class ProvinceCityModel
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
