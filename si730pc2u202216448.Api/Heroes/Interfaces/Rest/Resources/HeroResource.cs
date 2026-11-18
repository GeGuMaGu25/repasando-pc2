namespace si730pc2u202216448.Api.Heroes.Interfaces.Rest.Resources;

/// <summary>
///     Hero resource for REST API
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
/// <param name="Id">
///     The unique identifier of the hero registration
/// </param>
/// <param name="HeroId">
///     The identifier of the hero in another bounded context
/// </param>
/// <param name="RegisterEmailAddress">
///     The email address of the owner that registered the hero
/// </param>
/// <param name="HeroPlace">
///     The place of the hero
/// </param>
/// <param name="HeroCountry">
///     The country of the hero
/// </param>
/// <param name="HeroContinent">
///     The name of the continent of the hero
/// </param>
/// <param name="HeroAbility">
///     The ability of the hero
/// </param>
/// <param name="RegisterDateAt">
///     The date and time when the hero was registered
/// </param>
public record HeroResource(
    long Id,
    long HeroId,
    string RegisterEmailAddress,
    string HeroPlace,
    string HeroCountry,
    string HeroContinent,
    string HeroAbility,
    DateTime RegisterDateAt);
