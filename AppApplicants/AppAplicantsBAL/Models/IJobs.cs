using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppApplicants.Models;

namespace AppAplicantsBAL.Models
{
    public interface IJobs
    {
        IList<Job> Consult_Job();
    }
}
