using System;
using SQLite;

namespace oinkapp.Model
{
    public class AhorroItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime FechaDeposito { get; set; }
        public Decimal Cantidad { get; set; }
    }
}