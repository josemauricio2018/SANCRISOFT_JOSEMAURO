using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppApplicants.Models
{
    public class ManageJobs
    {
        private BD_APPLICANTSEntities1 dbApplicantContext = new BD_APPLICANTSEntities1();

        public ManageJobs() { 
        
        }

        /// <summary>
        /// En este procedimiento se consultan los datos de todos los cargos.
        /// </summary>
        /// <returns></returns>
        public IList<Job> Consult_Job()
        {
            IList<Job> lstJob = new List<Job>();

            try
            {
                var consultJobs = dbApplicantContext.SP_CONSULT_JOB();

                foreach (var item in consultJobs)
                {
                    lstJob.Add(new Job()
                    {
                        Consecutive = item.Consecutive,
                        Name = item.Name_Job
                    });
                }
            }
            catch (Exception Ex)
            {
            }

            return lstJob;
        }

    }
}