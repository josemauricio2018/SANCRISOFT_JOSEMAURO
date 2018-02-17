using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace AppApplicants.Models
{
    public class ManageApplicants
    {
        private BD_APPLICANTSEntities3 dbApplicantContext = new BD_APPLICANTSEntities3();

        public ManageApplicants() { 
        
        }

        /// <summary>
        /// En este procedimiento se crean los aplicantes a cargos ofertados.
        /// </summary>
        /// <param name="Id_Job"></param>
        /// <param name="First_Name"></param>
        /// <param name="Second_Name"></param>
        /// <param name="First_Last_Name"></param>
        /// <param name="Second_Last_Name"></param>
        /// <param name="Email"></param>
        /// <param name="International_Phone_Number"></param>
        /// <param name="Biography"></param>
        /// <param name="Birthday"></param>
        /// <param name="Street_Adress"></param>
        /// <param name="City"></param>
        /// <param name="Country"></param>
        /// <param name="Postal_Code"></param>
        /// <param name="Path_Photo_Local"></param>
        /// <param name="Path_Photo_URL"></param>
        /// <returns></returns>
        public Boolean Create_Applicants (int Id_Job, string First_Name, string Second_Name, string First_Last_Name, string Second_Last_Name, string Email, string International_Phone_Number, string Biography, DateTime Birthday, string Street_Adress, string City, string Country, string Postal_Code, string Path_Photo_Local, string Path_Photo_URL)
        {
            Boolean Result = false;

            try
            {
                Applicant applicant = new Applicant();
                applicant.ID_Job = Id_Job;
                applicant.Firts_Name = First_Name;
                applicant.Second_Name = Second_Name;
                applicant.First_Last_Name = First_Last_Name;
                applicant.Second_Last_Name = Second_Last_Name;
                applicant.Email = Email;
                applicant.International_Phone_Number = International_Phone_Number;
                applicant.Biography = Biography;
                applicant.Birtday = Birthday;
                applicant.Street_Adress = Street_Adress;
                applicant.City = City;
                applicant.Country = Country;
                applicant.Postal_Code = Postal_Code;
                applicant.PathPhotoLocal = Path_Photo_Local;
                applicant.PathPhotoURL = Path_Photo_URL;

                dbApplicantContext.SP_INSERT_APPLICANT(applicant.ID_Job, applicant.Firts_Name, applicant.Second_Name, applicant.First_Last_Name, applicant.Second_Last_Name, applicant.Email, applicant.International_Phone_Number, applicant.Biography, applicant.Birtday, applicant.Street_Adress, applicant.City, applicant.Country, applicant.Postal_Code, applicant.PathPhotoLocal, applicant.PathPhotoURL);

                Result = true;
            }
            catch (Exception Ex) {           
            }
            
            return Result;
        }


        /// <summary>
        /// En este procedimiento e actualizan los datos de un aplicante mediante el consecutivo del mismo.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <param name="Id_Job"></param>
        /// <param name="First_Name"></param>
        /// <param name="Second_Name"></param>
        /// <param name="First_Last_Name"></param>
        /// <param name="Second_Last_Name"></param>
        /// <param name="Email"></param>
        /// <param name="International_Phone_Number"></param>
        /// <param name="Biography"></param>
        /// <param name="Birthday"></param>
        /// <param name="Street_Adress"></param>
        /// <param name="City"></param>
        /// <param name="Country"></param>
        /// <param name="Postal_Code"></param>
        /// <param name="Path_Photo_Local"></param>
        /// <param name="Path_Photo_URL"></param>
        /// <returns></returns>
        public Boolean Edit_Applicants(int Consec_Applicant, int Id_Job, string First_Name, string Second_Name, string First_Last_Name, string Second_Last_Name, string Email, string International_Phone_Number, string Biography, DateTime Birthday, string Street_Adress, string City, string Country, string Postal_Code, string Path_Photo_Local, string Path_Photo_URL)
        {
            Boolean Result = false;

            try
            {
                Applicant applicant = new Applicant();

                applicant.Consecutive = Consec_Applicant;
                applicant.ID_Job = Id_Job;
                applicant.Firts_Name = First_Name;
                applicant.Second_Name = Second_Name;
                applicant.First_Last_Name = First_Last_Name;
                applicant.Second_Last_Name = Second_Last_Name;
                applicant.Email = Email;
                applicant.International_Phone_Number = International_Phone_Number;
                applicant.Biography = Biography;
                applicant.Birtday = Birthday;
                applicant.Street_Adress = Street_Adress;
                applicant.City = City;
                applicant.Country = Country;
                applicant.Postal_Code = Postal_Code;
                applicant.PathPhotoLocal = Path_Photo_Local;
                applicant.PathPhotoURL = Path_Photo_URL;

                dbApplicantContext.SP_EDIT_APPLICANT(applicant.Consecutive, applicant.ID_Job, applicant.Firts_Name, applicant.Second_Name, applicant.First_Last_Name, applicant.Second_Last_Name, applicant.Email, applicant.International_Phone_Number, applicant.Biography, applicant.Birtday, applicant.Street_Adress, applicant.City, applicant.Country, applicant.Postal_Code, applicant.PathPhotoLocal, applicant.PathPhotoURL);

                //var ConsultApplicant = dbApplicantContext.SP_CONSULT_APPLICANT_BY_ID(applicant.Consecutive);

                //System.Data.Objects.ObjectResult

                Result = true;
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento se elimna los datos del aplicante
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public Boolean Delete_Applicants(int Consec_Applicant)
        {
            Boolean Result = false;

            try
            {
                dbApplicantContext.SP_DELETE_APPLICANT(Consec_Applicant);

                Result = true;
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento se consultan los datos de los aplicantes. En caso que se envíe el id del aplicante se filtra los datos del aplicante requerido; por el contrario se consultan los datos de todos los aplicantes.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public IEnumerable<Applicant> Consult_Applicants(string Consec_Applicant)
        {
            List<Applicant> lstApplicant = new List<Applicant>();

            try
            {
                if (!string.IsNullOrEmpty(Consec_Applicant))
                {

                    var consultApplicant = dbApplicantContext.SP_CONSULT_APPLICANT_BY_ID(Convert.ToInt32(Consec_Applicant));

                    foreach (var item in consultApplicant)
                    {
                        lstApplicant.Add(new Applicant()
                        {
                            Consecutive = item.Consecutive,
                            ID_Job = item.ID_Job,
                            Firts_Name = item.Firts_Name,
                            Second_Name = item.Second_Name,
                            First_Last_Name = item.First_Last_Name,
                            Second_Last_Name = item.Second_Last_Name,
                            Email = item.Email,
                            International_Phone_Number = item.International_Phone_Number,
                            Biography = item.Biography,
                            Birtday = item.Birtday,
                            Street_Adress = item.Street_Adress,
                            City = item.City,
                            Country = item.Country,
                            Postal_Code = item.Postal_Code,
                            PathPhotoLocal = item.PathPhotoLocal,
                            PathPhotoURL = item.PathPhotoURL
                        });
                    }
                }
                else {

                    var consultApplicant = dbApplicantContext.SP_CONSULT_APPLICANT_ALL();

                    foreach (var item in consultApplicant)
                    {
                        lstApplicant.Add(new Applicant()
                        {
                            Consecutive = item.Consecutive,
                            ID_Job = item.ID_Job,
                            Firts_Name = item.Firts_Name,
                            Second_Name = item.Second_Name,
                            First_Last_Name = item.First_Last_Name,
                            Second_Last_Name = item.Second_Last_Name,
                            Email = item.Email,
                            International_Phone_Number = item.International_Phone_Number,
                            Biography = item.Biography,
                            Birtday = item.Birtday,
                            Street_Adress = item.Street_Adress,
                            City = item.City,
                            Country = item.Country,
                            Postal_Code = item.Postal_Code,
                            PathPhotoLocal = item.PathPhotoLocal,
                            PathPhotoURL = item.PathPhotoURL
                        });
                    }

                }
            }
            catch (Exception Ex)
            {
            }

            return lstApplicant.AsEnumerable();
        }


    }
}