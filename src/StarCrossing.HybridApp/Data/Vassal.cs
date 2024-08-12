namespace StarCrossing.HybridApp.Data;

public sealed class Vassal
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string Portrait { get; set; } = "";
    public int Level { get; set; }
    public int Willpower { get; set; } = 1;
    public Element Element { get; set; }
    public Species Species { get; set; }
    public AstrologicalSign Sign { get; set; }
    public Nature Nature { get; set; }
}
