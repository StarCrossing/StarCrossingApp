using System.Text.Json.Serialization;

namespace StarCrossing.HybridApp.Data;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Element
{
    Fire,
    Plant,
    Earth,
    Ice,
    Water,
    Lightning,
    Metal
}
