namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Orders", newName: "OrderMs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OrderMs", newName: "Orders");
        }
    }
}
