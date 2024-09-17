using ExamProject.EfPersistence.Animals;
using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.EfPersistence;

public class EfDataContext : DbContext
{
    public DbSet<Animal> Animals  { get; set; }
    public DbSet<Section> Sections  { get; set; }
    public DbSet<Ticket> Tickets  { get; set; }
    public DbSet<SoldTicket> SoldTickets { get; set; }
    public DbSet<Zoo> Zoos  { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "data source=.; initial catalog=EfExam; integrated security=true; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimalEntityMap).Assembly);
    }
}