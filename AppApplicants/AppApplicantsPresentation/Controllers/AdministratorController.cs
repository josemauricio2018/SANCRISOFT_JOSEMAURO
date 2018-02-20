using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAplicantsBAL.Models;
using AppApplicants.Models;

namespace AppApplicantsPresentation.Controllers
{
    public class AdministratorController : Controller
    {
        private IApplicants _repositoryApplicants;
        private BusinessApplicants repositoryApplicants = new BusinessApplicants();

        private IFile_Adjunts _repositoryFile_Adjunts;
        private BusinessFile_Adjunts repositoryFile_Adjunts = new BusinessFile_Adjunts();

        private IJobs _repositoryJobs;
        private BusinessJob repositoryJobs = new BusinessJob();
        //
        // GET: /Administrator/

        public ActionResult Index(ApplicantView applicant)
        {
            //ApplicantView applicant = new ApplicantView();
            applicant = FillJobs(applicant);

            applicant.file_Adjunt = new Files_Adjunt();

            ViewBag.cjobs = applicant.sjobs;

            ApplicantView applicantTemp = new ApplicantView();
            applicantTemp.SessionId = HttpContext.Session.SessionID;

            TempData["ModelApplicant"] = applicant;
            Session["SessionId"] = HttpContext.Session.SessionID;

            //Consult list files adjunt to the apllicants
            _repositoryFile_Adjunts = repositoryFile_Adjunts;
            TempData["ReportFiles_Adjunt"] = _repositoryFile_Adjunts.Consult_File_Adjunt(applicant.Consecutive.ToString());

            _repositoryApplicants = repositoryApplicants;
            TempData["ReportApplicants"] = _repositoryApplicants.Consult_Applicants(applicant.Consecutive.ToString());


            IEnumerable<Applicant> lstApplicants = _repositoryApplicants.Consult_Applicants(applicant.Consecutive.ToString());

            foreach (Applicant item in lstApplicants) {
                applicant.ID_Job = item.ID_Job;
                applicant.Street_Adress = item.Street_Adress;
                applicant.Biography = item.Biography;
                applicant.Birtday = item.Birtday;
                applicant.City = item.City;
                applicant.Consecutive = item.Consecutive;
                applicant.Country = item.Country;
                applicant.Email = item.Email;
                applicant.First_Last_Name = item.First_Last_Name;
                applicant.Firts_Name = item.Firts_Name;
                applicant.International_Phone_Number = item.International_Phone_Number;
                applicant.Postal_Code = item.Postal_Code;
                applicant.Second_Last_Name = item.Second_Last_Name;
                applicant.Second_Name = item.Second_Name;
                applicant.Street_Adress = item.Street_Adress;
            }


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
