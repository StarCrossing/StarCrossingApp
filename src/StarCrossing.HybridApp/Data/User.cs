namespace StarCrossing.HybridApp.Data;

public sealed class Player
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public int Level { get; set; }
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
}
