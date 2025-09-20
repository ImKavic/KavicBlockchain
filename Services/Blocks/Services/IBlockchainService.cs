using KavicBlockchain.Features.Blocks;
using KavicBlockchain.Models.Blocks;
namespace KavicBlockchain.Services.Blocks.Services;

public interface IBlockchainService
{
    IEnumerable<BlockView> GetFullChain();
    Block AddBlock(IEnumerable<TransactionDto> transactions);
}