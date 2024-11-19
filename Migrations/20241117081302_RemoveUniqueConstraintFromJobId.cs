using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_creator.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueConstraintFromJobId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_JobId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_JobId",
                table: "Addresses",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_JobId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_JobId",
                table: "Addresses",
                column: "JobId",
                unique: true,
                filter: "[JobId] IS NOT NULL");
        }
    }
}
