﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using locaweb_rest_api.Data.Contexts;

#nullable disable

namespace locaweb_rest_api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240828191206_removeRecipientAttrFromReceivedEmail")]
    partial class removeRecipientAttrFromReceivedEmail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("locaweb_rest_api.Models.DeletedReceivedEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdReceivedEmail")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdReceivedEmail");

                    b.HasIndex("IdUser");

                    b.ToTable("DeletedReceivedEmail", (string)null);
                });

            modelBuilder.Entity("locaweb_rest_api.Models.FavoriteReceivedEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdReceivedEmail")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdReceivedEmail");

                    b.HasIndex("IdUser");

                    b.ToTable("FavoriteReceivedEmail", (string)null);
                });

            modelBuilder.Entity("locaweb_rest_api.Models.ReceivedEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("ReceivedEmail", (string)null);
                });

            modelBuilder.Entity("locaweb_rest_api.Models.SentEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<bool>("Canceled")
                        .HasColumnType("number(1)");

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR2(150)");

                    b.Property<bool>("Scheduled")
                        .HasColumnType("number(1)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("date");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("date");

                    b.Property<bool>("Viewed")
                        .HasColumnType("number(1)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("SentEmail", (string)null);
                });

            modelBuilder.Entity("locaweb_rest_api.Models.TrashedEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdReceivedEmail")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("IdSentEmail")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdUser")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdReceivedEmail");

                    b.HasIndex("IdSentEmail");

                    b.HasIndex("IdUser");

                    b.ToTable("TrashedEmail", (string)null);
                });

            modelBuilder.Entity("locaweb_rest_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR2(2)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<bool>("Theme")
                        .HasColumnType("number(1)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("locaweb_rest_api.Models.DeletedReceivedEmail", b =>
                {
                    b.HasOne("locaweb_rest_api.Models.ReceivedEmail", "ReceivedEmail")
                        .WithMany()
                        .HasForeignKey("IdReceivedEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("locaweb_rest_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceivedEmail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("locaweb_rest_api.Models.FavoriteReceivedEmail", b =>
                {
                    b.HasOne("locaweb_rest_api.Models.ReceivedEmail", "ReceivedEmail")
                        .WithMany()
                        .HasForeignKey("IdReceivedEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("locaweb_rest_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceivedEmail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("locaweb_rest_api.Models.SentEmail", b =>
                {
                    b.HasOne("locaweb_rest_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("locaweb_rest_api.Models.TrashedEmail", b =>
                {
                    b.HasOne("locaweb_rest_api.Models.ReceivedEmail", "ReceivedEmail")
                        .WithMany()
                        .HasForeignKey("IdReceivedEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("locaweb_rest_api.Models.SentEmail", "SentEmail")
                        .WithMany()
                        .HasForeignKey("IdSentEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("locaweb_rest_api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReceivedEmail");

                    b.Navigation("SentEmail");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
