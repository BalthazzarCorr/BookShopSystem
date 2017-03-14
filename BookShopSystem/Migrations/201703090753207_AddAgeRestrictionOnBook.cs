namespace BookShopSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeRestrictionOnBook : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Books", "AgeRestriction", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Books", "AgeRestriction");
        }
    }
}
