using KavicBlockchain.Features.Blocks;

namespace KavicBlockchain.Features;

public static class EndpointMapping
{
    public static void MapEndpoints(this WebApplication app)
    {
        BlockFeature.MapEndpoints(app);
    }
}