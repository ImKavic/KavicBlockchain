using KavicBlockchain.Features.Blocks;
using KavicBlockchain.Models.Blocks;
using KavicBlockchain.Repositories.Blocks;

namespace KavicBlockchain.Services.Blocks.Services;

public class BlockchainService : IBlockchainService
{
    private readonly IBlockchainRepository _repo;

    public BlockchainService(IBlockchainRepository repo) => _repo = repo;

    public IEnumerable<BlockView> GetFullChain()
    {
        var chain = _repo.GetChain();
        return chain.Select(b => new BlockView(
            b.Index,
            b.Timestamp,
            b.PreviousHash,
            b.Hash,
            b.Nonce,
            b.Transactions.Select(t => new TransactionView(t.From, t.To, t.Amount)).ToList()
        )).ToList();
    }

    public Block AddBlock(IEnumerable<TransactionDto> transactions)
    {
        var block = new Block
        {
            Index = _repo.NextIndex(),
            Timestamp = DateTime.UtcNow,
            PreviousHash = _repo.GetLatestHash(),

            Transactions = transactions.Select(t => new Transaction
            {
                From = t.From,
                To = t.To,
                Amount = t.Amount
            }).ToList()
        };
        
        block.Hash = block.CalculateHash();
        
        _repo.AddBlock(block);
        return block;
    }
}