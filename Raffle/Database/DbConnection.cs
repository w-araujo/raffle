using Microsoft.EntityFrameworkCore;
using Raffle.Models;

namespace Raffle.Database
{
    public class DbConnection:DbContext
    {
        public DbSet<User> User {  get; set; }

        public string DbPath { get; }

        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "raffle.db");
            Console.WriteLine($"local banco de dados: {DbPath}");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
