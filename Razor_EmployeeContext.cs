using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace STW_demo_ODATA
{
    public partial class Razor_EmployeeContext : DbContext
    {
        public Razor_EmployeeContext()
        {
        }

        public Razor_EmployeeContext(DbContextOptions<Razor_EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benifit> Benifits { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeBenifit> EmployeeBenifits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Benifit>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<EmployeeBenifit>(entity =>
            {
                entity.HasIndex(e => e.BenifitId, "IX_EmployeeBenifits_BenifitId");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeBenifits_EmployeeId");

                entity.Property(e => e.Fromdate).HasColumnName("fromdate");

                entity.HasOne(d => d.Benifit)
                    .WithMany(p => p.EmployeeBenifits)
                    .HasForeignKey(d => d.BenifitId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeBenifits)
                    .HasForeignKey(d => d.EmployeeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
