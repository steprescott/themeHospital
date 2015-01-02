using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
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
            var efObject = _unitOfWork.GetById<Medicine>(medicine.MedicineId);

            try
            {
                if (efObject == null)
                {
                    efObject = new Medicine
                    {
                        MedicineId = medicine.MedicineId != Guid.Empty ? medicine.MedicineId : Guid.NewGuid()
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Domain.Treatments.Medicine> GetAllMedicines()
        {
            var medicines = _unitOfWork.GetAll<Medicine>().ToList().OrderBy(o => o.Name);
            return medicines.Select(o => ReflectiveMapperService.ConvertItem<Medicine, Domain.Treatments.Medicine>(o)).ToList();
        }

        public Domain.Treatments.Medicine GetMedicineById(Guid id)
        {
            Medicine medicine = _unitOfWork.GetById<Medicine>(id);
            return ReflectiveMapperService.ConvertItem<Medicine, Domain.Treatments.Medicine>(medicine);
        }
    }
}
