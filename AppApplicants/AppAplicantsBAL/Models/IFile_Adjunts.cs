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
        Boolean Create_Files_Adjunt(int Id_Applicant, string Path_File_Local, string Path_File_URL, string Description_File);
        Boolean Delete_File_Adjunts(int Consec_Applicant);
        string GetMimeType(string FileName);
        IEnumerable<Files_Adjunt> Consult_File_Adjunts(string Consec_Applicant);
    }
}
