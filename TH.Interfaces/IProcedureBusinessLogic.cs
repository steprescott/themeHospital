using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface IProcedureBusinessLogic
    {
        bool CreateProcedure(Procedure procedure);
        Procedure GetProcedureWithId(Guid id);
        List<Procedure> GetProceduresToBeAdministeredByStaffMemberId(Guid userId);
        List<Procedure> GetProceduresForTeamByConsultantId(Guid userId);
        List<Procedure> GetProceduresScheduledForPatientId(Guid patientId);
        bool AdministorProcedureWithId(Guid id, Guid administoredByUserId);
    }
}
