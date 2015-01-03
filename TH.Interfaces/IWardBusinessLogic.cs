using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Wards;

namespace TH.Interfaces
{
    public interface IWardBusinessLogic
    {
        List<Domain.Wards.Ward> GetAllWards();
        bool CreateOrUpdateWard(Ward ward);
        bool AssignPatientToWardWaitingList(Guid wardId, Guid patientId);
        Domain.Wards.Ward GetWardWithId(Guid id);
        List<Domain.Other.Bed> AvailableBedsForWardWithId(Guid id);
    }
}
