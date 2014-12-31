using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class MedicineBusinessLogicEntityFramework : IMedicineBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicineBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateOrUpdateMedicine(Domain.Treatments.Medicine medicine)
        {
            try
            {
                var efMedicine = _unitOfWork.GetById<Medicine>(medicine.MedicineId);

                if (efMedicine == null)
                {
                    efMedicine = new Medicine
                    {
                        MedicineId = medicine.MedicineId != null ? medicine.MedicineId : Guid.NewGuid()
                    };

                    _unitOfWork.Insert(efMedicine);
                }

                efMedicine.Name = medicine.Name;
                efMedicine.Description = medicine.Description;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMedicineWithId(Guid medicineId)
        {
            try
            {
                _unitOfWork.Delete(_unitOfWork.GetById<Medicine>(medicineId));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
