using Microsoft.EntityFrameworkCore;
using STGApplication.Models;

namespace STGApplication.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Animal> animal { get; set; }
    }
}
