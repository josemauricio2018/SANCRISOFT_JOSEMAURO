using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public interface IApplicants
    {
        Boolean Create_Applicants(int Id_Job, string First_Name, string Second_Name, string First_Last_Name, string Second_Last_Name, string Email, string International_Phone_Number, string Biography, DateTime Birthday, string Street_Adress, string City, string Country, string Postal_Code, string Path_Photo_Local, string Path_Photo_URL);
        Boolean Edit_Applicants(int Consec_Applicant, int Id_Job, string First_Name, string Second_Name, string First_Last_Name, string Second_Last_Name, string Email, string International_Phone_Number, string Biography, DateTime Birthday, string Street_Adress, string City, string Country, string Postal_Code, string Path_Photo_Local, string Path_Photo_URL);
        Boolean Delete_Applicants(int Consec_Applicant);
        IEnumerable<Report_Applicants> Consult_Applicants(string Consec_Applicant);
    }
}
