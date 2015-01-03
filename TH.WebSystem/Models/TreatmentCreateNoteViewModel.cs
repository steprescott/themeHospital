using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class TreatmentCreateNoteViewModel
    {
        [DisplayName("Treatment ID")]
        public Guid TreatmentId { get; set; }

        [DisplayName("Content")]
        public String NoteContent { get; set; }
    }
}