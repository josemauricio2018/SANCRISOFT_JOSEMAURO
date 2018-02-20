using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public class ApplicantView : Applicant
    {
        public string Country_Code { get; set; }
        public string Area_Code { get; set; }
        public string SessionId { get; set; }
        public string Description_File { get; set; }

        public virtual Files_Adjunt file_Adjunt { get; set; }

        public System.Web.Mvc.SelectList sjobs;
    }
}