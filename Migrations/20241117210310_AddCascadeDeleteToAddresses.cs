using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_creator.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteToAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_BasicInformations_BasicInformationId",
                table: "Addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_BasicInformations_BasicInformationId",
                table: "Addresses",
                column: "BasicInformationId",
                principalTable: "BasicInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_BasicInformations_BasicInformationId",
                table: "Addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_BasicInformations_BasicInformationId",
                table: "Addresses",
                column: "BasicInformationId",
                principalTable: "BasicInformations",
                principalColumn: "Id");
        }
    }
}
