using System.Text.Json.Serialization;

namespace StarCrossing.HybridApp.Data;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AstrologicalSign
{
    Raven,
    Kundrav,
    EightPlants,
    River,
    DoubleTrident,
    Tablet,
    LargeCupAndLittleCup,
    Cat,
    Crown,
    TheGoddess,
    Mountain,
    PapyrusBoat,
    PanFlute
}
