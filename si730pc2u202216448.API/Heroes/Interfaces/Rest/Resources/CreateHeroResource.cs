namespace si730pc2u202216448.API.Heroes.Interfaces.Rest.Resources;

/// <summary>
///     Create hero resource for REST API
/// </summary>
/// <remarks>
///     The hero id is not part of the body, it is specified in the request path.
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
/// <param name="RegisterEmailAddress">
///     The email address of the owner that registers the hero (valid email, up to 50 characters)
/// </param>
/// <param name="HeroPlace">
///     The place of the hero (up to 50 characters)
/// </param>
/// <param name="HeroCountry">
///     The country of the hero (up to 250 characters)
/// </param>
/// <param name="HeroContinent">
///     The name of the continent of the hero: AMERICAN, EUROPE, AFRICA, ASIA or OCEANIA
/// </param>
/// <param name="HeroAbility">
///     The ability of the hero (up to 50 characters)
/// </param>
public record CreateHeroResource(
    string? RegisterEmailAddress,
    string? HeroPlace,
    string? HeroCountry,
    string? HeroContinent,
    string? HeroAbility);
