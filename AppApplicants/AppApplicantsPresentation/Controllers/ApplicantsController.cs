using System;
using System.Collections.Generic;
using System.IO;
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

            ApplicantView applicantTemp = new ApplicantView();
            applicantTemp.SessionId = HttpContext.Session.SessionID;

            TempData["ModelApplicant"] = applicantTemp;

            Session["SessionId"] = HttpContext.Session.SessionID;

            //Consult list files adjunt to the apllicants
            _repositoryFile_Adjunts = repositoryFile_Adjunts;
            TempData["ReportFiles_Adjunt"] = _repositoryFile_Adjunts.Consult_File_Adjunt(applicant.Consecutive.ToString());


            return View(applicant);
        }

        //
        // POST: /Applicants/Create

        [HttpPost]
        public ActionResult Create(ApplicantView applicantView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    applicantView.PathPhotoLocal = "";
                    applicantView.PathPhotoURL = "";

                    _repositoryApplicants = repositoryApplicants;

                    Boolean resultado = _repositoryApplicants.Create_Applicants(Convert.ToInt32(applicantView.ID_Job.ToString()),
                    applicantView.Firts_Name,
                    applicantView.Second_Name,
                    applicantView.First_Last_Name,
                    applicantView.Second_Last_Name,
                    applicantView.Email,
                    applicantView.International_Phone_Number,
                    applicantView.Biography,
                    applicantView.Birtday,
                    applicantView.Street_Adress,
                    applicantView.City,
                    applicantView.Country,
                    applicantView.Postal_Code,
                    applicantView.PathPhotoLocal,
                    applicantView.PathPhotoURL
                    );
                }
            }
            catch (Exception ex) { 
            
            }

            return View(applicantView);
        }

        //
        // GET: /Clientes/Edit/5

        public ActionResult Edit(int Consec_Applicant = 0)
        {
            ApplicantView applicantView = new ApplicantView();

            _repositoryApplicants = repositoryApplicants;

            IEnumerable<Report_Applicants> lstApplicant = _repositoryApplicants.Consult_Applicants(Consec_Applicant.ToString());
           
            return View(applicantView);
        }

        //
        // POST: /Applicants/Edit

        [HttpPost]
        public ActionResult Edit(ApplicantView applicantView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryApplicants = repositoryApplicants;

                    Boolean resultado = _repositoryApplicants.Edit_Applicants(applicantView.Consecutive,
                    Convert.ToInt32(applicantView.ID_Job.ToString()),
                    applicantView.Firts_Name,
                    applicantView.Second_Name,
                    applicantView.First_Last_Name,
                    applicantView.Second_Last_Name,
                    applicantView.Email,
                    applicantView.International_Phone_Number,
                    applicantView.Biography,
                    applicantView.Birtday,
                    applicantView.Street_Adress,
                    applicantView.City,
                    applicantView.Country,
                    applicantView.Postal_Code,
                    applicantView.PathPhotoLocal,
                    applicantView.PathPhotoURL
                    );
                }
            }
            catch (Exception ex)
            {

            }

            return View(applicantView);
        }

        [HttpPost]
        public ActionResult Upload_File_Adjunts(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("demo");
            // return Content("successful");
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
