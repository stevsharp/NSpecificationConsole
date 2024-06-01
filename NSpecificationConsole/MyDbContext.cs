using Microsoft.EntityFrameworkCore;


namespace NSpecificationConsole;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
