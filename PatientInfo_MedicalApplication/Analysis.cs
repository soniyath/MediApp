using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientInfo_MedicalApplication
{
    public class AnalysisObj
    {
        public int MRN { get; set; }
        public string DateTime { get; set; }
        public string ReasonForVisit { get; set; }
        public string SubjectiveAnalysis { get; set; }
        public string ObjectiveAnalysis { get; set; }
        public bool CheckedIn { get; set; }
    }
}