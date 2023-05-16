using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(500)", maxLength: 500, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserClaim = table.Column<int>(type: "int", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 5, 16, 15, 38, 3, 579, DateTimeKind.Local).AddTicks(9382))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UnitCalorie = table.Column<double>(type: "float", nullable: false),
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 5, 16, 15, 38, 3, 579, DateTimeKind.Local).AddTicks(6261)),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 5, 16, 15, 38, 3, 579, DateTimeKind.Local).AddTicks(6629)),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealTypeID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(350)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 5, 16, 15, 38, 3, 578, DateTimeKind.Local).AddTicks(6916)),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 5, 16, 15, 38, 3, 578, DateTimeKind.Local).AddTicks(7375))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_MealType_MealTypeID",
                        column: x => x.MealTypeID,
                        principalTable: "MealType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meal_User_UserName",
                        column: x => x.UserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gram = table.Column<double>(type: "float", nullable: false),
                    MealID = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealDetail_Meal_MealID",
                        column: x => x.MealID,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MealType",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Kahvaltı" },
                    { 2, "Ara Öğün" },
                    { 3, "Öğle Yemeği" },
                    { 4, "Akşam Yemeği" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[,]
                {
                    { 1, "Et" },
                    { 2, "Balık" },
                    { 3, "Temel Gıda" },
                    { 4, "Sebze" },
                    { 5, "Meyve" },
                    { 6, "Lokanta Yemeği" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserName", "BirthDate", "PasswordHash", "UserClaim" },
                values: new object[] { "admin", new DateTime(2023, 5, 16, 15, 38, 3, 580, DateTimeKind.Local).AddTicks(809), new byte[] { 140, 105, 118, 229, 181, 65, 4, 21, 189, 233, 8, 189, 77, 238, 21, 223, 177, 103, 169, 200, 115, 252, 75, 184, 168, 31, 111, 42, 180, 72, 169, 24 }, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_MealTypeID",
                table: "Meal",
                column: "MealTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_UserName",
                table: "Meal",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_MealDetail_MealID",
                table: "MealDetail",
                column: "MealID");

            migrationBuilder.CreateIndex(
                name: "IX_MealDetail_ProductId",
                table: "MealDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product",
                column: "ProductTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealDetail");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "MealType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
