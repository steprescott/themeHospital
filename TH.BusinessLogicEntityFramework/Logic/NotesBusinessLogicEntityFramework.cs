using System;
using System.Collections.Generic;
using System.Linq;
using TH.UnitOfWorkEntityFramework;
using TH.Interfaces;
using TH.ReflectiveMapper;

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
                var efObject = ReflectiveMapperService.ConvertItem<Domain.Other.Note, Note>(note);
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
