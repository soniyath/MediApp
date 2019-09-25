using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientInfo_MedicalApplication
{
    public class Patient
    {
        public int MRN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string BloodType { get; set; }
    }
}