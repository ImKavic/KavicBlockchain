namespace KavicBlockchain.Features.Blocks;

public static class BlockFeature
{
    public static void MapEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api/blocks");

        api.MapGet("/chain", BlockHandler.GetChain)
           .WithName("GetBlockchainChain");

        api.MapPost("/block", BlockHandler.AddBlock)
           .WithName("AddBlockchainBlock");
    }
}
