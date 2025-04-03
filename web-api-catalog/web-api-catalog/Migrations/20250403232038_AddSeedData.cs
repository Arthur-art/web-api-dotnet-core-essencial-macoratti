using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_catalog.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into categories(Nome, ImagemUrl) Values('Bebidas', 'bebidas.png')");
            mb.Sql("insert into categories(Nome, ImagemUrl) Values('Lanches', 'lanches.png')");
            mb.Sql("insert into categories(Nome, ImagemUrl) Values('Sobremesas', 'sobremesas.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from categories");
        }
    }
}
