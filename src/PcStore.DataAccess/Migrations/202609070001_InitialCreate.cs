using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using PcStore.DataAccess.Context;

namespace PcStore.DataAccess.Migrations;

 [DbContext(typeof(PcStoreDbContext))]
 [Migration("202609070001_InitialCreate")]
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            CREATE TABLE categories (id uuid PRIMARY KEY, name varchar(120) NOT NULL, slug varchar(140) NOT NULL UNIQUE, created_at_utc timestamptz NOT NULL, updated_at_utc timestamptz NULL);
            CREATE TABLE brands (id uuid PRIMARY KEY, name varchar(120) NOT NULL UNIQUE, created_at_utc timestamptz NOT NULL, updated_at_utc timestamptz NULL);
            CREATE TABLE products (id uuid PRIMARY KEY, name varchar(200) NOT NULL, sku varchar(64) NOT NULL UNIQUE, description text NULL, price numeric(18,2) NOT NULL, category_id uuid NOT NULL REFERENCES categories(id), brand_id uuid NULL REFERENCES brands(id), is_active boolean NOT NULL, created_at_utc timestamptz NOT NULL, updated_at_utc timestamptz NULL);
            CREATE TABLE inventory_items (id uuid PRIMARY KEY, product_id uuid NOT NULL UNIQUE REFERENCES products(id), quantity_on_hand integer NOT NULL, quantity_reserved integer NOT NULL, created_at_utc timestamptz NOT NULL, updated_at_utc timestamptz NULL);
            CREATE TABLE orders (id uuid PRIMARY KEY, customer_email varchar(320) NOT NULL, status varchar(30) NOT NULL, created_at_utc timestamptz NOT NULL, updated_at_utc timestamptz NULL);
            CREATE TABLE order_items (id uuid PRIMARY KEY, order_id uuid NOT NULL REFERENCES orders(id) ON DELETE CASCADE, product_id uuid NOT NULL, product_name varchar(200) NOT NULL, sku varchar(64) NOT NULL, unit_price numeric(18,2) NOT NULL, quantity integer NOT NULL, created_at_utc timestamptz NOT NULL, updated_at_utc timestamptz NULL);
            """);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP TABLE IF EXISTS order_items, orders, inventory_items, products, brands, categories CASCADE;");
    }
}
