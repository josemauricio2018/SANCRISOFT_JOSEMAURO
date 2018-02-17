using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppApplicants.Models
{
    public class ManageFile_Adjunts
    {
        private BD_APPLICANTSEntities3 dbApplicantContext = new BD_APPLICANTSEntities3();

        public ManageFile_Adjunts() { 
        
        }

        /// <summary>
        /// En este procedimiento se graba los datos de los archivos adjuntos por el aplicante. 
        /// </summary>
        /// <param name="Id_Applicant"></param>
        /// <param name="File_Name"></param>
        /// <param name="Type_File"></param>
        /// <param name="Size"></param>
        /// <param name="Path_File_Local"></param>
        /// <param name="Path_File_URL"></param>
        /// <param name="Description_File"></param>
        /// <returns></returns>
        public Boolean Create_File_Adjunt(int Id_Applicant, string File_Name, string Type_File, decimal Size, string Path_File_Local, string Path_File_URL, string Description_File)
        {
            Boolean Result = false;

            try
            {
                Files_Adjunt File_Adjunt = new Files_Adjunt();
                File_Adjunt.Id_Applicant = Id_Applicant;
                File_Adjunt.File_Name=File_Name;
                File_Adjunt.Tipe_File=Type_File;
                File_Adjunt.Size=Size;
                File_Adjunt.Path_File_Local=Path_File_Local;
                File_Adjunt.Path_File_URL=Path_File_URL;
                File_Adjunt.Description_File = Description_File;

                dbApplicantContext.SP_INSERT_FILE_ADJUNT(File_Adjunt.Id_Applicant, File_Adjunt.File_Name, File_Adjunt.Tipe_File, File_Adjunt.Size, File_Adjunt.Path_File_Local, File_Adjunt.Path_File_URL, File_Adjunt.Description_File);

                //Obtener el consecutivo del archivo adjunto insertado.

                Result = true;
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// En este procedimiento se eliminan los datos de los archivos adjuntos del aplicante.
        /// </summary>
        /// <param name="Consec_File_Adjunt"></param>
        /// <returns></returns>
        public Boolean Delete_File_Adjunt(int Consec_File_Adjunt)
        {
            Boolean Result = false;

            try
            {
                dbApplicantContext.SP_DELETE_APPLICANT(Consec_File_Adjunt);

                Result = true;
            }
            catch (Exception Ex)
            {
            }

            return Result;
        }

        /// <summary>
        /// Este procediiento permite consultar los datos de los archivos adjuntos del aplicante.
        /// </summary>
        /// <param name="Consec_Applicant"></param>
        /// <returns></returns>
        public IEnumerable<Files_Adjunt> Consult_File_Adjunt(string Consec_Applicant)
        {
            List<Files_Adjunt> lstFile_Adjunt = new List<Files_Adjunt>();

            try
            {
                if (!string.IsNullOrEmpty(Consec_Applicant))
                {

                    var consultFiles_Adjunt = dbApplicantContext.SP_CONSULT_FILE_ADJUNT(Convert.ToInt32(Consec_Applicant));

                    foreach (var item in consultFiles_Adjunt)
                    {
                        lstFile_Adjunt.Add(new Files_Adjunt()
                        {
                            Consecutive = item.Consecutive,
                            File_Name = item.File_Name,
                            Tipe_File = item.Tipe_File,
                            Size = item.Size,
                            Path_File_Local = item.Path_File_Local,
                            Path_File_URL = item.Path_File_URL,
                            Description_File = item.Description_File
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
            }

            return lstFile_Adjunt.AsEnumerable();
        }
    }
}