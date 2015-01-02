using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class VisitCreateNoteViewModel
    {
        public Guid VisitId { get; set; }
        public String NoteContent { get; set; }
    }
}