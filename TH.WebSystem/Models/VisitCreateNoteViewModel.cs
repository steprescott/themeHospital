using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class VisitCreateNoteViewModel
    {
        [DisplayName("Visit ID")]
        public Guid VisitId { get; set; }

        [DisplayName("Content")]
        public String NoteContent { get; set; }
    }
}