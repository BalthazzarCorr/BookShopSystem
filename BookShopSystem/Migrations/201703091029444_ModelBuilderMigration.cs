namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelBuilderMigration : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Books", "Book_Id", "dbo.Books");
            this.DropIndex("dbo.Books", new[] { "Book_Id" });
            this.CreateTable(
                "dbo.BookBooks",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Book_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Book_Id1 })
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id1)
                .Index(t => t.Book_Id)
                .Index(t => t.Book_Id1);

            this.DropColumn("dbo.Books", "Book_Id");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Books", "Book_Id", c => c.Int());
            this.DropForeignKey("dbo.BookBooks", "Book_Id1", "dbo.Books");
            this.DropForeignKey("dbo.BookBooks", "Book_Id", "dbo.Books");
            this.DropIndex("dbo.BookBooks", new[] { "Book_Id1" });
            this.DropIndex("dbo.BookBooks", new[] { "Book_Id" });
            this.DropTable("dbo.BookBooks");
            this.CreateIndex("dbo.Books", "Book_Id");
            this.AddForeignKey("dbo.Books", "Book_Id", "dbo.Books", "Id");
        }
    }
}
