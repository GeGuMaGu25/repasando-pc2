namespace si730pc2u202216448.API.Heroes.Domain.Model.Commands;

/// <summary>
///     Command to create (register) a hero.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
/// <param name="HeroId">
///     The identifier of the hero in another bounded context.
/// </param>
/// <param name="RegisterEmailAddress">
///     The email address of the owner that registers the hero.
/// </param>
/// <param name="HeroPlace">
///     The place of the hero.
/// </param>
/// <param name="HeroCountry">
///     The country of the hero.
/// </param>
/// <param name="HeroContinent">
///     The name of the continent of the hero.
/// </param>
/// <param name="HeroAbility">
///     The ability of the hero.
/// </param>
public record CreateHeroCommand(
    long HeroId,
    string? RegisterEmailAddress,
    string? HeroPlace,
    string? HeroCountry,
    string? HeroContinent,
    string? HeroAbility);
