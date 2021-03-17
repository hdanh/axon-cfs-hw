using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AxonCFS.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tstamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tstamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgencyUser",
                columns: table => new
                {
                    AgencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyUser", x => new { x.AgencyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AgencyUser_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tstamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responder_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DispatchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tstamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_EventType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EventType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Responder_ResponderId",
                        column: x => x.ResponderId,
                        principalTable: "Responder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agency",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("eff6a082-31e3-412b-b661-bd340eab29b6"), "Agency1" });

            migrationBuilder.InsertData(
                table: "Agency",
                columns: new[] { "Id", "Code" },
                values: new object[] { new Guid("4b63867c-e27c-41da-9c06-5e10817c1266"), "Agency2" });

            migrationBuilder.InsertData(
                table: "AgencyUser",
                columns: new[] { "AgencyId", "UserId" },
                values: new object[] { new Guid("eff6a082-31e3-412b-b661-bd340eab29b6"), "1" });

            migrationBuilder.InsertData(
                table: "AgencyUser",
                columns: new[] { "AgencyId", "UserId" },
                values: new object[] { new Guid("4b63867c-e27c-41da-9c06-5e10817c1266"), "2" });

            migrationBuilder.CreateIndex(
                name: "IX_Event_ResponderId",
                table: "Event",
                column: "ResponderId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_TypeId",
                table: "Event",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Responder_AgencyId",
                table: "Responder",
                column: "AgencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyUser");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Responder");

            migrationBuilder.DropTable(
                name: "Agency");
        }
    }
}
