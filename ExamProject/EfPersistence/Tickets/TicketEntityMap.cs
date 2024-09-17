using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProject.EfPersistence.Tickets;

public class TicketEntityMap:IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Price).IsRequired().HasMaxLength(10);
        builder.HasOne(_=> _.Section).WithOne(_ => _.Ticket).HasForeignKey<Ticket>(_ => _.SectionId);
    }
}