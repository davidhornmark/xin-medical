using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using xin_medical.Models;

namespace xin_medical.DAL
{
    public class MedicalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalHistoryEntry> MedicalHistoryEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<Patient>().HasMany(p => p.MedicalHistoryEntries).WithRequired(m => m.Patient);
            modelBuilder.Entity<MedicalHistoryEntry>()
                .HasRequired(m => m.Patient)
                .WithMany(p => p.MedicalHistoryEntries)
                .HasForeignKey(p => p.PatientID);
        }
    }
}