using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using Medicine = TH.Domain.Treatments.Medicine;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class MedicineBusinessLogic : IMedicineBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicineBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateOrUpdateMedicine(Medicine medicine)
        {
            var efObject = _unitOfWork.GetById<UnitOfWorkEntityFramework.Medicine>(medicine.MedicineId);

            try
            {
                if (efObject == null)
                {
                    efObject = new UnitOfWorkEntityFramework.Medicine
                    {
                        MedicineId = medicine.MedicineId != Guid.Empty ? medicine.MedicineId : Guid.NewGuid()
                    };
                    efObject.Name = medicine.Name;
                    efObject.Description = medicine.Description;

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
                _unitOfWork.Delete(_unitOfWork.GetById<UnitOfWorkEntityFramework.Medicine>(medicineId));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Medicine> GetAllMedicines()
        {
            var medicines = _unitOfWork.GetAll<UnitOfWorkEntityFramework.Medicine>().ToList().OrderBy(o => o.Name);
            return medicines.Select(o => ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Medicine, Medicine>(o)).ToList();
        }

        public Medicine GetMedicineById(Guid id)
        {
            UnitOfWorkEntityFramework.Medicine medicine = _unitOfWork.GetById<UnitOfWorkEntityFramework.Medicine>(id);
            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Medicine, Medicine>(medicine);
        }
    }
}
