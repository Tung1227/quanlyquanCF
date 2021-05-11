namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "IDMon", "dbo.Menus");
            DropForeignKey("dbo.OrderDetails", "Order_IDOrder", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "IDMon" });
            DropIndex("dbo.OrderDetails", new[] { "Order_IDOrder" });
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        IDOrder = c.Int(nullable: false, identity: true),
                        IDMon = c.String(maxLength: 10),
                        Gia = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        Order_IDOrder = c.Int(),
                    })
                .PrimaryKey(t => t.IDOrder);
            
            CreateIndex("dbo.OrderDetails", "Order_IDOrder");
            CreateIndex("dbo.OrderDetails", "IDMon");
            AddForeignKey("dbo.OrderDetails", "Order_IDOrder", "dbo.Orders", "IDOrder");
            AddForeignKey("dbo.OrderDetails", "IDMon", "dbo.Menus", "IDMon");
        }
    }
}
