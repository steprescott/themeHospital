using System;
using System.Collections.Generic;
using System.Linq;
using TH.Domain.Other;

namespace TH.Interfaces
{
    public interface INotesBusinessLogic
    {
        bool CreateNote(Note note);
    }
}
