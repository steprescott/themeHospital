//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TH.UnitOfWorkEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consultant : StaffMember
    {
        public Consultant()
        {
            this.Skills = new HashSet<Skill>();
        }
    
    
        public virtual Team Team { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
