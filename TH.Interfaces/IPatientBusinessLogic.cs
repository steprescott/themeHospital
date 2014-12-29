using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface IPatientBusinessLogic
    {
        Patient GetPatientWithId(Guid userId);
        IEnumerable<Patient> GetAllPatients();
        bool InsertOrUpdatePatient(Patient domainPatient);
        bool DeletePatientWithId(Guid userId);
        bool DeletePatient(Patient domainPatient);
        List<Patient> SearchPatient(string searchText);
        bool IsOpenVisitForPatient(Guid patientId);
        bool AdmitPatient(Guid patientId, Guid teamId);
        Visit GetCurrentVisitForPatientId(Guid patientId);
    }
}
