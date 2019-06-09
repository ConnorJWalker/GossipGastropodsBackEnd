using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GossipGastropodsBackEnd.Migrations
{
    public partial class AddLikesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserGuid",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "PostBase");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserGuid",
                table: "PostBase",
                newName: "IX_PostBase_UserGuid1");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostBase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostType",
                table: "PostBase",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostBase",
                table: "PostBase",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false),
                    PostType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_PostBase_PostId",
                        column: x => x.PostId,
                        principalTable: "PostBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostBase_PostId",
                table: "PostBase",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostBase_UserGuid",
                table: "PostBase",
                column: "UserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserGuid",
                table: "Likes",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PostBase_PostBase_PostId",
                table: "PostBase",
                column: "PostId",
                principalTable: "PostBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PostBase_Users_UserGuid",
                table: "PostBase",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "GUID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PostBase_Users_UserGuid1",
                table: "PostBase",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "GUID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostBase_PostBase_PostId",
                table: "PostBase");

            migrationBuilder.DropForeignKey(
                name: "FK_PostBase_Users_UserGuid",
                table: "PostBase");

            migrationBuilder.DropForeignKey(
                name: "FK_PostBase_Users_UserGuid1",
                table: "PostBase");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostBase",
                table: "PostBase");

            migrationBuilder.DropIndex(
                name: "IX_PostBase_PostId",
                table: "PostBase");

            migrationBuilder.DropIndex(
                name: "IX_PostBase_UserGuid",
                table: "PostBase");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostBase");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "PostBase");

            migrationBuilder.RenameTable(
                name: "PostBase",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_PostBase_UserGuid1",
                table: "Posts",
                newName: "IX_Posts_UserGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IsEdited = table.Column<bool>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserGuid",
                table: "Comments",
                column: "UserGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserGuid",
                table: "Posts",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "GUID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
