using System;
using SQLite;
namespace oinkapp.Model
{
    public class Saving
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Quantity { get; set; }

        public DateTime DateRegister { get; set; }
    }
}
