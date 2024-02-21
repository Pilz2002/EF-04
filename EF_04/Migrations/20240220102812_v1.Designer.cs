﻿// <auto-generated />
using System;
using EF_04.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_04.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240220102812_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_04.Entity.ChiTietPhieuThu", b =>
                {
                    b.Property<int>("ChiTietPhieuThuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietPhieuThuId"));

                    b.Property<int>("NguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int>("PhieuThuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongBan")
                        .HasColumnType("int");

                    b.HasKey("ChiTietPhieuThuId");

                    b.HasIndex("NguyenLieuId");

                    b.HasIndex("PhieuThuId");

                    b.ToTable("ChiTietPhieuThu");
                });

            modelBuilder.Entity("EF_04.Entity.LoaiNguyenLieu", b =>
                {
                    b.Property<int>("LoaiNguyenLieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiNguyenLieuId"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiNguyenLieuId");

                    b.ToTable("LoaiNguyenLieu");
                });

            modelBuilder.Entity("EF_04.Entity.NguyenLieu", b =>
                {
                    b.Property<int>("NguyenLieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguyenLieuId"));

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiaBan")
                        .HasColumnType("int");

                    b.Property<int>("LoaiNguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongKho")
                        .HasColumnType("int");

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NguyenLieuId");

                    b.HasIndex("LoaiNguyenLieuId");

                    b.ToTable("NguyenLieu");
                });

            modelBuilder.Entity("EF_04.Entity.PhieuThu", b =>
                {
                    b.Property<int>("PhieuThuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhieuThuId"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("NhanVienLap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.HasKey("PhieuThuId");

                    b.ToTable("PhieuThu");
                });

            modelBuilder.Entity("EF_04.Entity.ChiTietPhieuThu", b =>
                {
                    b.HasOne("EF_04.Entity.NguyenLieu", "NguyenLieu")
                        .WithMany()
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_04.Entity.PhieuThu", "PhieuThu")
                        .WithMany()
                        .HasForeignKey("PhieuThuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguyenLieu");

                    b.Navigation("PhieuThu");
                });

            modelBuilder.Entity("EF_04.Entity.NguyenLieu", b =>
                {
                    b.HasOne("EF_04.Entity.LoaiNguyenLieu", "LoaiNguyenLieu")
                        .WithMany()
                        .HasForeignKey("LoaiNguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiNguyenLieu");
                });
#pragma warning restore 612, 618
        }
    }
}
