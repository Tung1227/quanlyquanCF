namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        IDOrder = c.Int(nullable: false),
                        IDMon = c.String(nullable: false, maxLength: 10),
                        Gia = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDOrder, t.IDMon })
                .ForeignKey("dbo.Menus", t => t.IDMon, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.IDOrder, cascadeDelete: true)
                .Index(t => t.IDOrder)
                .Index(t => t.IDMon);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "IDOrder", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "IDMon", "dbo.Menus");
            DropIndex("dbo.OrderDetails", new[] { "IDMon" });
            DropIndex("dbo.OrderDetails", new[] { "IDOrder" });
            DropTable("dbo.OrderDetails");
        }
    }
}
