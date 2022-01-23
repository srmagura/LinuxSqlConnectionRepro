using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=LinuxSqlConnectionRepro;TrustServerCertificate=True;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}