using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vaccinationmonitoring.Models.JoinModels
{
    public class CityAreaModel
    {
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string CityName { get; set; }
        public string AreaName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
