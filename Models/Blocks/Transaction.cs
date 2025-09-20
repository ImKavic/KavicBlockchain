namespace KavicBlockchain.Models.Blocks;

public class Transaction
{
    public int Id { get; set; }
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public decimal Amount { get; set; }

    public int BlockId { get; set; }
    public Block Block { get; set; } = null!;
}