using System;
using SQLite;

namespace oinkapp.Model
{
    public class DeseoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaMeta  {  get; set; }
    }
}
