using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table name
            builder.ToTable("Employees");

            // Primary key
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // Properties

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.LastName)
                     .IsRequired()
                     .HasMaxLength(50);

            builder.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.Salary)
                     .IsRequired()
                     .HasColumnType("decimal(18,2)");

            builder.Property(e => e.HireDate)
                        .IsRequired();

            // Relationships
            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);


            // Seed data
            builder.HasData(
            new Employee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Salary = new Salary
                {
                    Amount = 55000,
                    EffectiveDate = new DateTime(2020, 5, 12)
                },
                HireDate = new DateTime(2020, 5, 12),
                DepartmentId = 1
            },
            new Employee
            {
                Id = 2,
                FirstName = "Sara",
                LastName = "Ahmed",
                Email = "sara.ahmed@example.com",
                Salary = new Salary
                {
                    Amount = 60000,
                    EffectiveDate = new DateTime(2021, 2, 20)
                },
                HireDate = new DateTime(2021, 2, 20),
                DepartmentId = 2
            },
            new Employee
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Smith",
                Email = "michael.smith@example.com",
                Salary = new Salary
                {
                    Amount = 72000,
                    EffectiveDate = new DateTime(2019, 8, 15)
                },
                HireDate = new DateTime(2019, 8, 15),
                DepartmentId = 3
            },
            new Employee
            {
                Id = 4,
                FirstName = "Nadia",
                LastName = "Rahman",
                Email = "nadia.rahman@example.com",
                Salary = new Salary
                {
                    Amount = 48000,
                    EffectiveDate = new DateTime(2022, 1, 5)
                },
                HireDate = new DateTime(2022, 1, 5),
                DepartmentId = 4
            }
        );

        }
    }
}
