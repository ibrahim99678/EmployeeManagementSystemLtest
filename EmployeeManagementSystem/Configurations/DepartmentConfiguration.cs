using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");

        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
               .ValueGeneratedOnAdd();

        builder.Property(d => d.Name)   
                .IsRequired()
                .HasMaxLength(100);

        builder.HasIndex(d => d.Name)
               .IsUnique();

        // Relationships

        builder.HasMany(d => d.Employees)
               .WithOne(e => e.Department)
               .HasForeignKey(e => e.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade);

        //Seed data
        builder.HasData(
            new Department { Id = 1, Name = "Human Resources" },
            new Department { Id = 2, Name = "Finance" },
            new Department { Id = 3, Name = "IT" },
            new Department { Id = 4, Name = "Marketing" }
        );
    }

}
    