using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NB_API.Migrations
{
    public partial class MoreToCome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontaktoplysninger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fnavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addresselinje1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addresselinje2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnr = table.Column<int>(type: "int", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offentlig = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontaktoplysninger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rolle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolleNavn = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bruger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brugernavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PwHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PwSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RolleId = table.Column<int>(type: "int", nullable: false),
                    KontaktoplysningerId = table.Column<int>(type: "int", nullable: true),
                    AcceptedPolicy = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bruger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bruger_Kontaktoplysninger_KontaktoplysningerId",
                        column: x => x.KontaktoplysningerId,
                        principalTable: "Kontaktoplysninger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bruger_Rolle_RolleId",
                        column: x => x.RolleId,
                        principalTable: "Rolle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bryggeri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktoplysningerId = table.Column<int>(type: "int", nullable: true),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BryggeriLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BrugerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bryggeri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bryggeri_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bryggeri_Kontaktoplysninger_KontaktoplysningerId",
                        column: x => x.KontaktoplysningerId,
                        principalTable: "Kontaktoplysninger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Certifikat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CStatus = table.Column<int>(type: "int", nullable: true),
                    CertifikatBilled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrugerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifikat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifikat_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rapport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    AnklagetBrugerId = table.Column<int>(type: "int", nullable: true),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Besked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RType = table.Column<int>(type: "int", nullable: true),
                    Godtaget = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rapport_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BryggeriFollowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    BryggeriId = table.Column<int>(type: "int", nullable: false),
                    FolloerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BryggeriFollowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BryggeriFollowers_Bruger_FolloerId",
                        column: x => x.FolloerId,
                        principalTable: "Bruger",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BryggeriFollowers_Bryggeri_BryggeriId",
                        column: x => x.BryggeriId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SamarbejdeAnmodning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BryggeriId1 = table.Column<int>(type: "int", nullable: false),
                    BryggeriId2 = table.Column<int>(type: "int", nullable: false),
                    BryggeriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamarbejdeAnmodning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SamarbejdeAnmodning_Bryggeri_BryggeriId",
                        column: x => x.BryggeriId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BryggeriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Bryggeri_BryggeriId",
                        column: x => x.BryggeriId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lokation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventBilled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oprettet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForumBillede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forum_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Forum_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Øl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BryggeriId = table.Column<int>(type: "int", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Procent = table.Column<float>(type: "real", nullable: false),
                    Smag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlBillede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aargang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: true),
                    FlaskeAntal = table.Column<int>(type: "int", nullable: true),
                    TondeAntal = table.Column<int>(type: "int", nullable: true),
                    FlaskeResAntal = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Øl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Øl_Bryggeri_BryggeriId",
                        column: x => x.BryggeriId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Øl_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deltager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deltager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deltager_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Deltager_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EventTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTags_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ForumTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForumId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumTags_Forum_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ForumTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indhold = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oprettet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    SvarerId = table.Column<int>(type: "int", nullable: true),
                    ForumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Post_Forum_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Post_Post_SvarerId",
                        column: x => x.SvarerId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kommentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ForfatterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kommentar_Bruger_ForfatterId",
                        column: x => x.ForfatterId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kommentar_Øl_OlId",
                        column: x => x.OlId,
                        principalTable: "Øl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ØlTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ØlId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ØlTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ØlTags_Øl_ØlId",
                        column: x => x.ØlId,
                        principalTable: "Øl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ØlTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Opskrift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OlId = table.Column<int>(type: "int", nullable: false),
                    StepOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepFour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepFive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Offentliggjort = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opskrift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opskrift_Øl_OlId",
                        column: x => x.OlId,
                        principalTable: "Øl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Samarbejde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BryggeriId1 = table.Column<int>(type: "int", nullable: false),
                    BryggeriId2 = table.Column<int>(type: "int", nullable: false),
                    BryggeriId = table.Column<int>(type: "int", nullable: true),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ØlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samarbejde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samarbejde_Bryggeri_BryggeriId",
                        column: x => x.BryggeriId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Samarbejde_Øl_ØlId",
                        column: x => x.ØlId,
                        principalTable: "Øl",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Rolle",
                columns: new[] { "Id", "Level", "RolleNavn" },
                values: new object[] { 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "Rolle",
                columns: new[] { "Id", "Level", "RolleNavn" },
                values: new object[] { 2, 10, 10 });

            migrationBuilder.InsertData(
                table: "Rolle",
                columns: new[] { "Id", "Level", "RolleNavn" },
                values: new object[] { 3, 20, 20 });

            migrationBuilder.InsertData(
                table: "Bruger",
                columns: new[] { "Id", "AcceptedPolicy", "Brugernavn", "DeleteTime", "Deleted", "KontaktoplysningerId", "PwHash", "PwSalt", "RolleId" },
                values: new object[] { 1, false, "CfDJ8DXPo3W4uhxPoIhCOGVRAQl0mZGbGt2XE7bJLchEFM8KX7ydpjUXqBXGZVm6GTxKCFPR9z2Ugz6jhaZtlp8QPLNou5WEWaZse1xNcKjqdds4o0vQXucLQRNg3VjZ0VHOMA", null, false, null, new byte[] { 218, 15, 96, 47, 72, 244, 151, 153, 217, 42, 159, 246, 17, 158, 161, 188, 29, 224, 186, 116, 117, 251, 106, 113, 85, 77, 140, 2, 151, 181, 93, 197, 199, 85, 1, 121, 55, 202, 180, 25, 225, 206, 165, 117, 122, 172, 169, 64, 110, 163, 196, 71, 114, 160, 115, 118, 141, 178, 69, 218, 21, 56, 224, 46 }, new byte[] { 15, 93, 87, 188, 142, 23, 183, 247, 37, 172, 133, 86, 187, 230, 156, 226, 250, 94, 98, 194, 186, 53, 191, 125, 92, 158, 162, 89, 187, 19, 182, 32, 22, 229, 135, 142, 191, 209, 13, 103, 90, 150, 112, 173, 0, 28, 170, 10, 3, 57, 82, 101, 114, 57, 210, 204, 115, 89, 86, 2, 167, 245, 232, 212, 107, 244, 58, 96, 233, 49, 250, 127, 22, 218, 181, 218, 225, 56, 67, 235, 127, 127, 255, 254, 73, 178, 247, 111, 16, 24, 54, 240, 240, 128, 209, 24, 251, 37, 139, 210, 92, 153, 175, 205, 254, 117, 239, 89, 119, 111, 35, 48, 47, 110, 158, 90, 206, 113, 40, 23, 56, 211, 236, 12, 220, 1, 35, 10 }, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_KontaktoplysningerId",
                table: "Bruger",
                column: "KontaktoplysningerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_RolleId",
                table: "Bruger",
                column: "RolleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bryggeri_BrugerId",
                table: "Bryggeri",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bryggeri_KontaktoplysningerId",
                table: "Bryggeri",
                column: "KontaktoplysningerId",
                unique: true,
                filter: "[KontaktoplysningerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BryggeriFollowers_BryggeriId",
                table: "BryggeriFollowers",
                column: "BryggeriId");

            migrationBuilder.CreateIndex(
                name: "IX_BryggeriFollowers_FolloerId",
                table: "BryggeriFollowers",
                column: "FolloerId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifikat_BrugerId",
                table: "Certifikat",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deltager_BrugerId",
                table: "Deltager",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Deltager_EventId",
                table: "Deltager",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TagId",
                table: "Event",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_EventId",
                table: "EventTags",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTags_TagId",
                table: "EventTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_BrugerId",
                table: "Forum",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_TagId",
                table: "Forum",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTags_ForumId",
                table: "ForumTags",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTags_TagId",
                table: "ForumTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_ForfatterId",
                table: "Kommentar",
                column: "ForfatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_OlId",
                table: "Kommentar",
                column: "OlId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_BrugerId",
                table: "Login",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Øl_BryggeriId",
                table: "Øl",
                column: "BryggeriId");

            migrationBuilder.CreateIndex(
                name: "IX_Øl_TagId",
                table: "Øl",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ØlTags_ØlId",
                table: "ØlTags",
                column: "ØlId");

            migrationBuilder.CreateIndex(
                name: "IX_ØlTags_TagId",
                table: "ØlTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Opskrift_OlId",
                table: "Opskrift",
                column: "OlId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_BrugerId",
                table: "Post",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ForumId",
                table: "Post",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SvarerId",
                table: "Post",
                column: "SvarerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rapport_BrugerId",
                table: "Rapport",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Samarbejde_BryggeriId",
                table: "Samarbejde",
                column: "BryggeriId");

            migrationBuilder.CreateIndex(
                name: "IX_Samarbejde_ØlId",
                table: "Samarbejde",
                column: "ØlId");

            migrationBuilder.CreateIndex(
                name: "IX_SamarbejdeAnmodning_BryggeriId",
                table: "SamarbejdeAnmodning",
                column: "BryggeriId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BryggeriId",
                table: "Tag",
                column: "BryggeriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BryggeriFollowers");

            migrationBuilder.DropTable(
                name: "Certifikat");

            migrationBuilder.DropTable(
                name: "Deltager");

            migrationBuilder.DropTable(
                name: "EventTags");

            migrationBuilder.DropTable(
                name: "ForumTags");

            migrationBuilder.DropTable(
                name: "Kommentar");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "ØlTags");

            migrationBuilder.DropTable(
                name: "Opskrift");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Rapport");

            migrationBuilder.DropTable(
                name: "Samarbejde");

            migrationBuilder.DropTable(
                name: "SamarbejdeAnmodning");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "Øl");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Bryggeri");

            migrationBuilder.DropTable(
                name: "Bruger");

            migrationBuilder.DropTable(
                name: "Kontaktoplysninger");

            migrationBuilder.DropTable(
                name: "Rolle");
        }
    }
}
