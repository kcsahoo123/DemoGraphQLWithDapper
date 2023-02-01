using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dot6.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

namespace Dot6.DataAccess
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Cake> Cake { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyWorldDbContext>
    {
        public MyWorldDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<MyWorldDbContext>();
            var connectionString = configuration.GetConnectionString("MyWorldDbConnection");
            builder.UseSqlServer(connectionString);
            return new MyWorldDbContext(builder.Options);
        }
    }
}
