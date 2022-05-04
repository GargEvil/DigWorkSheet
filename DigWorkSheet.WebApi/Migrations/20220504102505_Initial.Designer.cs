﻿// <auto-generated />
using System;
using DigWorkSheet.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigWorkSheet.WebApi.Migrations
{
    [DbContext(typeof(DigWorkSheetContext))]
    [Migration("20220504102505_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfContract")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ContractId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.CustomerRequest", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RequestId");

                    b.ToTable("CustomerRequest");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfEquipment")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.EquipmentEmployeeWorkSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("WorkSheetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("WorkSheetId");

                    b.ToTable("EquipmentEmployeeWorkSheet");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Internet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Speed")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Internet");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("CaTv")
                        .HasColumnType("bit")
                        .HasColumnName("CaTV");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<int?>("InternetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("InternetId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.WorkSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("DescriptionExecutedWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionReportedProblem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("WorkSheet");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Account", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Account__RoleId__25869641");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Administrator", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Account", "Account")
                        .WithMany("Administrators")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Administr__Accou__32E0915F")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Customer", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Customer__Accoun__3A81B327")
                        .IsRequired();

                    b.HasOne("DigWorkSheet.WebApi.Database.Contract", "Contract")
                        .WithMany("Customers")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK__Customer__Commen__398D8EEE")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.CustomerRequest", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__CustomerR__Custo__440B1D61")
                        .IsRequired();

                    b.HasOne("DigWorkSheet.WebApi.Database.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .HasConstraintName("FK__CustomerR__Reque__44FF419A")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Employee", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Contract", "Contract")
                        .WithMany("Employees")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK__Employee__Contra__35BCFE0A")
                        .IsRequired();

                    b.HasOne("DigWorkSheet.WebApi.Database.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__Employee__Positi__36B12243")
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Equipment", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Employee", "Employee")
                        .WithMany("Equipment")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Equipment__Price__403A8C7D")
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.EquipmentEmployeeWorkSheet", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Employee", "Employee")
                        .WithMany("EquipmentEmployeeWorkSheets")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Equipment__Emplo__4BAC3F29")
                        .IsRequired();

                    b.HasOne("DigWorkSheet.WebApi.Database.Equipment", "Equipment")
                        .WithMany("EquipmentEmployeeWorkSheets")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("FK__Equipment__Equip__4AB81AF0")
                        .IsRequired();

                    b.HasOne("DigWorkSheet.WebApi.Database.WorkSheet", "WorkSheet")
                        .WithMany("EquipmentEmployeeWorkSheets")
                        .HasForeignKey("WorkSheetId")
                        .HasConstraintName("FK__Equipment__WorkS__4CA06362")
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Equipment");

                    b.Navigation("WorkSheet");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Internet", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Contract", "Contract")
                        .WithMany("Internets")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK__Internet__Contra__2C3393D0");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Offer", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Administrator", "Admin")
                        .WithMany("Offers")
                        .HasForeignKey("AdminId")
                        .HasConstraintName("FK__Offer__AdminId__3D5E1FD2")
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Package", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Contract", "Contract")
                        .WithMany("Packages")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK__Package__Contrac__300424B4");

                    b.HasOne("DigWorkSheet.WebApi.Database.Internet", "Internet")
                        .WithMany("Packages")
                        .HasForeignKey("InternetId")
                        .HasConstraintName("FK__Package__Interne__2F10007B");

                    b.Navigation("Contract");

                    b.Navigation("Internet");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.WorkSheet", b =>
                {
                    b.HasOne("DigWorkSheet.WebApi.Database.Customer", "Customer")
                        .WithMany("WorkSheets")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__WorkSheet__Custo__47DBAE45")
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Account", b =>
                {
                    b.Navigation("Administrators");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Administrator", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Contract", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("Internets");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Customer", b =>
                {
                    b.Navigation("WorkSheets");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Employee", b =>
                {
                    b.Navigation("Equipment");

                    b.Navigation("EquipmentEmployeeWorkSheets");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Equipment", b =>
                {
                    b.Navigation("EquipmentEmployeeWorkSheets");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Internet", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DigWorkSheet.WebApi.Database.WorkSheet", b =>
                {
                    b.Navigation("EquipmentEmployeeWorkSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
