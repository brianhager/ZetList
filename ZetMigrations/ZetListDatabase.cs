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

        //protected ZetListDatabase(string databasePath)
        //{
        //    DatabasePath = databasePath;
        //}
        //public static ZetListDatabase Create(string databasePath)
        //{
        //    var dbContext = new ZetListDatabase(databasePath);
        //    dbContext.Database.EnsureCreated();
        //    dbContext.Database.Migrate();
        //    return dbContext;
        //}

        //public async Task<List<Document>> GetDocumentsAsync()
        //{
        //    return await Documents.ToListAsync();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite($"Filename={DatabasePath}");
            optionsBuilder.UseSqlite($"Filename=./ZetList.sqlite");
            //optionsBuilder.UseSqlite($"Data Source=ZetList.db");
        }

    }
}
