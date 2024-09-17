using ExamProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProject.EfPersistence.Zoos;

public class ZooEntityMap:IEntityTypeConfiguration<Zoo>
{
    public void Configure(EntityTypeBuilder<Zoo> builder)
    {
        builder.ToTable("Zoos");
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).UseIdentityColumn();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.Property(_ => _.Address).IsRequired().HasMaxLength(50);
        builder.HasMany(_=>_.Sections).WithOne(_=>_.Zoo).HasForeignKey(zoo => zoo.ZooId).OnDelete(DeleteBehavior.Cascade);
    }
}