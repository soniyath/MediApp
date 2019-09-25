using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientInfo_MedicalApplication
{
    public class VitalsObj
    {

        public int MRN { get; set; }

        public int Systolic { get; set; }

        public int Diastolic { get; set; }

        public int O2_Levels { get; set; }

        public int Pulse { get; set; }

        public int Respiratory_Rate { get; set; }

        public string DateTime { get; set; }

    }
}