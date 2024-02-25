using Microsoft.EntityFrameworkCore;
using trendy.shopping.domain.Entities.Customers;
using trendy.shopping.domain.Entities.Master.Locations;
using trendy.shopping.domain.seeds.Masters;

namespace trendy.shopping.domain.Data
{
    public class TrendyShoppingBaseContext<T> : DbContext where T : DbContext
    {
        public TrendyShoppingBaseContext(DbContextOptions<T> options)
        : base(options)
        {
        }

        #region Masters

        #region Locations
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        #endregion

        #endregion

        #region Customers
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Masters
            modelBuilder.Entity<Country>().HasData(CommonMasterDataSeed.Countries);

            modelBuilder.Entity<State>().HasData(CommonMasterDataSeed.State);

            modelBuilder.Entity<City>().HasData(CommonMasterDataSeed.City);
            #endregion
        }
    }

    public class TrendyShoppingContext : TrendyShoppingBaseContext<TrendyShoppingContext>
    {
        public TrendyShoppingContext(DbContextOptions<TrendyShoppingContext> options) : base(options)
        {
        }
    }
}
