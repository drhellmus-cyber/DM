using Microsoft.EntityFrameworkCore;

namespace patient;


using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

public class PatientDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<Ordonnance> Ordonnances { get; set; }
    public DbSet<OrdonnanceDetail> OrdonnanceDetails { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<SigneOrl> SignesOrl { get; set; }
    public DbSet<ExamenClinique> ExamenCliniques { get; set; }
    public DbSet<OrdonnanceType> OrdonnanceTypes { get; set; }
    public DbSet<OrdonnanceTypeDetail> OrdonnanceTypeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Utiliser le fichier patient.db du dossier de travail de l'application.
        // Le fichier placé dans le dossier bin peut être une copie ancienne et ne
        // contient pas forcément les médicaments saisis dans la base principale.
        optionsBuilder.UseSqlite("Data Source=patient.db");
    }
}
