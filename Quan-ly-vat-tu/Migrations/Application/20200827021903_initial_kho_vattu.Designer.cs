﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quan_ly_vat_tu.Models;

namespace Quan_ly_vat_tu.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200827021903_initial_kho_vattu")]
    partial class initial_kho_vattu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quan_ly_vat_tu.Models.Kho", b =>
                {
                    b.Property<int>("maKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("diaChi")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("tenKho")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maKho");

                    b.ToTable("Kho");
                });

            modelBuilder.Entity("Quan_ly_vat_tu.Models.VatTu", b =>
                {
                    b.Property<int>("maVatTu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("gia")
                        .HasColumnType("float");

                    b.Property<int>("maKho")
                        .HasColumnType("int");

                    b.Property<int>("soLuong")
                        .HasColumnType("int");

                    b.Property<string>("tenVatTu")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("maVatTu");

                    b.HasIndex("maKho");

                    b.ToTable("VatTu");
                });

            modelBuilder.Entity("Quan_ly_vat_tu.Models.VatTu", b =>
                {
                    b.HasOne("Quan_ly_vat_tu.Models.Kho", "Kho")
                        .WithMany("nVatTu")
                        .HasForeignKey("maKho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
