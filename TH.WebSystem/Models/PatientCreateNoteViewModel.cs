using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TH.WebSystem.Models
{
    public class PatientCreateNoteViewModel
    {
        public Guid PatientUserId { get; set; }

        [DisplayName("Content")]
        public String NoteContent { get; set; }
    }
}