using Microsoft.EntityFrameworkCore;

namespace patient;


public class  PatientDbContext : DbContext

{
	public DbSet<Patient> Patients {  get; set; }
    public DbSet<Consultation> Consultations { get; set; }

     public DbSet<Ordonnance> Ordonnances { get; set; }
public DbSet<OrdonnanceDetail> OrdonnanceDetails { get; set; }
public DbSet<Medicament> Medicaments {  get; set; }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    //srting connctionstring=
         optionsBuilder.UseSqlite("Data Source=patient.db");
}


}
