namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogues",
                c => new
                    {
                        IDDanhMuc = c.String(nullable: false, maxLength: 10),
                        TenDanhMuc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDDanhMuc);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        IDMon = c.String(nullable: false, maxLength: 10),
                        TenMon = c.String(nullable: false),
                        Gia = c.Int(nullable: false),
                        IDDanhMuc = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.IDMon)
                .ForeignKey("dbo.Catalogues", t => t.IDDanhMuc)
                .Index(t => t.IDDanhMuc);
            
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
                .PrimaryKey(t => t.IDOrder)
                .ForeignKey("dbo.Menus", t => t.IDMon)
                .ForeignKey("dbo.Orders", t => t.Order_IDOrder)
                .Index(t => t.IDMon)
                .Index(t => t.Order_IDOrder);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IDOrder = c.Int(nullable: false, identity: true),
                        IDBan = c.String(maxLength: 10),
                        IDNhanVien = c.String(),
                        NgayMo = c.DateTime(nullable: false),
                        NgayDong = c.DateTime(nullable: false),
                        TinhTrangThanhToan = c.Boolean(nullable: false),
                        TaiKhoan_IDTaiKhoan = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.IDOrder)
                .ForeignKey("dbo.Tables", t => t.IDBan)
                .ForeignKey("dbo.TaiKhoans", t => t.TaiKhoan_IDTaiKhoan)
                .Index(t => t.IDBan)
                .Index(t => t.TaiKhoan_IDTaiKhoan);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        IDBAN = c.String(nullable: false, maxLength: 10),
                        KhuVuc = c.String(),
                        Trangthai = c.Boolean(nullable: false),
                        SoLuongChoNgoi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDBAN);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        IDTaiKhoan = c.String(nullable: false, maxLength: 10),
                        password = c.String(nullable: false, maxLength: 10),
                        TenNhanVien = c.String(nullable: false, maxLength: 50),
                        LoaiTaiKhoan = c.String(),
                        TrangThai = c.String(),
                    })
                .PrimaryKey(t => t.IDTaiKhoan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TaiKhoan_IDTaiKhoan", "dbo.TaiKhoans");
            DropForeignKey("dbo.Orders", "IDBan", "dbo.Tables");
            DropForeignKey("dbo.OrderDetails", "Order_IDOrder", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "IDMon", "dbo.Menus");
            DropForeignKey("dbo.Menus", "IDDanhMuc", "dbo.Catalogues");
            DropIndex("dbo.Orders", new[] { "TaiKhoan_IDTaiKhoan" });
            DropIndex("dbo.Orders", new[] { "IDBan" });
            DropIndex("dbo.OrderDetails", new[] { "Order_IDOrder" });
            DropIndex("dbo.OrderDetails", new[] { "IDMon" });
            DropIndex("dbo.Menus", new[] { "IDDanhMuc" });
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.Tables");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.Catalogues");
        }
    }
}
