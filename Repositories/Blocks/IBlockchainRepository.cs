using KavicBlockchain.Models.Blocks;

namespace KavicBlockchain.Repositories.Blocks;

public interface IBlockchainRepository
{
    IList<Block> Chain { get; }
    void Add(Block block);

    IEnumerable<Block> GetChain();
    int NextIndex();
    string GetLatestHash();
    void AddBlock(Block block);
}