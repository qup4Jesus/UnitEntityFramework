﻿
namespace TaskEntityFramework.DAL.Model
{
    internal class User : Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }

    }
}
