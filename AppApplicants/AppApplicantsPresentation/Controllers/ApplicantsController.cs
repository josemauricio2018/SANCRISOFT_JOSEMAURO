using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            string Id = Request.QueryString["Id"];
            ApplicantView applicant = new ApplicantView();

            if (!string.IsNullOrEmpty(Id)) {

                Id = "27";

                applicant.Consecutive = Convert.ToInt32(Id);
                return RedirectToAction("Index", "Administrator", applicant);
            }

            
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

                    int Id_Applicant = _repositoryApplicants.Create_Applicants(Convert.ToInt32(applicantView.ID_Job.ToString()),
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

                    bool result = false;
                    if (Id_Applicant > 0)
                    {
                        _repositoryFile_Adjunts = repositoryFile_Adjunts;

                        string pathString = string.Format("{0}File_Adjunt\\{1}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString());
                        string[] filePaths = Directory.GetFiles(pathString);
                        List<ListItem> files = new List<ListItem>();
                        foreach (string filePath in filePaths)
                        {
                            string.Format("{0}File_Adjunt\\{1}\\{2}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString(), Path.GetFileName(filePath));

                            FileInfo file = new FileInfo(string.Format("{0}File_Adjunt\\{1}\\{2}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString(), Path.GetFileName(filePath)));
                            decimal sizeFileNEW = Convert.ToDecimal(file.Length);

                            result = _repositoryFile_Adjunts.Create_File_Adjunt(Id_Applicant,
                            Path.GetFileName(filePath),
                            Path.GetExtension(filePath),
                            0,
                            Path.GetFullPath(filePath),
                            "",
                            Session["Description_File"].ToString());
                        }

                        pathString = string.Format("{0}Photo_Applicant\\{1}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString());
                        filePaths = Directory.GetFiles(pathString);
                        files = new List<ListItem>();
                        foreach (string filePath in filePaths)
                        {
                            FileInfo file = new FileInfo(string.Format("{0}Photo_Applicant\\{1}\\{2}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString(), Path.GetFileName(filePath)));
                            decimal sizeFileNEW = Convert.ToDecimal(file.Length);

                            result = _repositoryFile_Adjunts.Create_File_Adjunt(Id_Applicant,
                            Path.GetFileName(filePath),
                            Path.GetExtension(filePath),
                            0,
                            Path.GetFullPath(filePath),
                            "",
                            "");
                        }

                        //Send email to user

                        //It´s reload the view applicant
                        ApplicantView applicant = new ApplicantView();
                        applicant = FillJobs(applicant);
                        applicant.file_Adjunt = new Files_Adjunt();

                        string job_name = "";
                        foreach (var item in applicant.sjobs)
                        {
                            if (Convert.ToInt32(item.Value) == applicantView.ID_Job)
                            {
                                job_name = item.Text;
                            }
                        }

                        string FullName = applicantView.Firts_Name + " " + applicantView.Second_Name;
                        string FullLastName = applicantView.First_Last_Name + " " + applicantView.Second_Last_Name;

                        SendEmail(Id_Applicant, FullName, FullLastName, job_name, "Hemos recibido tu aplicación!", 1, applicantView.Email);

                        //Send email to administrator

                        SendEmail(Id_Applicant, FullName, FullLastName, job_name, "Nueva aplicación recibida", 2, applicantView.Email);


                        //It´s reload the view applicant
                        applicant = new ApplicantView();
                        applicant = FillJobs(applicant);
                        applicant.file_Adjunt = new Files_Adjunt();

                        ViewBag.cjobs = applicant.sjobs;

                        TempData["ModelApplicant"] = applicant;

                        //Consult list files adjunt to the apllicants
                        _repositoryFile_Adjunts = repositoryFile_Adjunts;
                        TempData["ReportFiles_Adjunt"] = _repositoryFile_Adjunts.Consult_File_Adjunt(applicant.Consecutive.ToString());

                        _repositoryApplicants = repositoryApplicants;
                        TempData["ReportApplicants"] = _repositoryApplicants.Consult_Applicants(applicant.Consecutive.ToString());
                    }

                }
            }
            catch (Exception ex)
            {

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

        /*[HttpPost]
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
        }*/

        [HttpPost]
        public void Upload_File_Adjunts()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var fileName = Path.GetFileName(file.FileName);
                string pathString = string.Format("{0}File_Adjunt\\{1}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString());

                System.IO.Directory.CreateDirectory(pathString);
                var path = Path.Combine(pathString, fileName);

                file.SaveAs(path);
            }

        }

        [HttpPost]
        public void Upload_Photo_Applicant()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var fileName = Path.GetFileName(file.FileName);
                string pathString = string.Format("{0}Photo_Applicant\\{1}", Server.MapPath("~"), HttpContext.Session.SessionID.ToString());

                System.IO.Directory.CreateDirectory(pathString);
                var path = Path.Combine(pathString, fileName);

                file.SaveAs(path);
            }
        }


        public bool Save_Description_File(string Description_File)
        {
            Session["Description_File"] = Description_File;
            return true;
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


        protected void SendEmail(int Id_Applicant, string Applicant_Name, string Applicant_Last_Name, string Job_Name, string Subject, int Type_Email, string Email_Applicant)
        {
            //calling for creating the email body with html template   

            string body = this.createEmailBody(Id_Applicant, Applicant_Name, Applicant_Last_Name, Job_Name, Subject, Type_Email);

            if (Type_Email == 2) {
                Email_Applicant = ConfigurationManager.AppSettings["EmailAdministrator"];
            }

            this.SendHtmlFormattedEmail(Subject, body, Email_Applicant);

        }

        private string createEmailBody(int Id_Applicant, string Applicant_Name, string Applicant_Last_Name, string Job_Name, string Subject, int Type_Email)//string userName, string title, string message)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   

            if (Type_Email == 1)
            {
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Models/Template_Email_Applicant.html")))
                {

                    body = reader.ReadToEnd();

                }

                body = body.Replace("{NOMBRE_DEL_APLICANTE}", Applicant_Name); //replacing the required things  
            }
            else
            {

                using (StreamReader reader = new StreamReader(Server.MapPath("~/Models/Template_Email_Administrator.html")))
                {

                    body = reader.ReadToEnd();

                }

                body = body.Replace("{NOMBRE_DEL_APLICANTE}", Applicant_Name); //replacing the required things  
                body = body.Replace("{APELLIDO_DEL_APLICANTE}", Applicant_Last_Name); //replacing the required things  
                body = body.Replace("{CARGO_POR_EL_QUE_APLICA}", Job_Name); //replacing the required things  

                var req = HttpContext.Request;
                string baseUrl = req.Url.Authority;

                body = body.Replace("{URL_DEL_APP}", baseUrl);
                body = body.Replace("{ID_DEL_REGISTRO}", Id_Applicant.ToString());
            }
            return body;

        }

        private void SendHtmlFormattedEmail(string subject, string body, string email_applicant)
        {

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                mailMessage.To.Add(new MailAddress(email_applicant));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                smtp.Send(mailMessage);

                //return View("Index", objModelMail);

            }

        }

    }
}

