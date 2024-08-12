using System.Text.Json.Serialization;

namespace StarCrossing.HybridApp.Data;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Species
{
    Human,
    Midine, // animal-people (based on Akkadian word for cat: Midinu)
    Ruqu, // strange-looking, creepy-elf people (Akkadian word for distant places and times; unfathomableness)
    Puturu, // fungus-people (Akkadian word for "mushroom")
}