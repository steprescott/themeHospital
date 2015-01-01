using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                var efMedicine = _unitOfWork.GetById<Medicine>(medicine.MedicineId);

                if (efMedicine == null)
                {
                    efMedicine = new Medicine
                    {
                        MedicineId = medicine.MedicineId != Guid.Empty ? medicine.MedicineId : Guid.NewGuid()
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

        public List<Domain.Treatments.CourseOfMedicine> GetCoursesOfMedicinesToBeAdministeredByStaffMemberId(Guid userId)
        {
            var coursesOfMedicines = _unitOfWork.GetAll<CourseOfMedicine>().ToList();

            coursesOfMedicines = coursesOfMedicines.Where(com => com.AdministeredByUserId == userId).ToList();

            return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<CourseOfMedicine, Domain.Treatments.CourseOfMedicine>(com)).ToList();
        }

        public List<Domain.Treatments.CourseOfMedicine> GetCoursesOfMedicinesForTeamId(Guid teamId)
        {
            var coursesOfMedicines = _unitOfWork.GetAll<CourseOfMedicine>().ToList();

            coursesOfMedicines = coursesOfMedicines.Where(com => com.AdministeredByUserId == userId).ToList();

            return coursesOfMedicines.Select(com => ReflectiveMapperService.ConvertItem<CourseOfMedicine, Domain.Treatments.CourseOfMedicine>(com)).ToList();
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
