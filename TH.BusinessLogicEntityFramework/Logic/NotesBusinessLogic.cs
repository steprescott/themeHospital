using System;
using System.Collections.Generic;
using System.Linq;
using TH.Interfaces;
using TH.ReflectiveMapper;
using Note = TH.Domain.Other.Note;

namespace TH.BusinessLogicEntityFramework.Logic
{
    public class NotesBusinessLogic : INotesBusinessLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotesBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateNote(Note note)
        {
            try
            {
                var efObject = ReflectiveMapperService.ConvertItem<Note, UnitOfWorkEntityFramework.Note>(note);
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
