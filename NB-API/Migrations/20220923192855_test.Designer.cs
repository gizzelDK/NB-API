// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NB_API.Models;

#nullable disable

namespace NB_API.Migrations
{
    [DbContext(typeof(NBDBContext))]
    [Migration("20220923192855_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Brugernavn = "CfDJ8CU3oWbkDJlJrPGNMbNfAoS20OEZt0fmiBGCOSdl4qO90pEUNz1skK7s7MCgXsGB3umnaFnZmMcN5bRAA6G-iPDZ0DsXyc505T2W3AffC_sAQmA9goniUVn_oVJKjVcOdA",
                            Deleted = false,
                            PwHash = new byte[] { 222, 28, 218, 208, 130, 224, 2, 72, 185, 49, 57, 12, 87, 228, 180, 47, 57, 240, 167, 254, 115, 108, 192, 225, 203, 175, 14, 183, 4, 11, 195, 95, 116, 170, 92, 31, 202, 248, 155, 98, 146, 54, 172, 146, 137, 60, 7, 71, 114, 209, 201, 136, 220, 250, 54, 89, 234, 223, 160, 228, 24, 232, 71, 195 },
                            PwSalt = new byte[] { 69, 81, 40, 101, 156, 79, 120, 87, 150, 170, 235, 31, 187, 215, 37, 118, 160, 212, 192, 99, 100, 111, 107, 30, 210, 44, 169, 105, 234, 145, 163, 8, 131, 139, 26, 43, 36, 40, 40, 2, 35, 150, 83, 188, 60, 102, 78, 14, 75, 125, 183, 45, 228, 2, 104, 191, 98, 157, 41, 57, 57, 97, 10, 78, 28, 30, 190, 49, 227, 128, 15, 12, 176, 63, 148, 253, 224, 185, 158, 138, 134, 62, 221, 117, 25, 8, 251, 231, 117, 12, 218, 127, 4, 181, 252, 215, 79, 227, 11, 185, 206, 113, 101, 15, 91, 91, 219, 192, 33, 136, 94, 48, 176, 146, 44, 238, 252, 26, 176, 162, 122, 115, 110, 64, 208, 70, 97, 251 },
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

                    b.Property<int?>("BrugerId")
                        .HasColumnType("int");

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

                    b.HasIndex("BrugerId");

                    b.HasIndex("KontaktoplysningerId")
                        .IsUnique()
                        .HasFilter("[KontaktoplysningerId] IS NOT NULL");

                    b.ToTable("Bryggeri");
                });

            modelBuilder.Entity("NB_API.Models.BryggeriFollowers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BryggeriId")
                        .HasColumnType("int");

                    b.Property<int?>("FolloerId")
                        .HasColumnType("int");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BryggeriId");

                    b.HasIndex("FolloerId");

                    b.ToTable("BryggeriFollowers");
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
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("NB_API.Models.Opskrift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BryggeriId")
                        .HasColumnType("int");

                    b.Property<bool>("Offentliggjort")
                        .HasColumnType("bit");

                    b.Property<int?>("OlId")
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

                    b.HasIndex("BryggeriId");

                    b.HasIndex("OlId")
                        .IsUnique()
                        .HasFilter("[OlId] IS NOT NULL");

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

                    b.Property<DateTime?>("Oprettet")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Navn = "Lager"
                        },
                        new
                        {
                            Id = 2,
                            Navn = "Bajer"
                        },
                        new
                        {
                            Id = 3,
                            Navn = "Luxus"
                        },
                        new
                        {
                            Id = 4,
                            Navn = "Hvede"
                        },
                        new
                        {
                            Id = 5,
                            Navn = "Kun for sjov"
                        },
                        new
                        {
                            Id = 6,
                            Navn = "Ølfest"
                        },
                        new
                        {
                            Id = 7,
                            Navn = "Pilsner"
                        });
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

                    b.Property<int?>("samarbejdeId")
                        .HasColumnType("int");

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
                    b.HasOne("NB_API.Models.Bruger", null)
                        .WithMany("Follows")
                        .HasForeignKey("BrugerId");

                    b.HasOne("NB_API.Models.Kontaktoplysninger", "Kontaktoplysninger")
                        .WithOne("Bryggeri")
                        .HasForeignKey("NB_API.Models.Bryggeri", "KontaktoplysningerId");

                    b.Navigation("Kontaktoplysninger");
                });

            modelBuilder.Entity("NB_API.Models.BryggeriFollowers", b =>
                {
                    b.HasOne("NB_API.Models.Bryggeri", "Bryggeri")
                        .WithMany("Followers")
                        .HasForeignKey("BryggeriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NB_API.Models.Bruger", "Folloer")
                        .WithMany()
                        .HasForeignKey("FolloerId");

                    b.Navigation("Bryggeri");

                    b.Navigation("Folloer");
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

            modelBuilder.Entity("NB_API.Models.Opskrift", b =>
                {
                    b.HasOne("NB_API.Models.Bryggeri", "Bryggeri")
                        .WithMany()
                        .HasForeignKey("BryggeriId");

                    b.HasOne("NB_API.Models.Øl", "Ol")
                        .WithOne("Bryggeprocess")
                        .HasForeignKey("NB_API.Models.Opskrift", "OlId");

                    b.Navigation("Bryggeri");

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

            modelBuilder.Entity("NB_API.Models.Bruger", b =>
                {
                    b.Navigation("Certifikats");

                    b.Navigation("Deltager");

                    b.Navigation("Follows");

                    b.Navigation("Rapporter");
                });

            modelBuilder.Entity("NB_API.Models.Bryggeri", b =>
                {
                    b.Navigation("Followers");

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

            modelBuilder.Entity("NB_API.Models.Tag", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Fora");

                    b.Navigation("Øl");
                });

            modelBuilder.Entity("NB_API.Models.Øl", b =>
                {
                    b.Navigation("Bryggeprocess");

                    b.Navigation("Kommentarer");

                    b.Navigation("Samarbejder");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
