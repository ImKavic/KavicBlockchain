using KavicBlockchain.Data.Blocks;
using KavicBlockchain.Models.Blocks;
using Microsoft.EntityFrameworkCore;

namespace KavicBlockchain.Repositories.Blocks;

public class BlockchainRepository : IBlockchainRepository
{
    private readonly BlockchainContext _ctx;

    public BlockchainRepository(BlockchainContext ctx) => _ctx = ctx;

    public IList<Block> Chain => _ctx.Blocks
                                     .Include(b => b.Transactions)
                                     .OrderBy(b => b.Index)
                                     .ToList();

    public void Add(Block block)
    {
        _ctx.Blocks.Add(block);
        _ctx.SaveChanges();
    }
    
    public IEnumerable<Block> GetChain() => Chain;

    public void AddBlock(Block block)
    {
        _ctx.Blocks.Add(block);
        _ctx.SaveChanges();
    }
    
    public int NextIndex() => !Chain.Any() ? 0 : Chain.Max(b => b.Index) + 1;

    public string GetLatestHash() => !Chain.Any() ? string.Empty : Chain.Last().Hash;
}