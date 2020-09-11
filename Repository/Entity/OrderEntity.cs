using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Repository.Entity
{
    public class OrderContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=orders.db");
    }
    
    public class OrderEntity
    {
        public string id { get; set; }
        public int state { get; set; }
    }
}
