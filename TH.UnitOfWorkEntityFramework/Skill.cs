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
    
    public partial class Skill
    {
        public Skill()
        {
            this.Consultants = new HashSet<Consultant>();
        }
    
        public System.Guid SkillId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Consultant> Consultants { get; set; }
    }
}
