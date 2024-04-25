﻿// <auto-generated />
using System;
using FileService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileService.Migrations
{
    [DbContext(typeof(FileDbContext))]
    [Migration("20240425074413_ChangedNavProps")]
    partial class ChangedNavProps
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DocumentService.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<byte[]>("FileContent")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Document");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FileService.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("CertificateData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CertificateOwner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("FileService.Punch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PunchNumber")
                        .HasColumnType("int");

                    b.Property<int>("SignedDocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Test")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SignedDocumentId");

                    b.ToTable("Punches");
                });

            modelBuilder.Entity("FileService.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChapterAffected")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PageAffected")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SignedDocumentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SignedDocumentId");

                    b.ToTable("Revisions");
                });

            modelBuilder.Entity("FileService.Stamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Signature")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("SignedDocumentId")
                        .HasColumnType("int");

                    b.Property<string>("SigneeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StampIdentity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SignedDocumentId");

                    b.ToTable("Stamps");
                });

            modelBuilder.Entity("DocumentService.Models.SignedDocument", b =>
                {
                    b.HasBaseType("DocumentService.Models.Document");

                    b.Property<string>("TestType")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("SignedDocument");
                });

            modelBuilder.Entity("FileService.Punch", b =>
                {
                    b.HasOne("DocumentService.Models.SignedDocument", "SignedDocument")
                        .WithMany("MyProperty")
                        .HasForeignKey("SignedDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SignedDocument");
                });

            modelBuilder.Entity("FileService.Revision", b =>
                {
                    b.HasOne("DocumentService.Models.SignedDocument", "SignedDocument")
                        .WithMany("Revisions")
                        .HasForeignKey("SignedDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SignedDocument");
                });

            modelBuilder.Entity("FileService.Stamp", b =>
                {
                    b.HasOne("DocumentService.Models.SignedDocument", "signedDocument")
                        .WithMany("Stamps")
                        .HasForeignKey("SignedDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("signedDocument");
                });

            modelBuilder.Entity("DocumentService.Models.SignedDocument", b =>
                {
                    b.Navigation("MyProperty");

                    b.Navigation("Revisions");

                    b.Navigation("Stamps");
                });
#pragma warning restore 612, 618
        }
    }
}
