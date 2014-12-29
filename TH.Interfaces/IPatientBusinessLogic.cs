using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IPatientBusinessLogic
    {
        Domain.User.Patient GetPatientWithId(Guid userId);
        IEnumerable<Patient> GetAllPatients();
        bool InsertOrUpdatePatient(Domain.User.Patient domainPatient);
        bool DeletePatientWithId(Guid userId);
        bool DeletePatient(Domain.User.Patient domainPatient);
        List<Domain.User.Patient> SearchPatient(string searchText);
    }
}
