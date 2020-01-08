using Microsoft.EntityFrameworkCore.Migrations;

namespace Autofaciocweb.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegStudents_Courses_CourseId",
                table: "RegStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegStudents",
                table: "RegStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "RegStudents",
                newName: "RegStudent");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RegStudent",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_RegStudents_CourseId",
                table: "RegStudent",
                newName: "IX_RegStudent_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "RegStudent",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "RegStudent",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "RegStudent",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegStudent",
                table: "RegStudent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegStudent_Course_CourseId",
                table: "RegStudent",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegStudent_Course_CourseId",
                table: "RegStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegStudent",
                table: "RegStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "age",
                table: "RegStudent");

            migrationBuilder.RenameTable(
                name: "RegStudent",
                newName: "RegStudents");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "RegStudents",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_RegStudent_CourseId",
                table: "RegStudents",
                newName: "IX_RegStudents_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RegStudents",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "RegStudents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegStudents",
                table: "RegStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegStudents_Courses_CourseId",
                table: "RegStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
