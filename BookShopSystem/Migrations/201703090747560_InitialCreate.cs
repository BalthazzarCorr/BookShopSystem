namespace BookShopSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Edition = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CopiesCount = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);

            this.CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
            this.DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Categories");
            this.DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            this.DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
            this.DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            this.DropIndex("dbo.Books", new[] { "AuthorId" });
            this.DropTable("dbo.CategoryBooks");
            this.DropTable("dbo.Categories");
            this.DropTable("dbo.Books");
            this.DropTable("dbo.Authors");
        }
    }
}
