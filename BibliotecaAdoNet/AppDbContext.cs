using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;
using System.IO;

namespace BibliotecaAdoNet
{
    public class AppDbContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "biblioteca.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
