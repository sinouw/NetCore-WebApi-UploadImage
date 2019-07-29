using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadImage.Migrations
{
    public partial class relation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StadiumIdStadium",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StadiumIdStadium",
                table: "Images",
                column: "StadiumIdStadium");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Stadiums_StadiumIdStadium",
                table: "Images",
                column: "StadiumIdStadium",
                principalTable: "Stadiums",
                principalColumn: "IdStadium",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Stadiums_StadiumIdStadium",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StadiumIdStadium",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StadiumIdStadium",
                table: "Images");
        }
    }
}
