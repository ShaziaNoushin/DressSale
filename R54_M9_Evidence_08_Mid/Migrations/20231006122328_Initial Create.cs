using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R54_M9_Evidence_08_Mid.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dresses",
                columns: table => new
                {
                    DressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DressName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dresses", x => x.DressId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    DressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Dresses_DressId",
                        column: x => x.DressId,
                        principalTable: "Dresses",
                        principalColumn: "DressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DressId",
                table: "Sales",
                column: "DressId");
            string sqlI = @"CREATE PROC InsertDress @n VARCHAR(50), @p MONEY, @s INT, @pi VARCHAR(50), @o BIT
             AS
             INSERT INTO Dresses (DressName, Price, Size, Picture, OnSale)
             VALUES (@n, @p, @s, @pi, @o )
            
             GO";
            migrationBuilder.Sql(sqlI);
            string sqlU = @"CREATE PROC UpdateDress @i INT, @n VARCHAR(50), @p MONEY, @s INT, @pi VARCHAR(50), @o BIT
             AS
             UPDATE Dresses SET DressName=@n, Price=@p, Size=@s, Picture=@pi, OnSale=@o
             WHERE DressId=@i
             GO";
            migrationBuilder.Sql(sqlU);
            string sqlD = @"CREATE PROC DeleteDress @i INT
                 AS
                 DELETE Dresses 
                 WHERE DressId=@i
                 GO";
            migrationBuilder.Sql(sqlD);
            string sqlS = @"CREATE PROC InsertSale @d DATE, @q INT, @did INT
             AS
             INSERT INTO Sales ([Date], Quantity, DressId)
             VALUES (@d, @q, @did )
             GO";
            migrationBuilder.Sql(sqlS);
            string sqlSU = @"CREATE PROC UpdateSale @id INT, @d DATE, @q INT, @did INT
             AS
             UPDATE Sales SET [Date]=@d, Quantity=@q, DressId=@did
             WHERE SaleId = @id
             GO";
            migrationBuilder.Sql(sqlSU);
            string sqlDU = @"CREATE PROC DeleteSale @id INT
             AS
             DELETE Sales 
             WHERE SaleId = @id
             GO";
            migrationBuilder.Sql(sqlDU);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Dresses");
            migrationBuilder.Sql("DROP PROC InsertDress");
            migrationBuilder.Sql("DROP PROC UpdateDress");
            migrationBuilder.Sql("DROP PROC DeleteDress");
            migrationBuilder.Sql("DROP PROC InsertSale");
            migrationBuilder.Sql("DROP PROC UpdateSale");
            migrationBuilder.Sql("DROP PROC DeleteSale");
        }
    }
}

