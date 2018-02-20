using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public class BusinessFile_Adjunts : IFile_Adjunts
    {
        public BusinessFile_Adjunts() {
        
        }

        /// <summary>
        /// En este procedimiento permite se habilita la adición de nuevos archivos adjuntos del aplicante.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public Boolean Create_File_Adjunt(int Id_Applicant, string File_Name, string Type_File, decimal Size, string Path_File_Local, string Path_File_URL, string Description_File)
        {
            Boolean Result = false;

            try
            {
                Result = true;

                AppApplicants.Models.ManageFile_Adjunts manageFile_Adjunts = new AppApplicants.Models.ManageFile_Adjunts();

                return (manageFile_Adjunts.Create_File_Adjunt(Id_Applicant, File_Name, Type_File, Size, Path_File_Local, Path_File_URL, Description_File));

                //Obtener el consecutivo del archivo adjunto insertado.
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento permite se habilita la consulta de los archivos adjuntos del aplicante.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public IEnumerable<Files_Adjunt> Consult_File_Adjunt(string Consec_Applicant)
        {
            IEnumerable<Files_Adjunt> lstFile_Adjunt = null;

            try
            {
                if (!string.IsNullOrEmpty(Consec_Applicant))
                {
                    AppApplicants.Models.ManageFile_Adjunts manageFile_Adjunts = new AppApplicants.Models.ManageFile_Adjunts();

                    return (manageFile_Adjunts.Consult_File_Adjunt(Consec_Applicant));
                }
            }
            catch (Exception Ex)
            {
            }

            return lstFile_Adjunt.AsEnumerable();
        }

    }
}