using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Configurations
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            // Table name
            builder.ToTable("Salaries");

            // Primary key
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            // Properties
            builder.Property(s => s.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(s => s.EffectiveDate)
                   .IsRequired();
            // Relationships
            builder.HasOne(s => s.Employee)
                   .WithMany(e => e.Salaries)
                   .HasForeignKey(s => s.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            builder.HasData(
                new Salary { Id = 1, EmployeeId = 1, Amount = 60000, EffectiveDate = new DateTime(2023, 1, 1) },
                new Salary { Id = 2, EmployeeId = 2, Amount = 75000, EffectiveDate = new DateTime(2023, 2, 1) },
                new Salary { Id = 3, EmployeeId = 3, Amount = 50000, EffectiveDate = new DateTime(2023, 3, 1) }
            );
        }

    }
}
