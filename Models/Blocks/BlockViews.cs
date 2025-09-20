namespace KavicBlockchain.Models.Blocks;

public record TransactionView(string From, string To, decimal Amount);

public record BlockView(
    int Index,
    DateTime Timestamp,
    string PreviousHash,
    string Hash,
    int Nonce,
    List<TransactionView> Transactions
);