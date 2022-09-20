﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NB_API.Models;

#nullable disable

namespace NB_API.Migrations
{
    [DbContext(typeof(NBDBContext))]
    partial class NBDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrugerBryggeri", b =>
                {
                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.Property<int>("FollowsId")
                        .HasColumnType("int");

                    b.HasKey("FollowersId", "FollowsId");

                    b.HasIndex("FollowsId");

                    b.ToTable("BrugerBryggeri");
                });

            modelBuilder.Entity("NB_API.Models.Bruger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AcceptedPolicy")
                        .HasColumnType("bit");

                    b.Property<string>("Brugernavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("KontaktoplysningerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("PwHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PwSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RolleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KontaktoplysningerId");

                    b.HasIndex("RolleId");

                    b.ToTable("Bruger");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcceptedPolicy = false,
                            Brugernavn = "CfDJ8DXPo3W4uhxPoIhCOGVRAQnqOee0YJ7jaopFF1NXlcEI3l6nt6HBLsefj43eOQ9R7fQf3mQT3_iyVFrb3AT28DElMHVUo59AuZAE6wP4VR5SrpP69tEmQH_aFSje92_1dw",
                            Deleted = false,
                            PwHash = new byte[] { 195, 142, 97, 125, 110, 10, 187, 89, 164, 61, 251, 126, 166, 191, 130, 211, 95, 185, 198, 195, 140, 229, 32, 245, 48, 147, 111, 52, 42, 230, 249, 233, 26, 143, 1, 245, 220, 77, 137, 80, 230, 100, 241, 176, 124, 249, 196, 17, 208, 126, 78, 162, 234, 108, 156, 116, 54, 203, 184, 31, 224, 207, 116, 179 },
                            PwSalt = new byte[] { 198, 29, 208, 96, 249, 131, 147, 101, 28, 151, 102, 210, 236, 152, 57, 164, 205, 4, 213, 4, 165, 175, 246, 48, 141, 106, 255, 195, 211, 231, 34, 117, 57, 240, 131, 26, 238, 185, 87, 214, 6, 44, 154, 182, 78, 226, 34, 105, 203, 234, 24, 37, 233, 252, 89, 141, 63, 253, 166, 215, 223, 193, 48, 129, 235, 187, 129, 208, 18, 224, 64, 165, 42, 164, 29, 158, 155, 44, 189, 163, 249, 200, 226, 20, 239, 164, 112, 229, 77, 209, 211, 128, 205, 161, 61, 209, 172, 210, 118, 29, 165, 84, 105, 98, 3, 169, 67, 48, 229, 19, 112, 148, 34, 210, 170, 148, 214, 180, 10, 73, 7, 249, 91, 220, 55, 97, 253, 175 },
                            RolleId = 3
                        });
                });

            modelBuilder.Entity("NB_API.Models.Bryggeri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BryggeriLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("KontaktoplysningerId")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KontaktoplysningerId")
                        .IsUnique()
                        .HasFilter("[KontaktoplysningerId] IS NOT NULL");

                    b.ToTable("Bryggeri");
                });

            modelBuilder.Entity("NB_API.Models.Certifikat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<int?>("CStatus")
                        .HasColumnType("int");

                    b.Property<string>("CertifikatBilled")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.ToTable("Certifikat");
                });

            modelBuilder.Entity("NB_API.Models.Deltager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.HasIndex("EventId");

                    b.ToTable("Deltager");
                });

            modelBuilder.Entity("NB_API.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventBilled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SlutDato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDato")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("NB_API.Models.EventTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TagId");

                    b.ToTable("EventTags");
                });

            modelBuilder.Entity("NB_API.Models.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<string>("ForumBillede")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Oprettet")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.HasIndex("TagId");

                    b.ToTable("Forum");
                });

            modelBuilder.Entity("NB_API.Models.ForumTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ForumId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.HasIndex("TagId");

                    b.ToTable("ForumTags");
                });

            modelBuilder.Entity("NB_API.Models.Kommentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ForfatterId")
                        .HasColumnType("int");

                    b.Property<int>("OlId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ForfatterId");

                    b.HasIndex("OlId");

                    b.ToTable("Kommentar");
                });

            modelBuilder.Entity("NB_API.Models.Kontaktoplysninger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Addresselinje1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Addresselinje2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fnavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Offentlig")
                        .HasColumnType("bit");

                    b.Property<int>("Postnr")
                        .HasColumnType("int");

                    b.Property<string>("TelefonNr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kontaktoplysninger");
                });

            modelBuilder.Entity("NB_API.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoginTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("getutcdate()");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("NB_API.Models.Øl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Aargang")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Antal")
                        .HasColumnType("int");

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BryggeriId")
                        .HasColumnType("int");

                    b.Property<int?>("FlaskeAntal")
                        .HasColumnType("int");

                    b.Property<int?>("FlaskeResAntal")
                        .HasColumnType("int");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OlBillede")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Procent")
                        .HasColumnType("real");

                    b.Property<string>("Smag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<int?>("TondeAntal")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BryggeriId");

                    b.HasIndex("TagId");

                    b.ToTable("Øl");
                });

            modelBuilder.Entity("NB_API.Models.ØlTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("ØlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("ØlId");

                    b.ToTable("ØlTags");
                });

            modelBuilder.Entity("NB_API.Models.Opskrift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Offentliggjort")
                        .HasColumnType("bit");

                    b.Property<int>("OlId")
                        .HasColumnType("int");

                    b.Property<string>("StepFive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepFour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepOne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepThree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StepTwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OlId")
                        .IsUnique();

                    b.ToTable("Opskrift");
                });

            modelBuilder.Entity("NB_API.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<int>("ForumId")
                        .HasColumnType("int");

                    b.Property<string>("Indhold")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Oprettet")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("SvarerId")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.HasIndex("ForumId");

                    b.HasIndex("SvarerId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("NB_API.Models.Rapport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnklagetBrugerId")
                        .HasColumnType("int");

                    b.Property<string>("Besked")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<bool?>("Godtaget")
                        .HasColumnType("bit");

                    b.Property<int?>("RType")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.ToTable("Rapport");
                });

            modelBuilder.Entity("NB_API.Models.Rolle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("RolleNavn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rolle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Level = 0,
                            RolleNavn = 0
                        },
                        new
                        {
                            Id = 2,
                            Level = 10,
                            RolleNavn = 10
                        },
                        new
                        {
                            Id = 3,
                            Level = 20,
                            RolleNavn = 20
                        });
                });

            modelBuilder.Entity("NB_API.Models.Samarbejde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BryggeriId")
                        .HasColumnType("int");

                    b.Property<int>("BryggeriId1")
                        .HasColumnType("int");

                    b.Property<int>("BryggeriId2")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ØlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BryggeriId");

                    b.HasIndex("ØlId");

                    b.ToTable("Samarbejde");
                });

            modelBuilder.Entity("NB_API.Models.SamarbejdeAnmodning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BryggeriId")
                        .HasColumnType("int");

                    b.Property<int>("BryggeriId1")
                        .HasColumnType("int");

                    b.Property<int>("BryggeriId2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BryggeriId");

                    b.ToTable("SamarbejdeAnmodning");
                });

            modelBuilder.Entity("NB_API.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BryggeriId")
                        .HasColumnType("int");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BryggeriId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BrugerBryggeri", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Bryggeri", null)
                        .WithMany()
                        .HasForeignKey("FollowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NB_API.Models.Bruger", b =>
                {
                    b.HasOne("NB_API.Models.Kontaktoplysninger", "Kontaktoplysninger")
                        .WithMany()
                        .HasForeignKey("KontaktoplysningerId");

                    b.HasOne("NB_API.Models.Rolle", "Rolle")
                        .WithMany()
                        .HasForeignKey("RolleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kontaktoplysninger");

                    b.Navigation("Rolle");
                });

            modelBuilder.Entity("NB_API.Models.Bryggeri", b =>
                {
                    b.HasOne("NB_API.Models.Kontaktoplysninger", "Kontaktoplysninger")
                        .WithOne("Bryggeri")
                        .HasForeignKey("NB_API.Models.Bryggeri", "KontaktoplysningerId");

                    b.Navigation("Kontaktoplysninger");
                });

            modelBuilder.Entity("NB_API.Models.Certifikat", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", null)
                        .WithMany("Certifikats")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NB_API.Models.Deltager", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", "Bruger")
                        .WithMany("Deltager")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Event", "Event")
                        .WithMany("Deltagelse")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bruger");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("NB_API.Models.Event", b =>
                {
                    b.HasOne("NB_API.Models.Tag", null)
                        .WithMany("Events")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("NB_API.Models.EventTags", b =>
                {
                    b.HasOne("NB_API.Models.Event", "Event")
                        .WithMany("Tags")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("NB_API.Models.Forum", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", "Bruger")
                        .WithMany()
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Tag", null)
                        .WithMany("Fora")
                        .HasForeignKey("TagId");

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("NB_API.Models.ForumTags", b =>
                {
                    b.HasOne("NB_API.Models.Forum", "Forum")
                        .WithMany("Tags")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forum");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("NB_API.Models.Kommentar", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", "Forfatter")
                        .WithMany()
                        .HasForeignKey("ForfatterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Øl", "Ol")
                        .WithMany("Kommentarer")
                        .HasForeignKey("OlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forfatter");

                    b.Navigation("Ol");
                });

            modelBuilder.Entity("NB_API.Models.Login", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", "Bruger")
                        .WithMany()
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("NB_API.Models.Øl", b =>
                {
                    b.HasOne("NB_API.Models.Bryggeri", "Bryggeri")
                        .WithMany("Øl")
                        .HasForeignKey("BryggeriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Tag", null)
                        .WithMany("Øl")
                        .HasForeignKey("TagId");

                    b.Navigation("Bryggeri");
                });

            modelBuilder.Entity("NB_API.Models.ØlTags", b =>
                {
                    b.HasOne("NB_API.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Øl", "Øl")
                        .WithMany("Tags")
                        .HasForeignKey("ØlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Øl");
                });

            modelBuilder.Entity("NB_API.Models.Opskrift", b =>
                {
                    b.HasOne("NB_API.Models.Øl", "Ol")
                        .WithOne("Bryggeprocess")
                        .HasForeignKey("NB_API.Models.Opskrift", "OlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ol");
                });

            modelBuilder.Entity("NB_API.Models.Post", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", "Bruger")
                        .WithMany()
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Forum", "Forum")
                        .WithMany("Posts")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Post", "Svarer")
                        .WithMany()
                        .HasForeignKey("SvarerId");

                    b.Navigation("Bruger");

                    b.Navigation("Forum");

                    b.Navigation("Svarer");
                });

            modelBuilder.Entity("NB_API.Models.Rapport", b =>
                {
                    b.HasOne("NB_API.Models.Bruger", "Bruger")
                        .WithMany("Rapporter")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("NB_API.Models.Samarbejde", b =>
                {
                    b.HasOne("NB_API.Models.Bryggeri", "Bryggeri")
                        .WithMany("Samarbejde")
                        .HasForeignKey("BryggeriId");

                    b.HasOne("NB_API.Models.Øl", null)
                        .WithMany("Samarbejder")
                        .HasForeignKey("ØlId");

                    b.Navigation("Bryggeri");
                });

            modelBuilder.Entity("NB_API.Models.SamarbejdeAnmodning", b =>
                {
                    b.HasOne("NB_API.Models.Bryggeri", "Bryggeri")
                        .WithMany()
                        .HasForeignKey("BryggeriId");

                    b.Navigation("Bryggeri");
                });

            modelBuilder.Entity("NB_API.Models.Tag", b =>
                {
                    b.HasOne("NB_API.Models.Bryggeri", null)
                        .WithMany("Tags")
                        .HasForeignKey("BryggeriId");
                });

            modelBuilder.Entity("NB_API.Models.Bruger", b =>
                {
                    b.Navigation("Certifikats");

                    b.Navigation("Deltager");

                    b.Navigation("Rapporter");
                });

            modelBuilder.Entity("NB_API.Models.Bryggeri", b =>
                {
                    b.Navigation("Samarbejde");

                    b.Navigation("Tags");

                    b.Navigation("Øl");
                });

            modelBuilder.Entity("NB_API.Models.Event", b =>
                {
                    b.Navigation("Deltagelse");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("NB_API.Models.Forum", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("NB_API.Models.Kontaktoplysninger", b =>
                {
                    b.Navigation("Bryggeri");
                });

            modelBuilder.Entity("NB_API.Models.Øl", b =>
                {
                    b.Navigation("Bryggeprocess");

                    b.Navigation("Kommentarer");

                    b.Navigation("Samarbejder");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("NB_API.Models.Tag", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Fora");

                    b.Navigation("Øl");
                });
#pragma warning restore 612, 618
        }
    }
}
