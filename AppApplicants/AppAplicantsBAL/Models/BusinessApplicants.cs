using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AppApplicants;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public class BusinessApplicants : IApplicants
    {
        public BusinessApplicants() { 
        
        }

        /// <summary>
        /// En este procedimiento se habilita la adición de nuevos aplicantes.
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
        public Boolean Create_Applicants(int Id_Job, string First_Name, string Second_Name, string First_Last_Name, string Second_Last_Name, string Email, string International_Phone_Number, string Biography, DateTime Birthday, string Street_Adress, string City, string Country, string Postal_Code, string Path_Photo_Local, string Path_Photo_URL)
        {
            Boolean Result = false;
            BusinessModel business = new BusinessModel();

            try
            {
                Regex Val = new Regex(@"^[+-]?\d+(\.\d+)?$");
                Regex ValEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                Regex ValPhone = new Regex(@"^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$");

                if (!Val.IsMatch(First_Name))
                {

                    business.CodigoError = 1;
                    business.DescriptionError = "The First Name is invalid.";
                }
                else
                {
                    if (!Val.IsMatch(Second_Name))
                    {

                        business.CodigoError = 2;
                        business.DescriptionError = "The Second Name is invalid.";
                    }
                    else
                    {
                        if (!Val.IsMatch(First_Last_Name))
                        {

                            business.CodigoError = 3;
                            business.DescriptionError = "The First Last Name is invalid.";
                        }
                        else
                        {
                            if (!Val.IsMatch(Second_Last_Name))
                            {
                                business.CodigoError = 5;
                                business.DescriptionError = "The Second Last Name is invalid.";
                            }
                            else
                            {
                                if (!ValEmail.IsMatch(Email))
                                {
                                    business.CodigoError = 6;
                                    business.DescriptionError = "The Email is invalid.";
                                }
                                else
                                {
                                    if (!ValEmail.IsMatch(International_Phone_Number))
                                    {
                                        business.CodigoError = 7;
                                        business.DescriptionError = "The International Phone Number is invalid.";
                                    }
                                }
                            }
                        }
                    }
                }

                if (business.CodigoError == 0 && !string.IsNullOrEmpty(business.DescriptionError))
                {
                    AppApplicants.Models.ManageApplicants manageApplicants = new AppApplicants.Models.ManageApplicants();

                    return (manageApplicants.Create_Applicants(Id_Job, First_Name, Second_Name, First_Last_Name, Second_Last_Name, Email, International_Phone_Number, Biography, Birthday, Street_Adress, City, Country, Postal_Code, Path_Photo_Local, Path_Photo_URL));
                }
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento se habilita la actualización de aplicantes existentes.
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
            BusinessModel business = new BusinessModel();

            try
            {
                Regex Val = new Regex(@"^[+-]?\d+(\.\d+)?$");
                Regex ValEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                Regex ValPhone = new Regex(@"^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$");

                if (!Val.IsMatch(First_Name))
                {

                    business.CodigoError = 1;
                    business.DescriptionError = "The First Name is invalid.";
                }
                else
                {
                    if (!Val.IsMatch(Second_Name))
                    {

                        business.CodigoError = 2;
                        business.DescriptionError = "The Second Name is invalid.";
                    }
                    else
                    {
                        if (!Val.IsMatch(First_Last_Name))
                        {

                            business.CodigoError = 3;
                            business.DescriptionError = "The First Last Name is invalid.";
                        }
                        else
                        {
                            if (!Val.IsMatch(Second_Last_Name))
                            {
                                business.CodigoError = 5;
                                business.DescriptionError = "The Second Last Name is invalid.";
                            }
                            else
                            {
                                if (!ValEmail.IsMatch(Email))
                                {
                                    business.CodigoError = 6;
                                    business.DescriptionError = "The Email is invalid.";
                                }
                                else
                                {
                                    if (!ValEmail.IsMatch(International_Phone_Number))
                                    {
                                        business.CodigoError = 7;
                                        business.DescriptionError = "The International Phone Number is invalid.";
                                    }
                                }
                            }
                        }
                    }
                }

                if (business.CodigoError == 0 && !string.IsNullOrEmpty(business.DescriptionError))
                {
                    AppApplicants.Models.ManageApplicants manageApplicants = new AppApplicants.Models.ManageApplicants();

                    return (manageApplicants.Edit_Applicants(Consec_Applicant, Id_Job, First_Name, Second_Name, First_Last_Name, Second_Last_Name, Email, International_Phone_Number, Biography, Birthday, Street_Adress, City, Country, Postal_Code, Path_Photo_Local, Path_Photo_URL));
                }
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento se habilita la eliminación de aplicantes existentes.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public Boolean Delete_Applicants(int Consec_Applicant)
        {
            Boolean Result = false;
            BusinessModel business = new BusinessModel();

            try
            {
                AppApplicants.Models.ManageApplicants manageApplicants = new AppApplicants.Models.ManageApplicants();

                return (manageApplicants.Delete_Applicants(Consec_Applicant));
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento se habilita la consulta de los aplicantes.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public IEnumerable<Report_Applicants> Consult_Applicants(string Consec_Applicant)
        {
            IEnumerable<Report_Applicants> lstApplicants = null;

            try
            {
                if (!string.IsNullOrEmpty(Consec_Applicant))
                {
                    AppApplicants.Models.ManageApplicants manageApplicants = new AppApplicants.Models.ManageApplicants();

                    return (manageApplicants.Consult_Applicants(Consec_Applicant));
                }
            }
            catch (Exception Ex)
            {
            }

            return lstApplicants.AsEnumerable();
        }

    }
}