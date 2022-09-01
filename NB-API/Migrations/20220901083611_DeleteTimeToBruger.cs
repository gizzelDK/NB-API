using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NB_API.Migrations
{
    public partial class DeleteTimeToBruger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    EventBilled = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

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
                    Telefonnr = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Bryggeri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktoplysningerId = table.Column<int>(type: "int", nullable: true),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BryggeriLogo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bryggeri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bryggeri_Kontaktoplysninger_KontaktoplysningerId",
                        column: x => x.KontaktoplysningerId,
                        principalTable: "Kontaktoplysninger",
                        principalColumn: "Id");
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
                    Certifikat = table.Column<byte>(type: "tinyint", nullable: true),
                    AcceptedPolicy = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bruger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bruger_Kontaktoplysninger_KontaktoplysningerId",
                        column: x => x.KontaktoplysningerId,
                        principalTable: "Kontaktoplysninger",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bruger_Rolle_RolleId",
                        column: x => x.RolleId,
                        principalTable: "Rolle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SamarbejdeAnmodning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BryggerId1 = table.Column<int>(type: "int", nullable: false),
                    BryggerId2 = table.Column<int>(type: "int", nullable: false),
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
                    Årgang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: true),
                    FlaskeAntal = table.Column<int>(type: "int", nullable: true),
                    TondeAntal = table.Column<int>(type: "int", nullable: true),
                    FlaskeResAntal = table.Column<int>(type: "int", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Archive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    KontaktoplysningerId = table.Column<int>(type: "int", nullable: false),
                    Oprettet = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Archive_Kontaktoplysninger_KontaktoplysningerId",
                        column: x => x.KontaktoplysningerId,
                        principalTable: "Kontaktoplysninger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BrugerBryggeri",
                columns: table => new
                {
                    FollowersId = table.Column<int>(type: "int", nullable: false),
                    FollowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrugerBryggeri", x => new { x.FollowersId, x.FollowsId });
                    table.ForeignKey(
                        name: "FK_BrugerBryggeri_Bruger_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BrugerBryggeri_Bryggeri_FollowsId",
                        column: x => x.FollowsId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BrugerEvent",
                columns: table => new
                {
                    DeltagereId = table.Column<int>(type: "int", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrugerEvent", x => new { x.DeltagereId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_BrugerEvent_Bruger_DeltagereId",
                        column: x => x.DeltagereId,
                        principalTable: "Bruger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BrugerEvent_Event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oprettet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForumBilled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrugerId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false, computedColumnSql: "getutcdate()")
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
                name: "EventTag",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTag", x => new { x.EventsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EventTag_Event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EventTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kommentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ØlId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kommentar_Øl_ØlId",
                        column: x => x.ØlId,
                        principalTable: "Øl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Opskrift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ØlId = table.Column<int>(type: "int", nullable: false),
                    StepOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepFour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepFive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opskrift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opskrift_Øl_ØlId",
                        column: x => x.ØlId,
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
                    ØlId = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samarbejde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samarbejde_Øl_ØlId",
                        column: x => x.ØlId,
                        principalTable: "Øl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TagØl",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    ØlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagØl", x => new { x.TagsId, x.ØlId });
                    table.ForeignKey(
                        name: "FK_TagØl_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TagØl_Øl_ØlId",
                        column: x => x.ØlId,
                        principalTable: "Øl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ForumTag",
                columns: table => new
                {
                    ForumId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTag", x => new { x.ForumId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ForumTag_Forum_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ForumTag_Tag_TagsId",
                        column: x => x.TagsId,
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
                    Oprettet = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
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
                name: "BryggeriSamarbejde",
                columns: table => new
                {
                    BryggerierId = table.Column<int>(type: "int", nullable: false),
                    SamarbejdeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BryggeriSamarbejde", x => new { x.BryggerierId, x.SamarbejdeId });
                    table.ForeignKey(
                        name: "FK_BryggeriSamarbejde_Bryggeri_BryggerierId",
                        column: x => x.BryggerierId,
                        principalTable: "Bryggeri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BryggeriSamarbejde_Samarbejde_SamarbejdeId",
                        column: x => x.SamarbejdeId,
                        principalTable: "Samarbejde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateIndex(
                name: "IX_Archive_BrugerId",
                table: "Archive",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_KontaktoplysningerId",
                table: "Archive",
                column: "KontaktoplysningerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_KontaktoplysningerId",
                table: "Bruger",
                column: "KontaktoplysningerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_RolleId",
                table: "Bruger",
                column: "RolleId");

            migrationBuilder.CreateIndex(
                name: "IX_BrugerBryggeri_FollowsId",
                table: "BrugerBryggeri",
                column: "FollowsId");

            migrationBuilder.CreateIndex(
                name: "IX_BrugerEvent_EventsId",
                table: "BrugerEvent",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bryggeri_KontaktoplysningerId",
                table: "Bryggeri",
                column: "KontaktoplysningerId",
                unique: true,
                filter: "[KontaktoplysningerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BryggeriSamarbejde_SamarbejdeId",
                table: "BryggeriSamarbejde",
                column: "SamarbejdeId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifikat_BrugerId",
                table: "Certifikat",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTag_TagsId",
                table: "EventTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_BrugerId",
                table: "Forum",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTag_TagsId",
                table: "ForumTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_ØlId",
                table: "Kommentar",
                column: "ØlId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_BrugerId",
                table: "Login",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opskrift_ØlId",
                table: "Opskrift",
                column: "ØlId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TagØl_ØlId",
                table: "TagØl",
                column: "ØlId");

            migrationBuilder.CreateIndex(
                name: "IX_Øl_BryggeriId",
                table: "Øl",
                column: "BryggeriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archive");

            migrationBuilder.DropTable(
                name: "BrugerBryggeri");

            migrationBuilder.DropTable(
                name: "BrugerEvent");

            migrationBuilder.DropTable(
                name: "BryggeriSamarbejde");

            migrationBuilder.DropTable(
                name: "Certifikat");

            migrationBuilder.DropTable(
                name: "EventTag");

            migrationBuilder.DropTable(
                name: "ForumTag");

            migrationBuilder.DropTable(
                name: "Kommentar");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Opskrift");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Rapport");

            migrationBuilder.DropTable(
                name: "SamarbejdeAnmodning");

            migrationBuilder.DropTable(
                name: "TagØl");

            migrationBuilder.DropTable(
                name: "Samarbejde");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Øl");

            migrationBuilder.DropTable(
                name: "Bruger");

            migrationBuilder.DropTable(
                name: "Bryggeri");

            migrationBuilder.DropTable(
                name: "Rolle");

            migrationBuilder.DropTable(
                name: "Kontaktoplysninger");
        }
    }
}
