using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Treatments;

namespace TH.Interfaces
{
    public interface IMedicineBusinessLogic
    {
        bool CreateOrUpdateMedicine(Medicine medicine);

        bool DeleteMedicineWithId(Guid medicineId);
    }
}
