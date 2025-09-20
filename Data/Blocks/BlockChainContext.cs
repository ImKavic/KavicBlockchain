using KavicBlockchain.Models.Blocks;
using Microsoft.EntityFrameworkCore;
using KavicBlockchain.Data;

namespace KavicBlockchain.Data.Blocks;

public class BlockchainContext : DbContext
{
    public BlockchainContext(DbContextOptions<BlockchainContext> options) : base(options) { }

    public DbSet<Block> Blocks { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyDecimalConfiguration();
        modelBuilder.ApplySingularization();

        modelBuilder.HasAnnotation("Relational:MigrationsHistoryTable", "MigrationHistory");
    }
}