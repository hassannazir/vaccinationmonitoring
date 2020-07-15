using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vaccinationmonitoring.Models.JoinModels;

namespace vaccinationmonitoring.Models.ViewModels
{
    public class AreaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public IList<City> CityList { get; set; }
        public IList<CityAreaModel> CAList { get; set; }
    }
}
