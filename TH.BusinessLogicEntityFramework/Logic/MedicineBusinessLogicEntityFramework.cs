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
                var efObject = _unitOfWork.GetById<Medicine>(medicine.MedicineId);

                if (efObject == null)
                {
                    efObject = new Medicine
                    {
                        MedicineId = medicine.MedicineId != Guid.Empty ? medicine.MedicineId : Guid.NewGuid(),
                        Name = medicine.Name,
                        Description = medicine.Description
                    };

                    _unitOfWork.Insert(efObject);
                }
                else
                {
                    efObject.Name = medicine.Name;
                    efObject.Description = medicine.Description;
                    _unitOfWork.Update(efObject);
                }

                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public bool DeleteMedicineWithId(Guid medicineId)
        {
            try
            {
                _unitOfWork.Delete(_unitOfWork.GetById<Medicine>(medicineId));
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static Medicine ConvertToEntityFramework(Domain.Treatments.Medicine medicine, bool solvedNested = false)
        {
            var obj = new Medicine
            {
                MedicineId = medicine.MedicineId,
                Name = medicine.Name,
                Description = medicine.Description,
            };

            if (solvedNested)
            {
                obj.CourseOfMedicines = medicine.CourseOfMedicines.Select(i => CourseOfMedicineBusinessLogicEntityFramework.ConvertToEntityFramework(i)).ToList();
            }

            return obj;
        }

        public static Domain.Treatments.Medicine ConvertToDomain(Medicine medicine, bool solvedNested = false)
        {
            var obj = new Domain.Treatments.Medicine
            {
                MedicineId = medicine.MedicineId,
                Name = medicine.Name,
                Description = medicine.Description,
            };

            if (solvedNested)
            {
                obj.CourseOfMedicines = medicine.CourseOfMedicines.Select(i => CourseOfMedicineBusinessLogicEntityFramework.ConvertToDomain(i)).ToList();
            }

            return obj;
        }
    }
}
