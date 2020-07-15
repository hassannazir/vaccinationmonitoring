using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vaccinationmonitoring.Models.JoinModels;

namespace vaccinationmonitoring.Models.ViewModels
{
    public class HouseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public IList<Area> AreaList { get; set; }
        public IList<AreaHouseModel> AHList { get; set; }
    }
}
