
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public interface IFile_Adjunts
    {
        //string GetMimeType(string FileName);
        IEnumerable<Files_Adjunt> Consult_File_Adjunt(string Consec_Applicant);
        Boolean Create_File_Adjunt(int Id_Applicant, string File_Name, string Type_File, decimal Size, string Path_File_Local, string Path_File_URL, string Description_File);
    }
}
