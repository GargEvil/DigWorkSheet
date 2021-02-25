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
        public virtual DbSet<Internet> Internets { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<WorkSheet> WorkSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DigWorkSheet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleId__25869641");
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__Accou__32E0915F");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.NumberOfContract)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Accoun__3A81B327");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Commen__398D8EEE");
            });

            modelBuilder.Entity<CustomerRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerRequest");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerR__Custo__440B1D61");

                entity.HasOne(d => d.Request)
                    .WithMany()
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerR__Reque__44FF419A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Contra__35BCFE0A");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Positi__36B12243");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Price__403A8C7D");
            });

            modelBuilder.Entity<EquipmentEmployeeWorkSheet>(entity =>
            {
                entity.ToTable("EquipmentEmployeeWorkSheet");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Emplo__4BAC3F29");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Equip__4AB81AF0");

                entity.HasOne(d => d.WorkSheet)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.WorkSheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__WorkS__4CA06362");
            });

            modelBuilder.Entity<Internet>(entity =>
            {
                entity.ToTable("Internet");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Speed)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Internets)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__Internet__Contra__2C3393D0");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Offers)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Offer__AdminId__3D5E1FD2");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.CaTv).HasColumnName("CaTV");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__Package__Contrac__300424B4");

                entity.HasOne(d => d.Internet)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.InternetId)
                    .HasConstraintName("FK__Package__Interne__2F10007B");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<WorkSheet>(entity =>
            {
                entity.ToTable("WorkSheet");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DescriptionExecutedWork).IsRequired();

                entity.Property(e => e.DescriptionReportedProblem).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.WorkSheets)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkSheet__Custo__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
