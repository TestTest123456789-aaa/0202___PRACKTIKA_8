using System.Data.Entity;

namespace _0202_8_Weather.Classes
{
    internal class Connection : DbContext
    {
        public DbSet<Weather> DataWeather { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;database=0202pr8;user=root;pwd=Asdfg123", new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}
