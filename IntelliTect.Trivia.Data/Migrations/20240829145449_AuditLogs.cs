using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliTect.Trivia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuditLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    KeyValue = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referrer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogProperties_AuditLogs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogProperties_ParentId",
                table: "AuditLogProperties",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_State",
                table: "AuditLogs",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_Type",
                table: "AuditLogs",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_Type_KeyValue",
                table: "AuditLogs",
                columns: new[] { "Type", "KeyValue" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogProperties");

            migrationBuilder.DropTable(
                name: "AuditLogs");
        }
    }
}
