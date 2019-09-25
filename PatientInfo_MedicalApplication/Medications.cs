using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientInfo_MedicalApplication
{
    public class Medications
    {
        public int MRN { get; set; }
        public string MedicationName { get; set; }
        public string Dose { get; set; }
        public string DateTime { get; set; }
    }
}