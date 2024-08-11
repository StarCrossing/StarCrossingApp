namespace StarCrossing.HybridApp.Data;

public abstract class GameResource
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public int Quantity { get; set; }
    public string Name { get; private set; }

    protected GameResource()
    {
        Name = GetType().Name;
    }
}
