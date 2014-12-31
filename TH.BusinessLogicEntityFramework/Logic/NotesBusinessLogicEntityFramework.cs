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
                var efObject = ConvertToEntityFramework(note);
                _unitOfWork.Insert(efObject);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        private Note ConvertToEntityFramework(Domain.Other.Note note)
        {
            return new Note
            {
                NoteId = note.NoteId,
                Content = note.Content,
                DateCreated = note.DateCreated,
                TreatmentId = note.TreatmentId,
                PatientUserId = note.PatientId,
                VisitId = note.VisitId
            };
        }

        private Domain.Other.Note ConvertToDomain(Note note)
        {
            return new Domain.Other.Note
            {
                NoteId = note.NoteId,
                Content = note.Content,
                DateCreated = note.DateCreated,
                TreatmentId = note.TreatmentId,
                PatientId = note.PatientUserId,
                VisitId = note.VisitId
            };
        }
    }
}
