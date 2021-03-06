﻿using System;
using SQLite;
namespace oinkapp.Model
{
    public class Saving
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Quantity { get; set; } = 0;

        public DateTime DateRegister { get; set; }
    }
}
