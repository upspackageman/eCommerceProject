namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
                    CustomerName = c.String(),
                    Address1 = c.String(),
                    Town = c.String(),
                    PostCode = c.String(),
                })
                .PrimaryKey(t => t.CustomerId);

            CreateTable(
                "dbo.OrderItem",
                c => new
                {
                    OrderItemId = c.Int(nullable: false, identity: true),
                    ProductId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Order_OrderId = c.Int(),
                })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);

            CreateTable(
                "dbo.Order",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    OrderDate = c.DateTime(nullable: false),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrderId);

            CreateTable(
                "dbo.Product",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    ImageUrl = c.String(maxLength: 255),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.ProductId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Customers");
        }
    }
}
