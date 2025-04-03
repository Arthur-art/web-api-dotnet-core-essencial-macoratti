using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_catalog.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into products(Name, Description, Price, ImageUrl, Rating, DateOfRegistration, CategoryId) Values('Coca-Cola', 'Refrigerante de cola', 5.00, 'coca-cola.png', 10, now(), 1)");
            mb.Sql("insert into products(Name, Description, Price, ImageUrl, Rating, DateOfRegistration, CategoryId) Values('X-Burguer', 'Sanduíche de carne com queijo', 15.00, 'x-burguer.png', 20, now(), 2)");
            mb.Sql("insert into products(Name, Description, Price, ImageUrl, Rating, DateOfRegistration, CategoryId) Values('Pudim', 'Sobremesa de leite condensado', 8.00, 'pudim.png', 30, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from products");
        }
    }
}
