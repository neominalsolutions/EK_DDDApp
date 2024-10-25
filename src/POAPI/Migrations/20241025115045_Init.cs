using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseQuoteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseRequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseQuotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Offer_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Offer_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseRequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseQuotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Id = table.Column<int>(type: "int", nullable: false),
                    Budget_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "PurchaseQuotes");

            migrationBuilder.DropTable(
                name: "PurchaseRequests");
        }
    }
}
