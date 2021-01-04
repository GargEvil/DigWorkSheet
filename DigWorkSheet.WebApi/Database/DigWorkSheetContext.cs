using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class DigWorkSheetContext : DbContext
    {
        public DigWorkSheetContext()
        {
        }

        public DigWorkSheetContext(DbContextOptions<DigWorkSheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRequest> CustomerRequests { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentEmployeeWorkSheet> EquipmentEmployeeWorkSheets { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<WorkSheet> WorkSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=DigWorkSheet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Administr__Accou__2A4B4B5E");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.NumberOfContract)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Accoun__31EC6D26");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Commen__30F848ED");
            });

            modelBuilder.Entity<CustomerRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerRequest");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerR__Custo__3B75D760");

                entity.HasOne(d => d.Request)
                    .WithMany()
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerR__Reque__3C69FB99");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Contra__2D27B809");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Positi__2E1BDC42");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Price__37A5467C");
            });

            modelBuilder.Entity<EquipmentEmployeeWorkSheet>(entity =>
            {
                entity.ToTable("EquipmentEmployeeWorkSheet");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Emplo__4316F928");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Equip__4222D4EF");

                entity.HasOne(d => d.WorkSheet)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.WorkSheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__WorkS__440B1D61");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Picture).IsRequired();

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__AdminId__34C8D9D1");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<WorkSheet>(entity =>
            {
                entity.ToTable("WorkSheet");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DescriptionExecutedWork).IsRequired();

                entity.Property(e => e.DescriptionReportedProblem).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.WorkSheets)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkSheet__Custo__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
