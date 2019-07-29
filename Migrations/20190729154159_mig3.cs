using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadImage.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Stadiums_StadiumIdStadium",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "StadiumIdStadium",
                table: "Images",
                newName: "IdStadium");

            migrationBuilder.RenameIndex(
                name: "IX_Images_StadiumIdStadium",
                table: "Images",
                newName: "IX_Images_IdStadium");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Stadiums_IdStadium",
                table: "Images",
                column: "IdStadium",
                principalTable: "Stadiums",
                principalColumn: "IdStadium",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Stadiums_IdStadium",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "IdStadium",
                table: "Images",
                newName: "StadiumIdStadium");

            migrationBuilder.RenameIndex(
                name: "IX_Images_IdStadium",
                table: "Images",
                newName: "IX_Images_StadiumIdStadium");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Stadiums_StadiumIdStadium",
                table: "Images",
                column: "StadiumIdStadium",
                principalTable: "Stadiums",
                principalColumn: "IdStadium",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
