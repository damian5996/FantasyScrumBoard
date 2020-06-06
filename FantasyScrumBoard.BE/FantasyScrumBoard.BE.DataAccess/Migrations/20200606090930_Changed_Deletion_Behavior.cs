using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyScrumBoard.BE.DataAccess.Migrations
{
    public partial class Changed_Deletion_Behavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_User_MvpId",
                table: "Sprint");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_Project_ProjectId",
                table: "Sprint");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_User_MvpId",
                table: "Sprint",
                column: "MvpId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_Project_ProjectId",
                table: "Sprint",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_User_MvpId",
                table: "Sprint");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_Project_ProjectId",
                table: "Sprint");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_User_MvpId",
                table: "Sprint",
                column: "MvpId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_Project_ProjectId",
                table: "Sprint",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
