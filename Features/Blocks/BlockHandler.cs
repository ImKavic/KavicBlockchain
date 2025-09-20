using KavicBlockchain.Services.Blocks.Services;

namespace KavicBlockchain.Features.Blocks;

public static class BlockHandler
{
    public static IResult GetChain(IBlockchainService service)
    {
        var chain = service.GetFullChain();
        return Results.Ok(chain);
    }

    public static IResult AddBlock(IBlockchainService service, BlockDto dto)
    {
        var block = service.AddBlock(dto.Transactions);
        return Results.Ok(block.Id);
    }
}

public record BlockDto(List<TransactionDto> Transactions);
public record TransactionDto(string From, string To, decimal Amount);
