using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vaccinationmonitoring.Models.JoinModels
{
    public class UsersJoinModel
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public int? Role { get; set; }
        public int? Status { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public string PhoneNumber { get; set; }
    }
}
