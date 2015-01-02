﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThemeHospitalDatabaseContainer : DbContext
    {
        public ThemeHospitalDatabaseContainer()
            : base("name=ThemeHospitalDatabaseContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<Bed> Beds { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<WardWaitingList> WardWaitingLists { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Refusal> Refusals { get; set; }
    }
}
