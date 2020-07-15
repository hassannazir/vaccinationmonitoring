using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vaccinationmonitoring.Models.JoinModels;

namespace vaccinationmonitoring.Models.ViewModels
{
    public class ProvinceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public IList<Country> CountryList { get; set; }
        public IList<CountryProvinceModel> CPList { get; set; }
    }
}
