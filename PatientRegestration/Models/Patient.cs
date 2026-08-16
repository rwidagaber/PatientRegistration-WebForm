using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientRegestration.Models
{
    public class Patient
    {
        public int Id { get;set;  }
        public long FileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

    }
}