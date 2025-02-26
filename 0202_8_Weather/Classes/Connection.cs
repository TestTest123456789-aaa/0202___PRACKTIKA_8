using Microsoft.EntityFrameworkCore;

namespace _0202_8_Weather.Classes
{
    internal class Connection : DbContext
    {
        public DbSet<Weather> Weather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseMySql("server=localhost;database=pr8_0202;user=root;pwd=Asdfg123;",
                new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}