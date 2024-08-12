namespace StarCrossing.HybridApp.Data;

public abstract class Building
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; private set; }
    public int Position { get; set; }
    public DateTimeOffset LastHarvestedOn { get; set; } = DateTime.UtcNow.Subtract(TimeSpan.FromHours(6));

    protected Building()
    {
        Name = GetType().Name;
    }

    protected Building(string name)
    {
        Name = name;
    }
}

public sealed class Woodsman : Building;
public sealed class Palace : Building;
public sealed class Hunter : Building;
public sealed class Lumberyard : Building;
public sealed class Farm : Building;
public sealed class Vineyard : Building;
public sealed class Pasture : Building;
public sealed class StonePit() : Building("Stone Pit");
public sealed class MarbleQuarry() : Building("Marble Quarry");
public sealed class IronMine() : Building("Iron Mine");
public sealed class GoldMine() : Building("Gold Mine");
public sealed class Obelisk : Building;
public sealed class Temple : Building;
public sealed class Harbor : Building;
public sealed class TradeDepot() : Building("Trade Depot");
public sealed class Fishery : Building;