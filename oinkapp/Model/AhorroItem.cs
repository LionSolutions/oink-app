using SQLite;
using System;

namespace oinkapp.Model
{
    public class AhorroItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime FechaDeposito { get; set; }
        public decimal Cantidad { get; set; }
        public bool EsCompra { get; set; }
        public string NombreCompra { get; set; }
    }
}