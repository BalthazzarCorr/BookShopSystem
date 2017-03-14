namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Copies", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "CopiesCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "CopiesCount", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Copies");
        }
    }
}
