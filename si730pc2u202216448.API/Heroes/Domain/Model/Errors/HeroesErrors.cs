using si730pc2u202216448.API.Shared.Domain.Model.Errors;

namespace si730pc2u202216448.API.Heroes.Domain.Model.Errors;

/// <summary>
///     Catalog of domain errors of the Heroes bounded context.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public static class HeroesErrors
{
    public static readonly Error HeroNotFound =
        Error.NotFound("Heroes.HeroNotFound", "The specified hero was not found.");

    public static readonly Error DuplicateHero =
        Error.Conflict("Heroes.DuplicateHero",
            "A hero with the same hero id is already registered in the same place, country and continent.");

    public static readonly Error InvalidHeroId =
        Error.Validation("Heroes.InvalidHeroId", "The hero id must be greater than zero.");

    public static readonly Error InvalidRegisterEmailAddress =
        Error.Validation("Heroes.InvalidRegisterEmailAddress",
            "The register email address must be a valid, non-blank email address of up to 50 characters.");

    public static readonly Error InvalidHeroPlace =
        Error.Validation("Heroes.InvalidHeroPlace",
            "The hero place must not be blank and must not exceed 50 characters.");

    public static readonly Error InvalidHeroCountry =
        Error.Validation("Heroes.InvalidHeroCountry",
            "The hero country must not be blank and must not exceed 250 characters.");

    public static readonly Error InvalidHeroContinent =
        Error.Validation("Heroes.InvalidHeroContinent",
            "The hero continent is required and must be one of AMERICAN, EUROPE, AFRICA, ASIA or OCEANIA.");

    public static readonly Error InvalidHeroAbility =
        Error.Validation("Heroes.InvalidHeroAbility",
            "The hero ability must not be blank and must not exceed 50 characters.");
}
