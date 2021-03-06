﻿using System;
using System.Collections.Generic;

namespace vaccinationmonitoring.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? AreaId { get; set; }
        public int? Role { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public string PhoneNumber { get; set; }
    }
}
