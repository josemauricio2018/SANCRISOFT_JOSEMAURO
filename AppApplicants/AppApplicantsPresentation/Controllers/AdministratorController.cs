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
		
		public FileResult Download_File_Adjunt(int Consecutive_File_Adjunt, int Modulo)
        {
			string filename = "";
			string pathLocal = "";
			string contentType = "";
			string typeFile = "";
			
			IEnumerable<Files_Adjunt> lstFile_Adjunt = _repositoryFile_Adjunts.Consult_File_Adjunt(Consecutive_File_Adjunt.ToString());
			
			foreach(Files_Adjunt item in lstFile_Adjunt){
				filename = item.File_Name;
				pathLocal = item.Path_File_Local;
				typeFile = item.Tipe_File;
			}
			
			switch (typeFile) {
				case ".docx":
					contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					break;
				
				case ".png"
					contentType = "image/png"; 
					break;
				
				case ".gif":
					contentType = "image/gif";
					break;
				
				case ".jpeg":
					contentType = "image/jpeg";
					break;
					
				case ".pdf":
					contentType = "application/pdf";
					break;			
			}
				
            //Parameters to file are
            //1. The File Path on the File Server
            //2. The content type MIME type
            //3. The parameter for the file save by the browser
            return File(pathLocal, contentType,filename);
        }
    }
}
