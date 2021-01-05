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
        public virtual DbSet<WorkSheet> WorkSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
                    .HasMaxLength(1);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("Administrator");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.City)
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
                    .HasConstraintName("FK__Administr__Accou__300424B4");
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
                    .HasConstraintName("FK__Customer__Accoun__37A5467C");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__Commen__36B12243");
            });

            modelBuilder.Entity<CustomerRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerRequest");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerR__Custo__412EB0B6");

                entity.HasOne(d => d.Request)
                    .WithMany()
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerR__Reque__4222D4EF");
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
                    .HasConstraintName("FK__Employee__Contra__32E0915F");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Positi__33D4B598");
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
                    .HasConstraintName("FK__Equipment__Price__3D5E1FD2");
            });

            modelBuilder.Entity<EquipmentEmployeeWorkSheet>(entity =>
            {
                entity.ToTable("EquipmentEmployeeWorkSheet");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Emplo__48CFD27E");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Equip__47DBAE45");

                entity.HasOne(d => d.WorkSheet)
                    .WithMany(p => p.EquipmentEmployeeWorkSheets)
                    .HasForeignKey(d => d.WorkSheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__WorkS__49C3F6B7");
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
                    .HasConstraintName("FK__Internet__Contra__29572725");
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
                    .HasConstraintName("FK__Offer__AdminId__3A81B327");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.CaTv).HasColumnName("CaTV");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__Package__Contrac__2D27B809");

                entity.HasOne(d => d.Internet)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.InternetId)
                    .HasConstraintName("FK__Package__Interne__2C3393D0");
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
                    .HasConstraintName("FK__WorkSheet__Custo__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
