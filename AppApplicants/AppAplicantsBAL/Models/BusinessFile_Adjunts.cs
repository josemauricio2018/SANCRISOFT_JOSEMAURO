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
        public Boolean Create_File_Adjunt()
        {
            Boolean Result = false;

            try
            {
                /*Files_Adjunt File_Adjunt = new Files_Adjunt();
                File_Adjunt.Id_Applicant = Id_Applicant;
                File_Adjunt.File_Name = File_Name;
                File_Adjunt.Tipe_File = Type_File;
                File_Adjunt.Size = Size;
                File_Adjunt.Path_File_Local = Path_File_Local;
                File_Adjunt.Path_File_URL = Path_File_URL;
                File_Adjunt.Description_File = Description_File;

                dbApplicantContext.SP_INSERT_FILE_ADJUNT(File_Adjunt.Id_Applicant, File_Adjunt.File_Name, File_Adjunt.Tipe_File, File_Adjunt.Size, File_Adjunt.Path_File_Local, File_Adjunt.Path_File_URL, File_Adjunt.Description_File);
                */

                //Obtener el consecutivo del archivo adjunto insertado.

                Result = true;
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