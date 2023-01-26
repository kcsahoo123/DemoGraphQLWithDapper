using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dot6.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Dot6.DataAccess
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Cake> Cake { get; set; }
    }
}
