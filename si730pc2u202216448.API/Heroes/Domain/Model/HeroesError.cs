namespace si730pc2u202216448.API.Heroes.Domain.Model;

/// <summary>
///     Represents the errors of the Heroes bounded context.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public enum HeroesError
{
    None,
    HeroNotFound,
    DuplicateHero,
    InvalidHeroId,
    InvalidRegisterEmailAddress,
    InvalidHeroPlace,
    InvalidHeroCountry,
    InvalidHeroContinent,
    InvalidHeroAbility,
    OperationCancelled,
    DatabaseError,
    InternalServerError
}
