﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrzychodniaEntities : DbContext
    {
        public PrzychodniaEntities()
            : base("name=PrzychodniaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Badania> Badania { get; set; }
        public virtual DbSet<Dokumentacja> Dokumentacja { get; set; }
        public virtual DbSet<HistoriaChorob> HistoriaChorob { get; set; }
        public virtual DbSet<Lekarze> Lekarze { get; set; }
        public virtual DbSet<LekarzOddzial> LekarzOddzial { get; set; }
        public virtual DbSet<Leki> Leki { get; set; }
        public virtual DbSet<Oddzialy> Oddzialy { get; set; }
        public virtual DbSet<Pacjenci> Pacjenci { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<PersonelOddzial> PersonelOddzial { get; set; }
        public virtual DbSet<Platnosci> Platnosci { get; set; }
        public virtual DbSet<ReceptaLeki> ReceptaLeki { get; set; }
        public virtual DbSet<Recepty> Recepty { get; set; }
        public virtual DbSet<Skierowanie> Skierowanie { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Wizyty> Wizyty { get; set; }
        public virtual DbSet<Towar> Towar { get; set; }
        public virtual DbSet<Faktury> Faktury { get; set; }
    }
}
