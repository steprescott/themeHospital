using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface ITreatmentBusinessLogic
    {
        string GetTreatmentName(Guid treatmentId);
        bool RecordRefusalOfTreatment(Guid treatmentId, string refusalReason);
        Treatment GetTreatmentById(Guid treatmentId);
    }
}
