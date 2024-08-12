using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using StarCrossing.HybridApp.Data;
using StarCrossing.HybridApp.Data.Resources;
using System.Diagnostics.CodeAnalysis;

namespace StarCrossing.HybridApp.Components.Pages.Account;

public partial class Register
{
    private static readonly string[] AvailablePortraits = ["priestess", "sailor", "sword"];

    [Inject, NotNull]
    private StarCrossingDbContext? DbContext { get; set; }

    [Inject, NotNull]
    private NavigationManager? Navigation { get; set; }

    private string VassalName { get; set; } = "";
    private string Portrait { get; set; } = "";

    private bool IsSubmitting { get; set; }
    private bool IsValid => !string.IsNullOrWhiteSpace(VassalName) && !string.IsNullOrWhiteSpace(Portrait);

    private async Task Submit()
    {
        if (IsSubmitting) return;
        IsSubmitting = true;

        await DbContext.Database.MigrateAsync();

        var sign = ((int)((DateTimeOffset.UtcNow.DayOfYear - 1) / (365 / 13f))) % 13;
        var element = DateTimeOffset.UtcNow.DayOfYear % Enum.GetValues<Data.Element>().Length;

        DbContext.AddRange(
            new Player(),
            new Vassal
            {
                Name = VassalName.Trim(),
                Portrait = Portrait,
                Level = 0,
                Willpower = 1,
                Element = (Data.Element)element,
                Species = Species.Human,
                Sign = (AstrologicalSign)sign,
                Nature = Nature.Evangelist
            },
            new Palace
            {
                Position = 0,
                LastHarvestedOn = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(6)),
            },
            new Wood() { Quantity = 80 },
            new Wheat() { Quantity = 50 },
            new Gold() { Quantity = 20 }
        );

        await DbContext.SaveChangesAsync();

        Navigation.NavigateTo("", forceLoad: true);
    }
}