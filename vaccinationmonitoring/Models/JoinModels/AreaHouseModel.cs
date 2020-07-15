using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vaccinationmonitoring.Models.JoinModels
{
    public class AreaHouseModel
    {
        public int HouseId { get; set; }
        public int AreaId { get; set; }
        public string HouseNo { get; set; }
        public string AreaName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
