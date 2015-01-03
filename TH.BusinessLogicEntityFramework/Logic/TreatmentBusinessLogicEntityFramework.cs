using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using TH.UnitOfWorkEntityFramework;
using Treatment = TH.Domain.Treatments.Treatment;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class TreatmentBusinessLogicEntityFramework : ITreatmentBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Treatment GetTreatmentById(Guid treatmentId)
        {
            var treatment = _unitOfWork.GetById<UnitOfWorkEntityFramework.Treatment>(treatmentId);

            return ReflectiveMapperService.ConvertItem<UnitOfWorkEntityFramework.Treatment, Treatment>(treatment);
        }

        public string GetTreatmentName(Guid treatmentId)
        {
            var procedure = _unitOfWork.GetInheritedSubTypeObjects<UnitOfWorkEntityFramework.Treatment, Procedure>()
                .SingleOrDefault(p => p.TreatmentId == treatmentId);

            if (procedure == null)
            {
                var coursesOfMedicine = _unitOfWork.GetInheritedSubTypeObjects<UnitOfWorkEntityFramework.Treatment, CourseOfMedicine>()
                    .SingleOrDefault(com => com.TreatmentId == treatmentId);

                if (coursesOfMedicine == null)
                {
                    return string.Empty;
                }

                return coursesOfMedicine.Medicine.Name;
            }
            return procedure.Operation.Name;
        }

        public bool RecordRefusalOfTreatment(Guid treatmentId, string refusalReason)
        {
            var treatment = _unitOfWork.GetById<UnitOfWorkEntityFramework.Treatment>(treatmentId);
            
            if (treatment != null)
            {
                try
                {
                    var refusal = new Refusal
                    {
                        RefusalId = Guid.NewGuid(),
                        Note = new Note
                        {
                            NoteId = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            Content = refusalReason
                        },
                        Treatment = treatment
                    };

                    treatment.Refusal = refusal;

                    _unitOfWork.Update(treatment);
                    _unitOfWork.SaveChanges();

                    return true;
                }
                catch (Exception exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
