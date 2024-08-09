using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_message2_contextforegnkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message2s",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageSenderID = table.Column<int>(type: "int", nullable: true),
                    MessageReciverID = table.Column<int>(type: "int", nullable: true),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message2s", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_MessageReciverID",
                        column: x => x.MessageReciverID,
                        principalTable: "Writers",
                        principalColumn: "WriterID");
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_MessageSenderID",
                        column: x => x.MessageSenderID,
                        principalTable: "Writers",
                        principalColumn: "WriterID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_MessageReciverID",
                table: "Message2s",
                column: "MessageReciverID");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_MessageSenderID",
                table: "Message2s",
                column: "MessageSenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message2s");
        }
    }
}
