using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainMe.Data.Migrations
{
    public partial class InitialServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInstances_ProgramInstances_ProgramInstanceProgramId_ProgramInstanceUserId",
                table: "ExerciseInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramInstances",
                table: "ProgramInstances");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseInstances_ProgramInstanceProgramId_ProgramInstanceUserId",
                table: "ExerciseInstances");

            migrationBuilder.DropColumn(
                name: "ProgramInstanceProgramId",
                table: "ExerciseInstances");

            migrationBuilder.DropColumn(
                name: "ProgramInstanceUserId",
                table: "ExerciseInstances");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProgramInstances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProgramInstanceId",
                table: "ExerciseInstances",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramInstances",
                table: "ProgramInstances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramInstances_ProgramId_UserId",
                table: "ProgramInstances",
                columns: new[] { "ProgramId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInstances_ProgramInstanceId",
                table: "ExerciseInstances",
                column: "ProgramInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInstances_ProgramInstances_ProgramInstanceId",
                table: "ExerciseInstances",
                column: "ProgramInstanceId",
                principalTable: "ProgramInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseInstances_ProgramInstances_ProgramInstanceId",
                table: "ExerciseInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramInstances",
                table: "ProgramInstances");

            migrationBuilder.DropIndex(
                name: "IX_ProgramInstances_ProgramId_UserId",
                table: "ProgramInstances");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseInstances_ProgramInstanceId",
                table: "ExerciseInstances");

            migrationBuilder.DropColumn(
                name: "ProgramInstanceId",
                table: "ExerciseInstances");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProgramInstances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProgramInstanceProgramId",
                table: "ExerciseInstances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgramInstanceUserId",
                table: "ExerciseInstances",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramInstances",
                table: "ProgramInstances",
                columns: new[] { "ProgramId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInstances_ProgramInstanceProgramId_ProgramInstanceUserId",
                table: "ExerciseInstances",
                columns: new[] { "ProgramInstanceProgramId", "ProgramInstanceUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseInstances_ProgramInstances_ProgramInstanceProgramId_ProgramInstanceUserId",
                table: "ExerciseInstances",
                columns: new[] { "ProgramInstanceProgramId", "ProgramInstanceUserId" },
                principalTable: "ProgramInstances",
                principalColumns: new[] { "ProgramId", "UserId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
