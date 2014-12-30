using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Domain.Other;
using TH.Domain.Treatments;
using TH.Domain.User;

namespace TH.Interfaces
{
    public interface INotesBusinessLogic
    {
        bool CreateNote(Note note);
    }
}
