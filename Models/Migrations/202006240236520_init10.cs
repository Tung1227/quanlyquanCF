namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init10 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderMs", name: "TaiKhoan_IDTaiKhoan", newName: "IDTaiKhoan");
            RenameIndex(table: "dbo.OrderMs", name: "IX_TaiKhoan_IDTaiKhoan", newName: "IX_IDTaiKhoan");
            DropColumn("dbo.OrderMs", "IDNhanVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderMs", "IDNhanVien", c => c.String());
            RenameIndex(table: "dbo.OrderMs", name: "IX_IDTaiKhoan", newName: "IX_TaiKhoan_IDTaiKhoan");
            RenameColumn(table: "dbo.OrderMs", name: "IDTaiKhoan", newName: "TaiKhoan_IDTaiKhoan");
        }
    }
}
