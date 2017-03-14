namespace BookShopSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;

    using Migrations;

    public class BookShopMain
    {
        public static void Main(string[] args)
        {
            var strategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(strategy);

            var context = new BookShopContext();

            Console.WriteLine(context.Authors.Count());
        }
    }
}
