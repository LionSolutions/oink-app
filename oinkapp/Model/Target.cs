using System;
using SQLite;
namespace oinkapp.Model
{
	public class Target
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public string Description { get; set; }

		public decimal Budget { get; set; }

		public DateTime DateRegister { get; set; }

		public DateTime EstimatePurchase { get; set; }
	}
}
