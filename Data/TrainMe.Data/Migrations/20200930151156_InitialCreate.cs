using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainMe.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ProgramId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    SeriesDefault = table.Column<int>(nullable: false),
                    RepetitionsDefault = table.Column<int>(nullable: false),
                    TempoDefault = table.Column<string>(maxLength: 20, nullable: true),
                    BreakDefault = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ProgramId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramInstances_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramInstances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseResources",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseResources", x => new { x.ExerciseId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ExerciseResources_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExercisesInPrograms",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false),
                    ProgramId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesInPrograms", x => new { x.ExerciseId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_ExercisesInPrograms_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExercisesInPrograms_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false),
                    ProgramInstanceId = table.Column<int>(nullable: false),
                    Series = table.Column<int>(nullable: false),
                    Repetitions = table.Column<int>(nullable: false),
                    Tempo = table.Column<string>(maxLength: 20, nullable: true),
                    Break = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseInstances_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseInstances_ProgramInstances_ProgramInstanceId",
                        column: x => x.ProgramInstanceId,
                        principalTable: "ProgramInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseInstancesInProgramInstances",
                columns: table => new
                {
                    ExerciseInstanceId = table.Column<int>(nullable: false),
                    ProgramInstanceId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseInstancesInProgramInstances", x => new { x.ExerciseInstanceId, x.ProgramInstanceId });
                    table.ForeignKey(
                        name: "FK_ExerciseInstancesInProgramInstances_ExerciseInstances_ExerciseInstanceId",
                        column: x => x.ExerciseInstanceId,
                        principalTable: "ExerciseInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseInstancesInProgramInstances_ProgramInstances_ProgramInstanceId",
                        column: x => x.ProgramInstanceId,
                        principalTable: "ProgramInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInstances_ExerciseId",
                table: "ExerciseInstances",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInstances_ProgramInstanceId",
                table: "ExerciseInstances",
                column: "ProgramInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInstancesInProgramInstances_ProgramInstanceId",
                table: "ExerciseInstancesInProgramInstances",
                column: "ProgramInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseResources_ResourceId",
                table: "ExerciseResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ProgramId",
                table: "Exercises",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisesInPrograms_ProgramId",
                table: "ExercisesInPrograms",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramInstances_ProgramId",
                table: "ProgramInstances",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramInstances_UserId",
                table: "ProgramInstances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CreatorId",
                table: "Programs",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseInstancesInProgramInstances");

            migrationBuilder.DropTable(
                name: "ExerciseResources");

            migrationBuilder.DropTable(
                name: "ExercisesInPrograms");

            migrationBuilder.DropTable(
                name: "ExerciseInstances");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ProgramInstances");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
