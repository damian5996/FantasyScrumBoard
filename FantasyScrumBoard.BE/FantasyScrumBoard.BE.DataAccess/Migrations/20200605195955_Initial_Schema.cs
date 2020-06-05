using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FantasyScrumBoard.BE.DataAccess.Migrations
{
    public partial class Initial_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Nick = table.Column<string>(maxLength: 64, nullable: true),
                    Exp = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Content = table.Column<string>(maxLength: 256, nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RedirectUrl = table.Column<string>(maxLength: 256, nullable: true),
                    ReceiverId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: true),
                    ClosedAt = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ProjectId = table.Column<long>(nullable: false),
                    MvpId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprint_User_MvpId",
                        column: x => x.MvpId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sprint_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievement",
                columns: table => new
                {
                    AchievementId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    EarnedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievement", x => x.AchievementId);
                    table.ForeignKey(
                        name: "FK_UserAchievement_Achievement_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAchievement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    ProjectId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    IsOwner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_UserProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    StoryPoints = table.Column<int>(nullable: false),
                    VersionGuid = table.Column<Guid>(maxLength: 64, nullable: false),
                    SprintId = table.Column<long>(nullable: false),
                    ProjectId = table.Column<long>(nullable: false),
                    AssignedUserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_User_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_Sprint_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EditedAt = table.Column<DateTime>(nullable: true),
                    AuthorId = table.Column<long>(nullable: false),
                    WorkItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_WorkItem_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_WorkItemId",
                table: "Comment",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReceiverId",
                table: "Notification",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_MvpId",
                table: "Sprint",
                column: "MvpId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_ProjectId",
                table: "Sprint",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievement_UserId",
                table: "UserAchievement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_AssignedUserId",
                table: "WorkItem",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_ProjectId",
                table: "WorkItem",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_SprintId",
                table: "WorkItem",
                column: "SprintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "UserAchievement");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
