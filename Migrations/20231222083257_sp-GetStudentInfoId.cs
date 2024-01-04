using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database_School_Project_.NET23_SQL.Migrations
{
    /// <inheritdoc />
    public partial class spGetStudentInfoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetStudents]
                    @StudentNumber int = null
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select StudentFirstName, StudentLastName, StudentBirthDate from Students where StudentNumber = @StudentNumber
                END";

            migrationBuilder.Sql(sp);
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
