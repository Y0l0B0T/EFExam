using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProject.EfPersistence.SoldTickets;

public class SoldTicketEntityMap:IEntityTypeConfiguration<SoldTicket>
{
    public void Configure(EntityTypeBuilder<SoldTicket> builder)
    {
        builder.ToTable("SoldTickets");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        // builder.HasMany(_=>_.Ticket).WithOne(_=>_.SoldTicket).HasForeignKey(_ => _.SoldTicketId);
    }
}