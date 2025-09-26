using KavicBlockchain;
using KavicBlockchain.Data.Blocks;
using KavicBlockchain.Features;
using KavicBlockchain.Repositories.Blocks;
using KavicBlockchain.Services.Blocks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAllDbContexts(builder.Configuration, "DefaultConnection");

builder.Services.AddScoped<IBlockchainRepository, BlockchainRepository>();
builder.Services.AddScoped<IBlockchainService, BlockchainService>();

var app = builder.Build();

try
{
    app.Services.ApplyMigrations<BlockchainContext>();
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
