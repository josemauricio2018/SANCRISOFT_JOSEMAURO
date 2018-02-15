using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAplicantsBAL.Models;
using AppApplicants.Models;

namespace AppApplicantsPresentation.Controllers
{
    public class ApplicantsController : Controller
    {
        private IApplicants _repositoryApplicants;
        private BusinessApplicants repositoryApplicants = new BusinessApplicants();

        private IFile_Adjunts _repositoryFile_Adjunts;
        private BusinessFile_Adjunts repositoryFile_Adjunts = new BusinessFile_Adjunts();

        private IJobs _repositoryJobs;
        private BusinessJob repositoryJobs = new BusinessJob();

        //
        // GET: /Applicants/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ApplicantView applicant = new ApplicantView();
            applicant = FillJobs(applicant);

            ViewBag.cjobs = applicant.sjobs;

            return View(applicant);
        }

        //
        // POST: /Applicants/Create

        [HttpPost]
        public ActionResult Create(ApplicantView applicant)
        {
            
            return View(applicant);
        }

        public ApplicantView FillJobs(ApplicantView applicant)
        {
            //It is loaded combobox jobs.  
            _repositoryJobs = repositoryJobs;

            IList<Job> listJobs = _repositoryJobs.Consult_Job();
            List<SelectListItem> listSelect = new List<SelectListItem>();

            foreach (Job item in listJobs)
            {
                listSelect.Add(new SelectListItem() { Value = Convert.ToString(item.Consecutive), Text = item.Name });
            }

            applicant.sjobs = new SelectList(listSelect, "Value", "Text");

            return applicant;
        }


    }
}
