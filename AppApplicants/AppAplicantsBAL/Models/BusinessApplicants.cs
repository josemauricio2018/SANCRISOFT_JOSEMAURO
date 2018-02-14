using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AppApplicants;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public class BusinessApplicants
    {
        public BusinessApplicants() { 
        
        }

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


    }
}