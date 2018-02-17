using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public class BusinessJob : IJobs
    {
        public BusinessJob() { 
        
        }

        /// <summary>
        /// En este procedimiento se habilita la consulta de los cargos.
        /// </summary>
        /// <returns></returns>
        public IList<Job> Consult_Job()
        {
            IList<Job> lstJobs = null;

            try
            {
                AppApplicants.Models.ManageJobs manageJobs = new AppApplicants.Models.ManageJobs();

                lstJobs = manageJobs.Consult_Job();
            }
            catch (Exception Ex)
            {
            }

            return lstJobs;
        }

    }
}