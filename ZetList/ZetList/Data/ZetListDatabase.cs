using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZetList.Models;

namespace ZetList.Data
{
    public class ZetListDatabase : DbContext
    {

        protected string DatabasePath { get; set; }

        public DbSet<Document> Documents { get; set; }

        protected ZetListDatabase(string databasePath)
        {
            DatabasePath = databasePath;
        }
        public static ZetListDatabase Create(string databasePath)
        {
            var dbContext = new ZetListDatabase(databasePath);
            //dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            return dbContext;
        }

        public async Task<List<Document>> GetDocumentsAsync()
        {
            return await Documents.ToListAsync();
        }

        public async Task<int> SaveItemAsync(Document document)
        {
            if (document.ID == 0)
            {
                await Documents.AddAsync(document);
            }
            return await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = new SqliteConnection($"Filename={DatabasePath}");
            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "PRAGMA key = password;";
            command.ExecuteNonQuery();

            optionsBuilder.UseSqlite(conn);
        }

    }
}
