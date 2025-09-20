using System.Security.Cryptography;
using System.Text;

namespace KavicBlockchain.Models.Blocks;

public class Block
{
    public int Id { get; set; }
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public string PreviousHash { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
    public int Nonce { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public string CalculateHash()
    {
        var data = $"{Index}-{Timestamp}-{PreviousHash}-{Nonce}-{string.Join(",", Transactions.Select(t => $"{t.From}{t.To}{t.Amount}"))}";

        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}