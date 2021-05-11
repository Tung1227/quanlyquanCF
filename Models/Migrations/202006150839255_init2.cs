namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tables", "Trangthai");
            DropColumn("dbo.TaiKhoans", "TrangThai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaiKhoans", "TrangThai", c => c.String());
            AddColumn("dbo.Tables", "Trangthai", c => c.Boolean(nullable: false));
        }
    }
}
