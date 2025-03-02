﻿using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
            
        }

        public HospitalContext(DbContextOptions options)
            : base(options) 
        {
            
        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=HospitalDatabase;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(e =>
            {
                e.HasKey(p => new { p.PatientId, p.MedicamentId });
            });
        }
    }
}
