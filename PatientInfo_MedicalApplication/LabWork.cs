using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientInfo_MedicalApplication
{
    public class LabWorkObj
    {
        public int MRN { get; set; }
        public string DateTime { get; set; }
        public double Creatinine { get; set; }
        public int Hemoglobin { get; set; }
        public double WBC { get; set; }
        public int Sodium { get; set; }
        public double Potassium { get; set; }
        public double Fluoride { get; set; }
    }
}