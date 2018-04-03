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

        public DbSet<MusicDocument> MusicDocuments { get; set; }

        protected ZetListDatabase(string databasePath)
        {
            DatabasePath = databasePath;
        }
        public static ZetListDatabase Create(string databasePath)
        {
            var dbContext = new ZetListDatabase(databasePath);
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            return dbContext;
        }

        public async Task<List<MusicDocument>> GetMusicDocumentsAsync()
        {
            return await MusicDocuments.ToListAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

    }
}
