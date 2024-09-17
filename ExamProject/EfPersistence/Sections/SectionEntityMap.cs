using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProject.EfPersistence.Sections;

public class SectionEntityMap:IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.Property(_ => _.Description).IsRequired(false).HasMaxLength(50);
        builder.Property(_ => _.Area).IsRequired().HasMaxLength(10);
        builder.Property(_ => _.AnimalCount).IsRequired().HasMaxLength(10);
        builder.HasOne(_ => _.Animal).WithMany(_ => _.Sections).HasForeignKey(_ => _.AnimalId).OnDelete(DeleteBehavior.Cascade);
        // builder.HasOne(_=> _.Ticket).WithOne(_ => _.Section).HasForeignKey<Section>(_ => _.TicketId);
    }
}