using Microsoft.EntityFrameworkCore;

namespace ZooAPI.Models
{
    public class ZooAPIContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ZooAPIContext(DbContextOptions<ZooAPIContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("MyConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Zoo> Zoo { get; set; } = null!;
        public DbSet<Animal> Animal { get; set; } = null!;
    }
}
