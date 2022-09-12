using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgreementManagement.Persistance.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Products",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Code",
                table: "Products",
                newName: "IX_Products_Number");

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Code", "Description", "IsActive", "IsDeleted" },
                values: new object[] { 1L, "Code_1", "Undrstandable description", true, false });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Code", "Description", "IsActive", "IsDeleted" },
                values: new object[] { 2L, "Code_2", "Some group", true, false });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Code", "Description", "IsActive", "IsDeleted" },
                values: new object[] { 3L, "Code_3", "Any Description", false, false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Number", "Price", "ProductGroupId" },
                values: new object[] { 1L, "Very interesting description for this product", true, false, "0001", 2000m, 1L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Number", "Price", "ProductGroupId" },
                values: new object[] { 2L, "Some description for this product", true, false, "0002", 5000m, 2L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Number", "Price", "ProductGroupId" },
                values: new object[] { 3L, "Short Description", false, false, "0003", 1200m, 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Products",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Number",
                table: "Products",
                newName: "IX_Products_Code");
        }
    }
}
