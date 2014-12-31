using System;
using System.Collections.Generic;
using System.Linq;
using TH.UnitOfWorkEntityFramework;
using TH.Interfaces;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class NotesBusinessLogicEntityFramework : INotesBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotesBusinessLogicEntityFramework(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateNote(Domain.Other.Note note)
        {
            try
            {
                var efObject = ConvertToEntityFramework(note, true);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public static Note ConvertToEntityFramework(Domain.Other.Note note, bool solvedNested = false)
        {
            var obj = new Note
            {
                NoteId = note.NoteId,
                Content = note.Content,
                DateCreated = note.DateCreated,
                TreatmentId = note.TreatmentId,
                PatientUserId = note.PatientId,
                VisitId = note.VisitId
            };

            if (solvedNested)
            {
                //TODO : This
                //obj.Treatment = 
                obj.Patient = PatientBusinessLogicEntityFramework.ConvertToEntityFramework(note.Patient);
                obj.Visit = VisitBusinessLogicEntityFramework.ConvertToEntityFramework(note.Visit);
            }

            return obj;
        }

        public static Domain.Other.Note ConvertToDomain(Note note, bool solvedNested = false)
        {
            var obj = new Domain.Other.Note
            {
                NoteId = note.NoteId,
                Content = note.Content,
                DateCreated = note.DateCreated,
                TreatmentId = note.TreatmentId,
                PatientId = note.PatientUserId,
                VisitId = note.VisitId
            };

            if (solvedNested)
            {
                //obj.Treatment = 
                obj.Patient = PatientBusinessLogicEntityFramework.ConvertToDomain(note.Patient);
                obj.Visit = VisitBusinessLogicEntityFramework.ConvertToDomain(note.Visit);
            }

            return obj;
        }
    }
}
