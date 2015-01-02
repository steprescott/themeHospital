using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface IMedicineBusinessLogic
    {
        bool CreateOrUpdateMedicine(Medicine medicine);

        bool DeleteMedicineWithId(Guid medicineId);

        List<Domain.Treatments.Medicine> GetAllMedicines();

        Domain.Treatments.Medicine GetMedicineById(Guid id);
    }
}
