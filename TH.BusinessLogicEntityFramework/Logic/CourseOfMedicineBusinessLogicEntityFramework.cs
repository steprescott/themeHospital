using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class CourseOfMedicineBusinessLogicEntityFramework : ICourseOfMedicineBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseOfMedicineBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateCauseOfMedicne(Domain.Treatments.CourseOfMedicine courseOfMedicine)
        {
            try
            {
                CourseOfMedicine efObject = ReflectiveMapperService.ConvertItem<Domain.Treatments.CourseOfMedicine, CourseOfMedicine>(courseOfMedicine);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
