namespace BookShopSystem
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class BookShopContext : DbContext
	{
		
		public BookShopContext()
			: base("name=BookShopContext")
		{

		}

		

		 public virtual IDbSet<Book> Books { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}